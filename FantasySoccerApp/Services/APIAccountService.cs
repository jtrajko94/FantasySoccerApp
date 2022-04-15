using System;
using System.Net;
using FantasySoccerApp.Models.API;
using FantasySoccerApp.Models.API.Accounts;
using FantasySoccerApp.Utilities;
using Newtonsoft.Json;
using RestSharp;

namespace FantasySoccerApp.Services
{
    public class APIAccountService
    {
        public TokenModel Register(UserModel user)
        {
            var model = new TokenModel();
            var client = new RestClient($"{Settings.APIRootUrl}/api/accounts/register/");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", JsonConvert.SerializeObject(user), ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                model = JsonConvert.DeserializeObject<TokenModel>(response.Content);
                return model;
            }else if(((int)response.StatusCode).Equals(422))
            {
                model.validation = JsonConvert.DeserializeObject<ValidationResponse>(response.Content);
                return model;
            }

            return null;
        }

        public TokenModel Login(UserModel user)
        {
            var model = new TokenModel();
            var client = new RestClient($"{Settings.APIRootUrl}/api/accounts/login/");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", JsonConvert.SerializeObject(user), ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                model = JsonConvert.DeserializeObject<TokenModel>(response.Content);
                return model;
            }
            else if (((int)response.StatusCode).Equals(422))
            {
                model.validation = JsonConvert.DeserializeObject<ValidationResponse>(response.Content);
                return model;
            }

            return null;
        }
    }
}
