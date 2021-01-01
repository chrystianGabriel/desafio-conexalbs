using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace PlaylistRecommender.Domain.Core
{
    public abstract class Provider<T> where T : Entity
    {
        private string _baseUrl { set; get; }

        private HttpClient _httpClient = new HttpClient();

        private Dictionary<String, String> _urlParams = new Dictionary<string, string>();

        protected Provider(string baseUrl)
        {
            if(String.IsNullOrEmpty(baseUrl))
                throw new ArgumentNullException("O provider deve conter um url base"); 

            this._baseUrl = baseUrl;
        }

        protected async Task<T> Get(string Route)
        {
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString($"{this._baseUrl}/{Route}", this._urlParams));
            string result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }

        protected void AddUrlParams(string key, string value){
            this._urlParams.Add(key, value);
        }
    }
}