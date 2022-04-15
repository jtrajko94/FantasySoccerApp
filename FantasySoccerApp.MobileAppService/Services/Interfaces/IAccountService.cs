using System;
using System.Threading.Tasks;
using FantasySoccerApp.MobileAppService.Models.Accounts;
using FantasySoccerApp.MobileAppService.Utilities;

namespace FantasySoccerApp.MobileAppService.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ValidationResponse> IsRegistrationValidAsync(UserModel register);
        Task<ValidationResponse> IsLoginValidAsync(UserModel login);
        TokenModel CreateBearerToken(DateTime expirationDate);
        UserModel GetUser(string id);
        UserModel GetUserByCredentials(string email, string password);
        string InsertUser(UserModel user);
        string Update(UserModel u);
    }
}
