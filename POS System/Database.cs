using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Controls;
using System.IO;
using System.Net;

namespace POS_System
{
    internal class Database
    {
        public void GetData()
        {
            CallSimple();
        }
        private void CallSimple()
        {
            var url = "https://mangomart-autocount.myboostorder.com/wp-json/wc/v1/products";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Headers["Authorization"] = "Basic Y2tfMjY4MmIzNWM0ZDlhOGI2YjZlZmZhYzEyNmFjNTUyZTBiZmIzMTVhMDpjc19jYWI4YzlhNzI5ZGZiNDljNTBjZTgwMWE5ZWE0MWI1NzdjMDBhZDcx";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

            Console.WriteLine(httpResponse.StatusCode);


        }
        private void CallApiAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var url = "https://mangomart-autocount.myboostorder.com/wp-json/wc/v1/products";


                    //string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("ck_2682b35c4d9a8b6b6effac126ac552e0bfb315a0:cs_cab8c9a729dfb49c50ce801a9ea41b577c00ad71"));


                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

                    var response = client.GetAsync(url).Result;
                    response.EnsureSuccessStatusCode();
           
                    var result =  response.Content.ReadAsStringAsync().Result;
                    if (int.TryParse(response.Headers.GetValues("X-WP-TotalPages").First(), out int totalPages))
                    {
                        Console.WriteLine(totalPages);
                        // Continue to next page
                    }
                    else
                    {
                        // Handle error getting total pages
                        Console.WriteLine("Error getting total pages");
                    }

                    //    // Example of calling the API with pagination
                    //    int totalPages = 0;
                    //    for (int page = 1; page <= totalPages + 1; page++)
                    //    {
                    //        // Append the page parameter to the URL
                    //        string urlWithPage = $"{apiUrl}?page={page}";

                    //        // Send GET request
                    //        HttpResponseMessage response = await client.GetAsync(urlWithPage);

                    //        // Check if the request was successful
                    //        if (response.IsSuccessStatusCode)
                    //        {
                    //            // Read and parse the response content
                    //            string data = await response.Content.ReadAsStringAsync();

                    //            // Process the data as needed
                    //            Console.WriteLine(data);

                    //            // Get total pages from response header

                    //        }
                    //        else
                    //        {
                    //            // Handle unsuccessful response
                    //            Console.WriteLine($"Error: {response.StatusCode}");
                    //            break;
                    //        }
                    //    }
                    //}

                }
            }
            catch
            {

            }
        }
    }
}
