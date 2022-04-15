using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.Accounts
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public string ReEnterPassword { get; set; }
    }
}
