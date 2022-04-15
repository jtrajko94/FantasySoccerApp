using System.Collections.Generic;

namespace FantasySoccerApp.MobileAppService.Utilities
{
    public class ValidationResponse
    {
        public bool? IsValid { get; set; }
        public Dictionary<string,string> Issues { get; set; }
    }
}
