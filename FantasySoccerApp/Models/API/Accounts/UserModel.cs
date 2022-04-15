namespace FantasySoccerApp.Models.API.Accounts
{
    public class UserModel
    {
        public long? Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReEnterPassword { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public ValidationResponse validation { get; set; }
    }
}
