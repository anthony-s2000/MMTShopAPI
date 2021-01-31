using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoApp.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace DemoApp
{
    class Program
    {

        private static string DownloadContent(string downloadUrl)
        {
            // Does the webclient get with appropriate headers
            // Use HttpWebRequest as webclient doesnt expose timeout settings
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(downloadUrl);
            try
            {
                request.Headers.Add("Content-Type:application/json");
                request.Headers.Add("Accept:application/json");
                request.Timeout = 5000;
                request.ReadWriteTimeout = 5000;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (System.IO.Stream responseStream = response.GetResponseStream())
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("ERROR  : Failed to get content from API service");
                Console.WriteLine("DETAILS: " + ex.Message.ToString());
                Console.WriteLine("Press a key to continue.");
                Console.ReadKey();
                return "";
            }

        }

        private static void ListProducts(string urlProducts)
        {
            // Gets all products and displays
            string jsonContent;

            jsonContent = DownloadContent(urlProducts);
            if (jsonContent == "")
            {
                //Error in the download so exit to menu
                return;
            }

            Console.WriteLine();

            try
            {
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonContent);

                if (products.Count > 0)
                {
                    foreach (Product product in products)
                    {
                        Console.WriteLine(product.Name.PadRight(50, ' ') + "(" + product.Sku + ")\t\t£" + product.Price);
                        Console.WriteLine(product.Description);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No records found.");
                }
            }
            catch (JsonReaderException jre)
            {
                Console.WriteLine("ERROR  : Failed to parse the JSON returned from the API service.");
                Console.WriteLine("DETAILS: " + jre.Message.ToString());
            }

            Console.WriteLine("Press a key to continue.");
            Console.ReadKey();
        }



        private static void ListCategories(string urlCategories)
        {
            // Get all categories and displays
            string jsonContent;

            jsonContent = DownloadContent(urlCategories);
            if (jsonContent == "")
            {
                //Error in the download so exit to menu
                return;
            }

            //Console.WriteLine(Environment.NewLine + jsonContent);
            Console.WriteLine();
            
            try 
            {
                List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(jsonContent);
                if (categories.Count > 0)
                {
                    foreach (Category category in categories)
                    {
                        Console.WriteLine(category.Name + "(" + category.ID + ")");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No records found.");
                }
            }
            catch (JsonReaderException jre)
            {
                Console.WriteLine("ERROR  : Failed to parse the JSON returned from the API service.");
                Console.WriteLine("DETAILS: " + jre.Message.ToString());
            }
            Console.WriteLine("Press a key to continue.");
            Console.ReadKey();
        }


        static void Main(string[] args)
        {
            ConsoleKeyInfo menuOption;

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", true, true)
                .Build();

            do
            {
                Console.Clear();
                Console.WriteLine("1. List All Products");
                Console.WriteLine("2. List Featured Products");
                Console.WriteLine("3. List Categories");
                Console.WriteLine("X. Quit");
                menuOption = Console.ReadKey();
                Console.WriteLine();
                switch (menuOption.KeyChar.ToString().ToUpper())
                {
                    case "1":
                        Console.WriteLine("List All Products");
                        ListProducts(config["AllProductsUrl"]);
                        break;
                    case "2":
                        Console.WriteLine("List Featured Products");
                        ListProducts(config["FeaturedProductsUrl"]);
                        break;
                    case "3":
                        Console.WriteLine("List Categories");
                        ListCategories(config["CategoriesUrl"]);
                        break;
                    case "X":
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        Task.Delay(1000).Wait();
                        break;
                }
            } while(menuOption.KeyChar.ToString().ToUpper() != "X");
        }
    }
}
