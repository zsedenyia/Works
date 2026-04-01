using IAM.Provisioning.Client.Services;
using System;
using System.Threading.Tasks;

namespace IAM.Provisioning.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string apiKey = "Your-API-Key";
            string baseUrl = "Your-BaseURL";

            var service = new ProvisioningService(baseUrl, apiKey);

            Console.WriteLine("--- Startar IAM Provisioning System ---");

            try
            {
                //Här anropar vi G-metoden, denna raden måste justeras ut om du vill anropa VG-metoden.
                //await service.ProcessBasicAsync("F:\\School 25-26 - STI\\26-v11 Exam\\IAM.Provisioning.Client-main\\IAM.Provisioning.Client\\users.json");
                await service.ProcessAdvancedAsync("F:\\School 25-26 - STI\\26-v11 Exam\\IAM.Provisioning.Client-main\\IAM.Provisioning.Client\\users.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett oväntat fel uppstod: {ex.Message}");
            }

            Console.WriteLine("--- Körning klar ---");

            Console.Write("\nTryck på valfri knapp för att avsluta programmet...");
            Console.ReadKey();
        }
    }
}
