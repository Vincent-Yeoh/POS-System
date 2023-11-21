using RestSharp.Authenticators;
using RestSharp;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using MangoMartDb.Models;
using Microsoft.EntityFrameworkCore;
using MangoMartDb.DTOs;
using System.Net.NetworkInformation;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using System.Linq;
using MangoMartDbService;

namespace MangoMartDb
{


    public class MangoDatabase
    {
        private string _username;
        private string _password;
        private string _url;
        private RestClient _client;
        private LocalDbContextFactory dbFactory;

        public MangoDatabase(string username, string password, string url, string connectionString)
        {
            _username = username;
            _password = password;
            _url = url;
            dbFactory = new LocalDbContextFactory(connectionString);
            var options = new RestClientOptions()
            {
                Authenticator = new HttpBasicAuthenticator(_username, password)
            };
            _client = new RestClient(options);
        }

        public async Task<List<ProductDTO>> GetData()
        {
  

            List<ProductDTO> products = new List<ProductDTO>();

            var request = new RestRequest(_url);
            var response = await _client.GetAsync(request);

            if (!response.IsSuccessful) return products;

            Int32.TryParse(response.Headers!.ToList().Find(x => x.Name == "X-WP-Total")!.Value!.ToString(), out int totalObject);
            if (!Int32.TryParse(response.Headers!.ToList().Find(x => x.Name == "X-WP-TotalPages")!.Value!.ToString(), out int totalPages)) return products;

            for(int i = 1; i <= totalPages; i++)
            {
                string page_url = $"{_url}?page={i}";
                var pageRequest = new RestRequest(page_url);
                var pageResponse = await _client.GetAsync(pageRequest);

                if (!pageResponse.IsSuccessful) continue;
                List<ProductDTO> product = JsonConvert.DeserializeObject<List<ProductDTO>>(pageResponse.Content!);
                products.AddRange(product);
            }
            return products;

        }
        public async Task EnsureCreated()
        {
            using (var context = dbFactory.CreateDbContext())
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

     

        public async Task RetrieveData(List<ProductDTO> productDTOs)
        {

            using(var context = dbFactory.CreateDbContext())
            {
                foreach(var productDTO in productDTOs)
                {
                    if (context.Products.Any(x => x.Id == productDTO.Id)) continue;
                    Product product = await Product.MapDTO(productDTO);
                    context.Products.Add(product);
                    context.SaveChanges();
                }

            }
        }

        public List<Product> B()
        {
            using (var context = dbFactory.CreateDbContext())
            {
                return context.Products.ToList();
           
            }
        }

    }
}
