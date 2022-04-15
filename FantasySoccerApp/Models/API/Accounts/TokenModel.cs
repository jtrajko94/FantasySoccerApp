using System;
namespace FantasySoccerApp.Models.API.Accounts
{
    public class TokenModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public DateTime? expires { get; set; }
        public ValidationResponse validation { get; set; }

        public TokenModel()
        {
            validation = new ValidationResponse();
        }
    }
}
