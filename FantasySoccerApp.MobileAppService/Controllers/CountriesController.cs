using FantasySoccerApp.MobileAppService.Models.SoccerAPI.Countries;
using FantasySoccerApp.MobileAppService.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace FantasySoccerApp.MobileAppService.Controllers
{
    [Route("api/countries")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        [Route("get-countries")]
        public ActionResult GetCountries()
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/countries/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<CountriesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }
    }
}