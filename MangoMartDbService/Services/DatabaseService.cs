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

namespace MangoMartDbService.Services
{


    public class DatabaseService : IDatabaseService
    {
        private string _username;
        private string _password;
        private string _url;
        private RestClient _client;
        private LocalDbContextFactory dbFactory;

        public DatabaseService(string username, string password, string url, string connectionString)
        {
            _username = username;
            _password = password;
            _url = url;

            //Ensure that the database file is created/up to date
            dbFactory = new LocalDbContextFactory(connectionString);
            using (var context = dbFactory.CreateDbContext())
            {
                context.Database.Migrate();
            }

            var options = new RestClientOptions()
            {
                Authenticator = new HttpBasicAuthenticator(_username, password)
            };
            _client = new RestClient(options);

        }

        public async Task<List<Product>> Get(int page)
        {
            try
            {
                
                string pageUrl = $"{_url}?page={page}";
                List<ProductDTO> productDTOs = await RetrieveProductData(pageUrl);
                List<Product> products = await CacheData(productDTOs, page);
               
            }
            catch (Exception ex)
            {
                //If response fail, fall back on local db 
                Console.WriteLine(ex);
                
            }
            return GetLocal(page);

        }

        private List<Product> GetLocal(int Page)
        {
            using(var context = dbFactory.CreateDbContext())
            {
                return context.Products.Where(x=> x.PageNumber == Page).ToList();
            }
        }

        private async Task<List<Product>> CacheData(List<ProductDTO> productDTOs, int page)
        {
            List<Product> products = new List<Product>();
            using (var context = dbFactory.CreateDbContext())
            {
                foreach (var productDTO in productDTOs)
                {
                    if (context.Products.Any(x => x.Id == productDTO.Id)) continue;
                    Product product = await Product.MapDTO(productDTO);
                    product.PageNumber = page;
                    context.Products!.Add(product);
                    context.SaveChanges();
                }
            }
            return products;
        }


        private async Task<RestResponseBase?> RetrieveData(string url)
        {
            var request = new RestRequest(url);
            var response = await _client.GetAsync(request);

            if (!response.IsSuccessful) throw new ArgumentNullException(nameof(response));
            return response;
        }

        private async Task<List<ProductDTO>> RetrieveProductData(string url) {
            List<ProductDTO> products = new List<ProductDTO>();
            var response = await RetrieveData(url);
            List<ProductDTO>? product = JsonConvert.DeserializeObject<List<ProductDTO>>(response!.Content!);
            if (product is null) throw new ArgumentNullException(nameof(product));
            return product;
        }
   
        public async Task<int> GetPageTotal()
        {
            var response = await RetrieveData(_url);
            
            if (!int.TryParse(response!.Headers!.ToList().Find(x => x.Name == "X-WP-TotalPages")!.Value!.ToString(), out int totalPages)) throw new ArgumentNullException(nameof(totalPages));
          
            return totalPages;
           
        }
    }
}
