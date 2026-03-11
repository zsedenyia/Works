using CountryApiClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace CountryApiClient.Services
{
    public class CountryService
    {
        private readonly HttpClient _httpClient;

        private readonly string _baseUrl = "https://restcountries.com/v3.1";
        private readonly string _endpoint = "/name";

        public CountryService()
        {
            _httpClient = new HttpClient();
        }

        public void DisplayCountry(CountryModel country)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n----Data Fetched Successfully----\n");
            Console.ResetColor();

            Console.WriteLine($"Common Name: (ENG){country.Name.Common}");
            Console.WriteLine($"official Name: (ENG){country.Name.Official}");

            var native = country.Name.NativeName.Values.FirstOrDefault();
            if (native != null)
            {
                Console.WriteLine($"Common Name (Local): {native.Common}");
                Console.WriteLine($"official Name (Local): {native.Official}");
            }

            Console.WriteLine($"Capital: {string.Join(", ", country.Capital)}");
            Console.WriteLine($"Continent: {string.Join(", ", country.Continents)}");
            Console.WriteLine($"Languages: {string.Join(", ", country.Languages)}");
            Console.WriteLine($"Population: {country.Population:n0}");
        }
        public async Task getCountryinfoAsync(string countryName)
        {
            Console.Clear();
            Console.WriteLine("Calling API to fetch data about {countryName}");

            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}{_endpoint}/{countryName}");

                if (response.IsSuccessStatusCode)
                {
                    var countries = await response.Content.ReadFromJsonAsync<List<CountryModel>>();

                    if (countries != null && countries.Count > 0)
                    {
                        DisplayCountry(countries[0]);
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n{response.StatusCode}: Could not find the country{countryName}, please check spellin...");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nError: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nunexpected error: {ex.Message}");

            }
            finally {
            }

        }
    }
}