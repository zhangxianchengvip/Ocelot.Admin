using Auto.Options;

namespace OcelotAdmin.Settings;
[AutoOptions(Node = "Jwt")]
public class JwtOptions
{
    public string key { get; set; }
    public int Expire { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}
