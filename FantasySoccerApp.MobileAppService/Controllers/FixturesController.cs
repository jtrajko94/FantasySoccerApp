using FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures;
using FantasySoccerApp.MobileAppService.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FantasySoccerApp.MobileAppService.Controllers
{
    [Route("api/fixtures")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class FixturesController : ControllerBase
    {
        [HttpGet]
        [Route("get-fixtures-by-league-and-offset")]
        // If Offset is negative, we pull previous matches otherwise pulls next matches
        public ActionResult GetFixturesByLeagueAndOffset([Required] long leagueId, int offset = 0)
        {
            var url = $"{Settings.APIFootballRoot}/fixtures/league/{leagueId}/";
            if (offset != 0)
            {
                if (offset > 0)
                {
                    url = url + "next/" + offset;
                }
                else
                {
                    url = url + "last/" + Math.Abs(offset);
                }
            }
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<FixturesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-fixtures-by-team-and-offset")]
        // If Offset is negative, we pull previous matches otherwise pulls next matches
        public ActionResult GetFixturesByTeamAndOffset([Required] long teamId, int offset = 0)
        {
            var url = $"{Settings.APIFootballRoot}/fixtures/team/{teamId}/";
            if (offset != 0)
            {
                if (offset > 0)
                {
                    url = url + "next/" + offset;
                }
                else
                {
                    url = url + "last/" + Math.Abs(offset);
                }
            }
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<FixturesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-fixtures-by-league-id")]
        public ActionResult GetFixturesByLeagueId([Required] long leagueId)
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/fixtures/league/{leagueId}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<FixturesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-fixtures-by-date")]
        public ActionResult GetFixturesByDate([Required] DateTime date)
        {
            var formattedDate = date.ToString("yyyy-MM-dd");
            var client = new RestClient($"{Settings.APIFootballRoot}/fixtures/date/{formattedDate}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<FixturesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-h2h-by-team-fixtures")]
        public ActionResult GetH2HByTeamFixtures([Required] long teamOneId, [Required] long teamTwoId)
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/fixtures/h2h/{teamOneId}/{teamTwoId}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<FixturesH2HResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-fixtures-in-play")]
        public ActionResult GetFixturesInPlay(long leagueId)
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/fixtures/live/{leagueId}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<FixturesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-fixtures-by-league-and-date")]
        public ActionResult GetFixturesByLeagueAndDate([Required] DateTime date, [Required] long leagueId)
        {
            var formattedDate = date.ToString("yyyy-MM-dd");
            var client = new RestClient($"{Settings.APIFootballRoot}/fixtures/league/{leagueId}/{formattedDate}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<FixturesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-fixtures-by-team-and-league")]
        public ActionResult GetFixturesByTeamAndLeague([Required] long teamId, [Required] long leagueId)
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/fixtures/team/{teamId}/{leagueId}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<FixturesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-fixtures-by-league-and-round")]
        public ActionResult GetFixturesByLeagueAndRound([Required] long leagueId, [Required] string round)
        {
            round = round.Replace(" ", "_").ToLower();
            var client = new RestClient($"{Settings.APIFootballRoot}/fixtures/league/{leagueId}/{round}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<FixturesResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-fixtures-by-id")]
        public ActionResult GetFixturesById([Required] long id)
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/fixtures/id/{id}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<FixturesResponseModel>();

                foreach(var fixture in results.Fixtures)
                {
                    var lineups = new List<FixtureLineupModel>();
                    foreach(var tempLineup in fixture.TempLineups)
                    {
                        var lineup = tempLineup.Value.ToObject<FixtureLineupModel>();
                        lineup.TeamName = tempLineup.Key;
                        lineups.Add(lineup);
                    }
                    fixture.Lineups = lineups;
                    fixture.TempLineups = null;
                }

                return Ok(results);
            }

            return BadRequest("API not successful");
        }

        [HttpGet]
        [Route("get-rounds-by-league-id")]
        public ActionResult GetRoundsByLeagueId([Required] long leagueId, bool current = false)
        {
            var client = new RestClient($"{Settings.APIFootballRoot}/fixtures/rounds/{leagueId}/{(current ? "current" : "")}/");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-RapidAPI-Key", Settings.APIFootballAPIKey);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var results = JObject.Parse(response.Content).SelectToken("api", true).ToObject<FixturesRoundsResponseModel>();
                return Ok(results);
            }

            return BadRequest("API not successful");
        }
    }
}