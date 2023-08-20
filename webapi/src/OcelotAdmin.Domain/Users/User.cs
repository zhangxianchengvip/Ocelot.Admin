using OcelotAdmin.Roles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace OcelotAdmin.Users;
public class User : BasicAggregateRoot<Guid>
{
    public string LoginName { get; init; }
    private string _password;
    public string Password
    {
        private get
        {
            return _password;
        }
        set
        {
            _password = MD5Encrypt64(value);
        }
    }
    public ICollection<UserRole> UserRoles { get; private set; }

    private User() { }

    public User(Guid id, string loginName, string password) : base(id)
    {
        LoginName = Check.NotNullOrWhiteSpace(loginName, nameof(loginName));
        Password = Check.NotNullOrWhiteSpace(password, nameof(password));
        UserRoles = new Collection<UserRole>();
    }

    public bool CheckPassword(string password)
    {
        return MD5Encrypt64(password).Equals(Password);
    }

    public User AddRole(Guid roleId)
    {
        if (!UserRoles.Any(s => s.RoleId.Equals(roleId)))
        {
            UserRoles.Add(new UserRole(Id, roleId));
        }
        return this;
    }
    private string MD5Encrypt64(string str)
    {
        MD5 md5 = MD5.Create();
        byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
        return Convert.ToBase64String(s);
    }
}
