using System;
namespace employee_api.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Department { get; set; }

        public string DateOfBirth { get; set; }
    }
}
