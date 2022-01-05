using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqresDemo.Utilities
{
    public class APIHelper<T>
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public string baseUrl = "https://reqres.in/";

        public RestClient SetUrl(string theEndPoint)
        {
            var url = Path.Combine(baseUrl, theEndPoint);
            var restClient = new RestClient(url);
            return restClient;
        }

        public RestRequest CreateGetRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public RestRequest CreatePostRequest(string payLoad)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payLoad, ParameterType.RequestBody);
            return restRequest;
        }

        public IRestResponse GetResponse(IRestClient Client, IRestRequest request)
        {
            return Client.Execute(request);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(content);
            return dtoObject;
        }



    }
}
