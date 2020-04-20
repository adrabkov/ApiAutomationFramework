using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

            protected string GetResponce(IRestClient client, IRestRequest request, bool isThrowExc = true)
        {
            var response = client.Execute(request);
            var statusCode = response.StatusCode;
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            else
            {
                if (isThrowExc)
                {
                    throw new Exception("The response from the server returned with an error: " + statusCode);
                }
                else
                    return response.StatusCode.ToString();
            }
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

            protected static async Task<string> GetRequest(string req)
        {
            //string str = "";

            using (var vk = new HttpClient())
            {
                vk.BaseAddress = new Uri(req);
                vk.DefaultRequestHeaders.Add("Connection", "close");
                vk.DefaultRequestHeaders.Add("User-Agent", "RM");
                HttpResponseMessage response = await vk.GetAsync(req);
                response.EnsureSuccessStatusCode();
                var resp = response.Content.ReadAsStreamAsync().ToString();
                return resp;
            }

            //var Vk = new HttpClient();
            //Vk.BaseAddress = new Uri(req);
            //Vk.DefaultRequestHeaders.Add("Connection", "close");
            //Vk.DefaultRequestHeaders.Add("User-Agent", "RM");

            //HttpResponseMessage response = await Vk.GetAsync(req);
            //response.EnsureSuccessStatusCode();
            //return await response.Content.ReadAsStringAsync();

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(req);
            //request.UseDefaultCredentials = true;

            //request.PreAuthenticate = true;
            //request.Credentials = CredentialCache.DefaultCredentials;
            //request.Method = "GET";
            //request.Host = host;
            //request.UserAgent = "RM";
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.KeepAlive = false;


            //using (HttpWebResponse responsevk = (HttpWebResponse)request.GetResponse())
            //using (var stream = responsevk.GetResponseStream())
            //using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            //{
            //    str = streamReader.ReadToEnd();
            //}
            //return str;
        }

    }
}
