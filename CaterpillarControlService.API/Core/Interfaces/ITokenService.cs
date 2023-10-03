using CaterpillarControlService.API.Core.Models;

namespace CaterpillarControlService.API.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateJwtToken(User user, List<string> roles);

        Task<string> GetUserDetailsFromToken(string token);
    }
}
