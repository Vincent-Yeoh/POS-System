using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MangoMartDb
{
    internal class Utility
    {
        public static async Task<string> DownloadImageAsFile(string uri, string saveDir)
        {
            using(var client = new HttpClient())
            {
                try
                {
                    saveDir = Path.Combine(Path.GetFullPath(saveDir));
                    if(!Directory.Exists(saveDir))
                    {
                        Directory.CreateDirectory(saveDir);
                        
                    }
                    byte[] imageBytes = await client.GetByteArrayAsync(new Uri(uri));
                    saveDir = Path.Combine(saveDir, $"{Guid.NewGuid()}.jpg");
                    File.WriteAllBytes(saveDir, imageBytes);
                    return saveDir; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return "";
        }
       
    }
}
