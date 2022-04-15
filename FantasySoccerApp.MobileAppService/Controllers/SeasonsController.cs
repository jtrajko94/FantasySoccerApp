using FantasySoccerApp.MobileAppService.Models.SoccerAPI.Seasons;
using FantasySoccerApp.MobileAppService.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace FantasySoccerApp.MobileAppService.Controllers
{
    [Route("api/seasons")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class SeasonsController : ControllerBase
    {
        [HttpGet]
        [Route("get-available-seasons")]
        public ActionResult GetSeasons()
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/seasons/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<SeasonsResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }
    }
}