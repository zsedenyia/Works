using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IAM.Provisioning.Client.Models
{
    public class ProvisioningPayload
    {
        // G-krav: Läs kravspecen, finns alla fält som ska skickas till API:t med här?
        [JsonPropertyName("name")]
        private string name { get; set; }
        [JsonPropertyName("email")]
        private string email { get; set; }
        [JsonPropertyName("department")]
        private string department { get; set; }
        [JsonPropertyName("is_active")]
        private bool isActive { get; set; }

        public ProvisioningPayload(string name, string email, string department, bool isActive)
        {
            this.name = name;
            this.email = email;
            this.department = department;
            this.isActive = isActive;
        }
        public string getName() { return name; }
        public string getEmail() { return email; }
        public string getDepartment() { return department; }
        public bool getIsActive() { return isActive; }
    }
}