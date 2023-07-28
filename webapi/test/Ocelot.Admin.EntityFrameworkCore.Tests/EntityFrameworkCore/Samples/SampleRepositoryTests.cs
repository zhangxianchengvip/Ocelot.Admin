using System.Threading.Tasks;
using Xunit;

namespace Ocelot.Admin.EntityFrameworkCore.Samples;

/* This is just an example test class.
 * Normally, you don't test ABP framework code
 * (like default AppUser repository IRepository<AppUser, Guid> here).
 * Only test your custom repository methods.
 */
public class SampleRepositoryTests : AdminEntityFrameworkCoreTestBase
{


    public SampleRepositoryTests()
    {
      
    }

    [Fact]
    public async Task Should_Query_AppUser()
    {
      
    }
}
