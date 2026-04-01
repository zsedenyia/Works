using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAM.Provisioning.Client.Models
{
    public class UserRecord
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; } = true;

        public UserRecord() { }
        public String GetId(){ return Id; }
        public void SetId(String id){ this.Id = id; }
        public string GetFirstName(){ return FirstName; }
        public void SetFirstName(string firstName){ this.FirstName = firstName; }
        public string GetLastName(){ return LastName; }
        public void SetLastName(string lastName){ this.LastName = lastName; }
        public string GetDepartment(){ return Department; }
        public void SetDepartment(string department){ this.Department = department; }
        public bool GetIsActive(){ return IsActive; }
        public void SetIsActive(bool isActive){ this.IsActive = isActive; }

        

        // Metod som ska kombinera firstname + lastname till en och samma sträng, t.ex. "Kalle Anka"
        public string GetFormattedFullName()
        {
            var formattedName = FirstName + " " + LastName;
            return formattedName;
        }

        // G-KRAV: Denna metod måste du uppdatera så den kombinerar firstname + lastname till en e-postaddress, t.ex. "kalle.anka@tssab.com" 
        public string GetFormattedEmail()
        {
            var email = FirstName + "." + LastName + "@tssab.com".ToLower().Trim().Replace(" ", "").Replace("å", "a").Replace("ä", "a").Replace("ö", "o");
            return email;
        }
    }
}
 