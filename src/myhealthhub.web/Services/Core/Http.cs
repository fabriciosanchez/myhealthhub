using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using myhealthhub.web.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using myhealthhub.web.Models.Auth;

namespace myhealthhub.web.Services.Core
{ 
    public class Http
    {
        private IConfiguration _config;

        private string baseUri;
        
        private string tokenResource;
        
        private string grantType;
        
        private string clientId;
        
        private string clientSecret;
        
        private string resource;

        private string logicAppEndpoint;

        public Http(IConfiguration config)
        {
            _config = config;

            baseUri = _config.GetSection("MyHealthHubApi").GetSection("BaseUrl").Value;
            tokenResource = _config.GetSection("AccessToken").GetSection("TokenResource").Value;
            grantType = _config.GetSection("AccessToken").GetSection("GrantType").Value;
            clientId = _config.GetSection("AzureAd").GetSection("ClientId").Value;
            clientSecret = _config.GetSection("AzureAd").GetSection("ClientSecret").Value;
            resource = _config.GetSection("AccessToken").GetSection("Resource").Value;
        }

        private async Task<string> GetAuthToken()
        {
            try
            {
                var clientToken = new RestClient(tokenResource);
                var requestToken = new RestRequest(Method.POST);
                requestToken.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                requestToken.AddParameter("grant_type", grantType, ParameterType.GetOrPost);
                requestToken.AddParameter("client_id", clientId, ParameterType.GetOrPost);
                requestToken.AddParameter("client_secret", clientSecret, ParameterType.GetOrPost);
                requestToken.AddParameter("resource", resource, ParameterType.GetOrPost);
                var responseToken = await clientToken.ExecuteAsync<AADAccessToken>(requestToken, Method.POST);
                var tokenReturned = responseToken.Data.AccessToken;
                return tokenReturned;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public async Task<T> Get<T>(string resource)
        {
            try
            {
                string bearerToken = await GetAuthToken();
                
                var client = new RestClient(baseUri);
                var request = new RestRequest(resource, Method.GET, DataFormat.Json);
                request.AddHeader("Authorization", $"Bearer {bearerToken}");
                var response = await client.ExecuteAsync<T>(request, Method.GET);

                if(!response.IsSuccessful)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                }

                return response.Data;
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        public async Task<T> GetById<T>(string resource, string id)
        {
            try
            {
                string bearerToken = await GetAuthToken();
                
                var client = new RestClient(baseUri);
                var request = new RestRequest(resource + "/byid/" + id, Method.GET, DataFormat.Json);
                request.AddHeader("Authorization", $"Bearer {bearerToken}");
                var response = await client.ExecuteAsync<T>(request, Method.GET);

                if(!response.IsSuccessful)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                }

                return response.Data;
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        public async Task<T> GetByStudyId<T>(string resource, string id)
        {
            try
            {
                string bearerToken = await GetAuthToken();
                
                var client = new RestClient(baseUri);
                var request = new RestRequest(resource + "/bystudyid/" + id, Method.GET, DataFormat.Json);
                request.AddHeader("Authorization", $"Bearer {bearerToken}");
                var response = await client.ExecuteAsync<T>(request, Method.GET);

                if(!response.IsSuccessful)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                }

                return response.Data;
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        public async Task<T> GetByEmail<T>(string resource, string email)
        {
            try
            {
                string bearerToken = await GetAuthToken();
                
                var client = new RestClient(baseUri);
                var request = new RestRequest(resource + "/byemail/" + email, Method.GET, DataFormat.Json);
                request.AddHeader("Authorization", $"Bearer {bearerToken}");
                var response = await client.ExecuteAsync<T>(request, Method.GET);

                if(!response.IsSuccessful)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                }

                return response.Data;
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        public async Task<T> GetByInternalId<T>(string resource, string id)
        {
            try
            {
                string bearerToken = await GetAuthToken();
                
                var client = new RestClient(baseUri);
                var request = new RestRequest(resource + "/byinternalid/" + id, Method.GET, DataFormat.Json);
                request.AddHeader("Authorization", $"Bearer {bearerToken}");
                var response = await client.ExecuteAsync<T>(request, Method.GET);

                if(!response.IsSuccessful)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                }

                return response.Data;
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        public async Task<T> Post<T>(string resource, object payload = null)
        {
            try
            {
                string bearerToken = await GetAuthToken();
                
                var client = new RestClient(baseUri);
                var request = new RestRequest(resource, Method.POST, DataFormat.Json);
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Authorization", $"Bearer {bearerToken}");
                
                if(payload != null)
                {
                    request.AddJsonBody(payload);
                }

                var response = await client.ExecuteAsync<T>(request, Method.POST);

                if(!response.IsSuccessful)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                }
                
                return response.Data;
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        public async Task<T> PostExternal<T>(string endpoint, object payload = null)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest(endpoint, Method.POST, DataFormat.Json);
                request.RequestFormat = DataFormat.Json;
                
                if(payload != null)
                {
                    request.AddJsonBody(payload);
                }

                var response = await client.ExecuteAsync<T>(request, Method.POST);

                if(!response.IsSuccessful)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                }
                
                return response.Data;
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        public async Task<T> Put<T>(string resource, object payload = null)
        {
            try
            {
                string bearerToken = await GetAuthToken();
                
                var client = new RestClient(baseUri);
                var request = new RestRequest(resource, Method.PUT, DataFormat.Json);
                request.AddHeader("Authorization", $"Bearer {bearerToken}");
                request.AddHeader("Content-type", "application/json; charset=utf-8");
                
                if(payload != null)
                {
                    request.AddJsonBody(payload);
                }

                var response = await client.ExecuteAsync<T>(request, Method.PUT);

                if(!response.IsSuccessful)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                }
                
                return response.Data;
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        public async Task<T> Delete<T>(string resource, string id)
        {
            try
            {
                string bearerToken = await GetAuthToken();
                
                var client = new RestClient(baseUri);
                var request = new RestRequest($"{resource}/{id}", Method.DELETE, DataFormat.Json);
                request.AddHeader("Authorization", $"Bearer {bearerToken}");
                var response = await client.ExecuteAsync<T>(request, Method.DELETE);

                if(!response.IsSuccessful)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                }
                
                return response.Data;
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }
        
    }
}