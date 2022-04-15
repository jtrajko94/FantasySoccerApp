using System;
namespace FantasySoccerApp.MobileAppService.Models.Accounts
{
    public class TokenModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public DateTime expires { get; set; }
    }
}
