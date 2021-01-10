using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MMTTechnicalTestConsoleApp
{
    class Program
    {
        private static readonly string ApiUrl = "https://localhost:44352";
        static HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            await Menu();
        }

        public static async Task Menu()
        {
            Console.WriteLine("Welcome to the MMT Shop. Please select one of the following options and press enter:\r\n\r\n" +
                "1) Show all featured products\r\n" +
                "2) Show all available product category names\r\n" +
                "3) Find products by category\r\n" +
                "4) Exit application"
                );

            int selection;
            bool correctChoice; ;
            correctChoice = int.TryParse(Console.ReadLine(), out selection);

            if (!correctChoice)
            {
                Console.WriteLine("\r\nSorry, I didn't recognise that. You must choose a number to continue");
                await Menu();
            }

            switch (selection)
            {
                case 1:
                    await ShowFeaturedProducts();
                    break;
                case 2:
                    await ShowAllCategoryNames();
                    break;
                case 3:
                    await FindProductsByCategory();
                    break;
                case 4:
                    Console.WriteLine("Thank you, goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\r\nSorry, I did not recognise that choice. Please choose one of the available options");
                    await Menu();
                    break;
            }
        }

        public static async Task ShowFeaturedProducts()
        {
            try
            {
                var response = await client.GetAsync(ApiUrl + "/Product/GetFeaturedProducts");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                Console.ReadLine();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Message = {0}", e.Message);
            }
            await Menu();
            ///Get request to Endpoint
        }

        public static async Task ShowAllCategoryNames()
        {
            try
            {
                var response = await client.GetAsync(ApiUrl + "/Category/GetAllCategoryNames");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                Console.ReadLine();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Message = {0}", e.Message);
            }
            await Menu();
        }

        public static async Task FindProductsByCategory()
        {
            Console.WriteLine("\r\n Please select a category between 1 and 5");
            int chosenCategory;
            var isANumber = int.TryParse(Console.ReadLine(), out chosenCategory);
            if (isANumber)
            {
                try
                {
                    var response = await client.GetAsync(ApiUrl + "/Product/GetProductsByCategory/" + chosenCategory);
                    Console.WriteLine("\r\n" + await response.Content.ReadAsStringAsync());
                    Console.ReadLine();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Message = {0}", e.Message);
                }
            }
            else
            {
                Console.WriteLine("Sorry, I didn't recognise that. You must choose a number between 1 and 5 to continue\r\n");
                await FindProductsByCategory();
            }
            await Menu();
        }
    }
}
