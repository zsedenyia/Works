namespace CountryApiClient
{
    internal class Program
    {         static async Task Main(string[] args)
        {
            var countryService = new Services.CountryService();


            while (true)
            {
                Console.Clear();
                Console.WriteLine("----Country Info Tool----");
                Console.Write("Enter a country name (or 'exit' to quit: )");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")

                {
                    break;
                }
                await countryService.getCountryinfoAsync(input);

                Console.Write("\nPress any key to continue...");
                Console.ReadKey();

            }
            Console.WriteLine("Exiting the Application. Goodbye!");
        }
    }

}