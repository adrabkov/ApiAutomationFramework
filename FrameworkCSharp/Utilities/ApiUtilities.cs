using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace FrameworkCSharp.Utilities
{
    public class ApiUtilities
    {
            protected (IRestRequest, IRestClient) CreateRequest(string token, Method method, string apiMethod, string version = "5.103")
        {
            var client = new RestClient(CustomerData.ApiUrl + apiMethod);       
            RestRequest request = new RestRequest() { Method = method };
            request.AddParameter("access_token", token);
            request.AddParameter("v", version);
            return (request, client);
        }

            protected string GetResponce(IRestClient client, IRestRequest request)
        {
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseString = response.Content;
                return responseString;
            }
            return null;
        }

            protected T ResponseConverter<T>(IRestClient client, IRestRequest request)
        {
            var responseString = GetResponce(client, request);
            var result = responseString.Substring(12, responseString.Length - 13);
            T response = JsonConvert.DeserializeObject<T>(result);
            return response;
        }

            protected string ResponseConverter(IRestClient client, IRestRequest request, string returned_value)
        {
            var responseString = GetResponce(client, request);
            var result = responseString.Substring(13, responseString.Length - 15);
            Dictionary<string, string> Dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            return Dict[returned_value];
        }

            protected static string GetRequest(string host, string req)
        {
            string str = "";

            var Vk = new HttpClient();
            Vk.DefaultRequestHeaders.Add("Connection", "close");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(req);
            request.UseDefaultCredentials = true;
            request.PreAuthenticate = true;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "GET";
            request.Host = host;
            request.UserAgent = "RM";
            request.ContentType = "application/x-www-form-urlencoded";
            request.KeepAlive = false;

            using (HttpWebResponse responsevk = (HttpWebResponse)request.GetResponse())
            using (var stream = responsevk.GetResponseStream())
            using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            {
                str = streamReader.ReadToEnd();
            }
            return str;
        }

    }
}
