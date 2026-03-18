using System;
using System.Collections.Generic;
using System.Text;

namespace IAM_Demo_Integration
{
    public class HrUser
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int EmployeeId { get; set; }
        public string JobTitle { get; set; }
        public string PrivateEmail { get; set; }
        public string WorkPhone { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public HrUser Manager { get; set; }
        public bool IsActive { get; set; }
        public DateOnly DateofEmployment { get; set; }
        public DateOnly DateOfEmployment { get; internal set; }
    }
}
