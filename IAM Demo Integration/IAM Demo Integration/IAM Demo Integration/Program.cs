namespace IAM_Demo_Integration
{
    internal class Program
    {
        private static string cleanLastName;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the IAM provisioning system!");

            var bigBoss = new HrUser
            {
                Fname = "William",
                Lname = "Gross",
                EmployeeId = 1111,
                JobTitle = "Big Boss",
                PrivateEmail = "william@gross.nu",
                WorkPhone = "076-123 45 67",
                Department = "IT",
                City = "STO",
                Manager = null,
                IsActive = true,
                DateofEmployment = new DateOnly(2020, 03, 01)
            };

            var LittleBoss = new HrUser
            {
                Fname = "Peter",
                Lname = "Sagan",
                EmployeeId = 1112,
                JobTitle = "Little Boss",
                PrivateEmail = "peter@sagan.nu",
                WorkPhone = "076-234 56 78",
                Department = "IT",
                City = "GBG",
                Manager = bigBoss,
                IsActive = true,
                DateOfEmployment = new DateOnly(2020, 03, 15)
            };

            var HrUsers = new List<HrUser>
            {
                new HrUser
                {
                    Fname = "Sten Åke",
                    Lname = "åkerström",
                    EmployeeId = 1113,
                    JobTitle = "Kodknackare",
                    PrivateEmail = "stenake@gmail.com",
                    WorkPhone = "076-195 78 56",
                    Department = "IT",
                    City = "STO",
                    Manager = LittleBoss,
                    IsActive = true,
                    DateOfEmployment = new DateOnly(2020, 04, 01)
                },
                new HrUser
                {
                    Fname = "Lisa",
                    Lname = "Costello",
                    EmployeeId = 1114,
                    JobTitle = "moodmanager",
                    PrivateEmail = "lisa@costello.com",
                    WorkPhone = "076-045 72 18",
                    Department = "Facility",
                    City = "STO",
                    Manager = bigBoss,
                    IsActive = true,
                    DateOfEmployment = new DateOnly(2020, 03, 20)
                },
                new HrUser
                {
                    Fname = "Jan",
                    Lname = "Persson",
                    EmployeeId = 1115,
                    JobTitle = "HR manager",
                    PrivateEmail = "janne@yahoo.com",
                    WorkPhone = "076-934 54 91",
                    Department = "HR",
                    City = "GBG",
                    Manager = bigBoss,
                    IsActive = true,
                    DateOfEmployment = new DateOnly(2023, 08, 25)
                },
                new HrUser
                {
                    Fname = "Oliver",
                    Lname = "Spetz",
                    EmployeeId = 1116,
                    JobTitle = "Trainee",
                    PrivateEmail = "oliver1337@tiktok.com",
                    WorkPhone = "076-189 566 01",
                    Department = "IT",
                    City = "GBG",
                    Manager = LittleBoss,
                    IsActive = true,
                    DateOfEmployment = new DateOnly(2025, 03, 01)
                },
                new HrUser
                {
                    Fname = "Amy",
                    Lname = "Winhouse",
                    EmployeeId = 1117,
                    JobTitle = "Entertainer",
                    PrivateEmail = "amy@winehouse.com",
                    WorkPhone = "076-724 89 45",
                    Department = "facility",
                    City = "STO",
                    Manager = bigBoss,
                    IsActive = false,
                    DateOfEmployment = new DateOnly(2022, 04, 04)
                }
            };

            HrUsers.Add(bigBoss);
            HrUsers.Add(LittleBoss);

            var iamUsers = new List<IAMuser>();

            foreach (var HrUser in HrUsers)
            {
                DateOnly today = DateOnly.FromDateTime(DateTime.Now);

                if (!HrUser.IsActive || HrUser.DateOfEmployment > today)
                {
                    continue;
                }


                var iamUser = new IAMuser();

                var cleanFirstName = HrUser.Fname.Trim();
                var cleanLastName = HrUser.Lname.Trim();

                iamUser.FullName = cleanFirstName + " " + cleanLastName;

                iamUser.DisplayName = cleanLastName.ToUpper() + ", " + cleanFirstName + " (" + HrUser.JobTitle + ")";

                iamUser.ExternalId = HrUser.City.ToUpper() + "-" + HrUser.EmployeeId;

                if (HrUser.Department == "IT")
                {
                    iamUser.role = "Admin";

                }
                else
                {
                    iamUser.role = "User";
                }


                var email = cleanFirstName + "." + cleanLastName + "@itmood.se";

                iamUser.PersonalEmail = HrUser.PrivateEmail;

                var cleanEmail = email.ToLower().Replace(" ", "").Replace("å", "a").Replace("ä", "a").Replace("ö", "o");

                iamUser.Email = cleanEmail;

                var cleanMobile = "+46" + HrUser.WorkPhone.Substring(1).Replace("-", "").Replace(" ", "");
                iamUser.Mobile = cleanMobile;

                iamUser.departmentCode = HrUser.City.ToUpper() + "-" + HrUser.Department.ToUpper();

                iamUsers.Add(iamUser);

            }

            foreach (var iamUser in iamUsers)
            {
                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine($"Full Name: {iamUser.FullName}");
                Console.WriteLine($"Display Name: {iamUser.DisplayName}");
                Console.WriteLine($"External ID: {iamUser.ExternalId}");
                Console.WriteLine($"Role: {iamUser.role}");
                Console.WriteLine($"E-mail: {iamUser.Email}");
                Console.WriteLine($"Private e-mail: {iamUser.PersonalEmail}");
                Console.WriteLine($"Mobile: {iamUser.Mobile}");
                Console.WriteLine($"Department Code: {iamUser.departmentCode}");
            }
            Console.ReadKey();
        }
    }
}




     

