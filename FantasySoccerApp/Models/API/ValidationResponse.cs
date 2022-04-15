using System.Collections.Generic;

namespace FantasySoccerApp.Models.API
{
    public class ValidationResponse
    {
        public bool? IsValid { get; set; }
        public Dictionary<string,string> Issues { get; set; }
    }
}
