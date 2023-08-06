using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Admin.Roles;
using Ocelot.Admin.Settings;
using Ocelot.Admin.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Ocelot.Admin.Auths;
public class AuthAppService : ApplicationService, IAuthAppService
{
    private readonly IRepository<User, Guid> _user;
    private readonly IRepository<Role, Guid> _role;
    private readonly JwtOptions _jwt;

    public AuthAppService(IRepository<User, Guid> user, IRepository<Role, Guid> role, IOptionsSnapshot<JwtOptions> options)
    {
        _user = user;
        _role = role;
        _jwt = options.Value;
    }

    public async Task<AuthViewModel> Authentication(AuthInput input, CancellationToken token)
    {
        var user = await _user.FindAsync(s => s.LoginName.Equals(input.LoginName), true, token);

        if (user is null)
        {
            throw new BusinessException();
        }

        bool ok = user.CheckPassword(input.Password);

        if (!ok)
        {
            throw new BusinessException();
        }

        var roleList = await _role.GetListAsync(r => user.UserRoles.Select(s => s.RoleId).Contains(r.Id));

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.LoginName),
            new Claim(ClaimTypes.Role,roleList.Single().Name),
        };

        // 2. 从 appsettings.json 中读取SecretKey
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.key));

        // 3. 选择加密算法
        var algorithm = SecurityAlgorithms.HmacSha256;

        // 4. 生成Credentials
        var signingCredentials = new SigningCredentials(secretKey, algorithm);

        // 5. 根据以上，生成token
        var jwtSecurityToken = new JwtSecurityToken
        (
            _jwt.Issuer,                                         //Issuer
            _jwt.Audience,                                   //Audience
            claims,                                              //Claims,
            DateTime.Now,                                //notBefore
            DateTime.Now.AddSeconds(30),    //expires
            signingCredentials                         //Credentials
        );

        // 6. 将token变为string
        new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return new AuthViewModel { Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken) };
    }
}
