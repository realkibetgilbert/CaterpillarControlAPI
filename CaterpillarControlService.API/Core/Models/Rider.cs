using Microsoft.AspNetCore.Identity;

namespace CaterpillarControlService.API.Core.Models
{
    public class Rider:IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
