using Ardalis.SmartEnum;

namespace Ocelot.Admin.Entity.Configurations.Routes.LoadBalancerOption;
public class LoadBalanceType : SmartEnum<LoadBalanceType>
{
    public static readonly LoadBalanceType LeastConnection = new LoadBalanceType(nameof(LeastConnection), 1);
    public static readonly LoadBalanceType RoundRobin = new LoadBalanceType(nameof(RoundRobin), 2);
    public static readonly LoadBalanceType NoLoadBalancer = new LoadBalanceType(nameof(NoLoadBalancer), 3);
    public static readonly LoadBalanceType CookieStickySessions = new LoadBalanceType(nameof(CookieStickySessions), 4);

    public LoadBalanceType(string name, int value) : base(name, value)
    {
    }
}
