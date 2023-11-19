using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Controls;
using System.IO;
using System.Net;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace POS_System
{
    internal class Database
    {

        private readonly HttpClient _client;

        public Database()
        {
           
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.ExpectContinue = false;
            //_client.DefaultRequestHeaders.Add("Content-Type", "application/json");

        }
        public async Task<string> GetData(string uri)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();


        }
    }
    
}
