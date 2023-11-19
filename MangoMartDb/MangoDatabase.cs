using RestSharp.Authenticators;
using RestSharp;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MangoMartDb
{

  
    public class MangoDatabase
    {
        private string _username;
        private string _password;
        private string _url;
        private RestClient _client;

        public MangoDatabase(string username, string password, string url)
        {
            _username = username;
            _password = password;
            _url = url;
            var options = new RestClientOptions()
            {
                Authenticator = new HttpBasicAuthenticator(_username, password)
            };
            _client = new RestClient(options);
        }

        public async Task<List<Product>> GetData()
        {
            var request = new RestRequest(_url);

            var response = await _client.GetAsync(request);
            var totalObject = response.Headers;


            var dbObject = JsonConvert.DeserializeObject<List<Product>>(response.Content!);
            return dbObject;

        }

    }
}
