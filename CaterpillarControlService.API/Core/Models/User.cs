using Microsoft.AspNetCore.Identity;

namespace CaterpillarControlService.API.Core.Models
{
    public class User:IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public List<Shift> Shifts { get; set; }
        public List<UserControlStation> UserTollStations { get; set; }
    }
}
