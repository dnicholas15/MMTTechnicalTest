using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MMTTechnicalTestConsoleApp
{
    class Program
    {
        private static string ApiUrl = "https://localhost:44352/";

        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("Welcome to the MMT Shop. Please select one of the following options and press enter:\r\n\r\n" +
                "1) Show all featured products\r\n" +
                "2) Show all available product category names\r\n" +
                "3) Find products by category"
                );

            int selection;
            bool correctChoice; ;
            correctChoice = int.TryParse(Console.ReadLine(), out selection);

            if (!correctChoice)
            {
                Console.WriteLine("\r\nSorry, I didn't recognise that. You must choose a number to continue");
                Menu();
            }

            switch (selection)
            {
                case 1:
                    Console.Clear();
                    ShowFeaturedProducts();
                    break;
                case 2:
                    Console.Clear();
                    ShowAllCategoryNames();
                    break;
                case 3:
                    Console.Clear();
                    FindProductsByCategory();
                    break;
                default:
                    Console.WriteLine("\r\nSorry, I did not recognise that choice. Please choose one of the available options");
                    Menu();
                    break;
            }
        }

        public static void ShowFeaturedProducts()
        {

            ///Get request to Endpoint
        }

        public static void ShowAllCategoryNames()
        {
            ///Get request to Endpoint
        }

        public static void FindProductsByCategory()
        {
            ///varible to store category names
        }
    }
}
