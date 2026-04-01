using IAM.Provisioning.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Security;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;





namespace IAM.Provisioning.Client.Services
{
    public class ProvisioningService
    {
        private readonly HttpClient _httpClient;
        private readonly ObjectMapper _objectMapper;
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public ProvisioningService(string baseUrl, string apiKey)
        {
            this._httpClient = new HttpClient();
            this._objectMapper = new ObjectMapper();
            this._baseUrl = baseUrl;
            this._apiKey = apiKey;
        }
        // --- G-NIVÅ METOD ---
        public async Task ProcessBasicAsync(string filePath)
        {
            Console.WriteLine("Mappar användare för G-provisionering");
            var users = LoadUsers(filePath);

            // (G): Mappa ALLA fält enligt specifikation. Saknas något va?
            var payload = users.Select(u => new {
                name = u.GetFormattedFullName(),
                email = u.GetFormattedEmail(),
                Id = u.Id,
                Department = u.Department,
                IsActive = u.IsActive,
            }).ToList();

            await SendBatchRequestAsync(payload, "basic");
        } 
        // --- VG-NIVÅ METOD ---
        public async Task ProcessAdvancedAsync(string filePath)
        {
            Console.WriteLine("Mappar användare för VG-provisionering");
            var users = LoadUsers(filePath);

            // FIX: Filter the list BEFORE mapping it to the anonymous payload
            // This removes anyone where IsActive is false.
            var activeUsers = users.Where(u => u.IsActive == true ).ToList();

            // (VG): Här ska det vara samma mappning som för G, men det saknas något mer...
            // Det behövs ju något för att endast mappa aktiva användar

            
            var payload = activeUsers.Select(u => new {
                filterInfo = "IsActive = true",  // <-- This is the new field that will be used for filtering on the API side
                name = u.GetFormattedFullName(),
                email = u.GetFormattedEmail(),
                Id = u.Id,
                Department = u.Department,
                IsActive = u.IsActive,


            }).ToList();

            // Now this log will show the correct count of active users
            Console.WriteLine($"Provisionerar {payload.Count} aktiva användare");

            await SendBatchRequestAsync(payload, "advanced");

        }

        private async Task SendBatchRequestAsync(object payload, string endpoint)
        {
            Console.WriteLine($"Försöker skicka mappade användare till API-endpoint {endpoint}...");
            try
            {
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

                if (endpoint == "advanced")
                    _httpClient.DefaultRequestHeaders.Add(name: "X-Integration-Level", value: "Advanced");
                Console.WriteLine("[VG] lägger till X-Integration-Level: Advanced");

                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/{endpoint}", payload);
                string responseString = await response.Content.ReadAsStringAsync();

                Console.WriteLine("\nSvar från API:");
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var json = JsonSerializer.Deserialize<JsonElement>(responseString);
                        string msg = json.TryGetProperty("message", out var m) ? m.GetString() : responseString;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode} - {msg}\n");
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode} - {responseString}\n");
                    }
                }
                else
                {
                    try
                    {
                        var json = JsonSerializer.Deserialize<JsonElement>(responseString);
                        string err = json.TryGetProperty("error", out var e) ? e.GetString() : responseString;

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode} - Error: {err}\n");
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode} - Error: {responseString}\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[CRITICAL] System Error: {ex.Message}\n");
            }

            Console.ResetColor();
        }

        private List<UserRecord> LoadUsers(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<UserRecord>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
