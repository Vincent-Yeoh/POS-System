// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using System.Net.Http;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading;
using System.Configuration;
using MangoMartDbService.Services;

string username = "ck_2682b35c4d9a8b6b6effac126ac552e0bfb315a0";
string password = "cs_cab8c9a729dfb49c50ce801a9ea41b577c00ad71";
string uri = "https://mangomart-autocount.myboostorder.com/wp-json/wc/v1/products";

DatabaseService mangoDb = new DatabaseService(username, password, uri, ConfigurationManager.
    ConnectionStrings["conn"].ConnectionString);


var i = await mangoDb.Get(1);

Console.ReadLine();
