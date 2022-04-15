using System;
using FantasySoccerApp.Models.API.Fixtures;
using FantasySoccerApp.Utilities;
using Newtonsoft.Json;
using RestSharp;

namespace FantasySoccerApp.Services
{
    public class APIFixtureService
    {
        public static FixturesResponseModel GetFixturesByDate(DateTime date, string accessToken)
        {
            var client = new RestClient($"{Settings.APIRootUrl}/api/fixtures/get-fixtures-by-date/");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {accessToken}");

            request.AddParameter("date", date, ParameterType.GetOrPost);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<FixturesResponseModel>(response.Content);
            }

            return null;
        }
    }
}
