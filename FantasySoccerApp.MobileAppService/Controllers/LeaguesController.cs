using FantasySoccerApp.MobileAppService.Models.SoccerAPI.Leagues;
using FantasySoccerApp.MobileAppService.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.ComponentModel.DataAnnotations;

namespace FantasySoccerApp.MobileAppService.Controllers
{
    [Route("api/leagues")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class LeaguesController : ControllerBase
    {
        [HttpGet]
        [Route("get-leagues-from-country-and-season")]
        public ActionResult GetLeaguesByCountryAndSeason([Required] string country, long? season = null)
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/leagues/country/{country}/{season}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<LeaguesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-all-leagues")]
        public ActionResult GetAllLeagues()
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/leagues/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<LeaguesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-leagues-by-type-and-season")]
        public ActionResult GetLeaguesByTypeAndSeason([Required] string type, long? season = null)
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/leagues/type/{type}/{season}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<LeaguesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-league-by-id")]
        public ActionResult GetLeagueByID([Required] long id)
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/leagues/league/{id}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<LeaguesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");

        }

        [HttpGet]
        [Route("get-current-season-for-all-leagues")]
        public ActionResult GetCurrentSeasonForAllLeagues()
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/leagues/current/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<LeaguesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-league-by-season-and-team-id")]
        public ActionResult GetLeaguebySeasonandTeamID([Required] long id, long? season = null)
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/leagues/team/{id}/{season}");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<LeaguesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");

        }

        [HttpGet]
        [Route("get-available-leagues-by-id-and-season")]
        public ActionResult GetAvailableLeaguesByIDAndSeason([Required] long id, long? season = null)
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/leagues/seasonsAvailable/{id}/{season}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<LeaguesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");

        }

        [HttpGet]
        [Route("get-leagues-by-type-and-country-and-season")]
        public ActionResult GetLeaguesByTypeAndCountryAndSeason([Required] string type, [Required] string country, long? season = null)
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/leagues/type/{type}/{country}/{season}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<LeaguesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-leagues-by-team-id-and-season")]
        public ActionResult GetLeaguesByTeamIDAndSeason([Required] long id, [Required] long season)
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/leagues/team/{id}/{season}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<LeaguesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-league-by-search")]
        public ActionResult GetLeagueBySearch([Required] string term)
        {
            term = term.Replace(" ", "_").ToLower();

            var client = new RestClient($"{Settings.APIFootballRoot}/leagues/search/{term}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<LeaguesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }
    }
}