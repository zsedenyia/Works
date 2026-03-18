using System;
using System.Collections.Generic;
using System.Text;

namespace IAM_Demo_Integration
{
    public class IAMuser
    {
        public string FullName { get; set; }
        public string DisplayName { get; set; } 
        public string ExternalId { get; set; }
        public string role { get; set; }
        public string Email { get; set; }
        public string PersonalEmail { get; set; }
        public string Mobile { get; set; }
        public string departmentCode { get; set; }
        public IAMuser Manager {  get; set; }
    }
}