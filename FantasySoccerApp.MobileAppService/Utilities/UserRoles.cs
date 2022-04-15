namespace FantasySoccerApp.MobileAppService.Utilities
{
    public class UserRoles
    {
        public enum Roles
        {
            Standard
        }

        public static string[] GetAllRoles()
        {
            return new string[] { Roles.Standard.ToString() };
        }
    }
}
