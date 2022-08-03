using StudentShadow.Helpers;
using StudentShadow.Models;

namespace StudentShadow.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(CustomUser model);

        Task<AuthModel> GetTokenAsync(TokenRequestModel model);

        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
