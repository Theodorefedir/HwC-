using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public float Salary { get; set; }

        public Employee(string fullName, string position, string phone, string email, float salary)
        {
            FullName = fullName;
            Position = position;
            Phone = phone;
            Email = email;
            Salary = salary;
        }
        public override string ToString() {
            return $"full name: {FullName}, Position: {Position}, Phone: {Phone}, Email: {Email}, Salary {Salary}";
        }
    }
}
