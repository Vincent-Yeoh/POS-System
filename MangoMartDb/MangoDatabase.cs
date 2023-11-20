using RestSharp.Authenticators;
using RestSharp;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using MangoMartDb.Models;
using Azure.Core.Pipeline;
using Microsoft.EntityFrameworkCore;
using MangoMartDb.DTOs;
using System.Net.NetworkInformation;

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

        public async Task<List<ProductDTO>> GetData()
        {
            var request = new RestRequest(_url);

            var response = await _client.GetAsync(request);
            var totalObject = response.Headers;


            var dbObject = JsonConvert.DeserializeObject<List<ProductDTO>>(response.Content!);
            return dbObject;

        }
        public async Task EnsureCreated()
        {
            using (var context = new MangoDbContext())
            {
                context.Database.Migrate();
            }

            if (!NetworkInterface.GetIsNetworkAvailable()) return;
            try
            {
                List<ProductDTO> products = await GetData();
                await RetrieveData(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<byte[]?> DownloadImageAsync(string imageUrl)
        {
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync(imageUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    // Handle error (e.g., return null or throw an exception)
                    return null;
                }
            }
        }

        public async Task RetrieveData(List<ProductDTO> productDTOs)
        {

            using(var context = new MangoDbContext())
            {
                foreach(var productDTO in productDTOs)
                {
                    if (context.Products.Any(x => x.Id == productDTO.Id)) continue;
                    Product product = await Product.MapDTO(productDTO);
                    context.Products.Add(product);
                }
                context.SaveChanges();
            }
        }

        public List<Product> B()
        {
            using (var context = new MangoDbContext())
            {
                return context.Products.ToList();
           
            }
        }

    }
}
