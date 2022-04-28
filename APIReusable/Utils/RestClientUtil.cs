using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Utils
{
    public class RestClientUtil
    {
        static RestClient _RestClient;
        
        public static RestClient RestClient
        {
            get
            {
                if (_RestClient == null)
                {
                    return new RestClient(
                        "https://localhost:3000/");
                }
                else
                {
                    return _RestClient;
                }
            }
        }

        public static RestClient RestClientWithAuthentication(string userName,string password)
        {
            RestClient.Authenticator = new HttpBasicAuthenticator(userName, password, Encoding.UTF8);
            return RestClient;
        }

        public static RestRequest CreateRequest(string resource,Method method,DataFormat format)
        { 
                return new RestRequest(resource, method,format);          
        }

        //Post
        public static T Post<T>(string resource, string payload,RestSharp.DataFormat dataFormat)
        {
            return JsonConvert.DeserializeObject<T>
                (
                     RestClient.Execute
                     (
                         CreateRequest
                         (resource, Method.POST, dataFormat)
                         .AddBody(payload)
                     )
                     .Content
                  );
        }

        //Post With Authenticator
        public static T Post<T>(string resource, string payload, RestSharp.DataFormat dataFormat,string userName,string password)
        {
            
            return JsonConvert.DeserializeObject<T>
                (               
                RestClientWithAuthentication(userName,password).Execute
                     (
                         CreateRequest
                         (resource, Method.POST, dataFormat)
                         .AddBody(payload)
                     )
                     .Content
                  );
        }

        //Delete
        public static bool Delete(string resource, RestSharp.DataFormat dataFormat,HttpStatusCode expectedStatusCode)
        {
            var response =
            RestClient.Execute
            (
                CreateRequest
                (resource, Method.DELETE, dataFormat)
            );
            return response.StatusCode.Equals(expectedStatusCode);
        }


    }
}
