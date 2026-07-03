using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{

    public enum BusinessProfile
    {
        Marketing,
        IT,
        Finance,
        Food,
        Other
    }
    internal class Firm
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public BusinessProfile Profile { get; set; }
        public string DirectorFullName { get; set; }
        public int EmployeeCount { get; set; }
        public string Address { get; set; }

        public Employee[] Employees { get; set; }


        public Firm(string name, DateTime date, BusinessProfile profile, string directorFullName, int employeeCount, string address)
        {
            Name = name;
            Date = date;
            Profile = profile;
            DirectorFullName = directorFullName;
            EmployeeCount = employeeCount;
            Address = address;
            Employees = new Employee[0];
        }

        public Firm(string name, DateTime date, BusinessProfile profile, string directorFullName, int employeeCount, string address, Employee[] employees)
        {
            Name = name;
            Date = date;
            Profile = profile;
            DirectorFullName = directorFullName;
            EmployeeCount = employeeCount;
            Address = address;
            Employees = employees;
        }

        public override string ToString() { 
            return $"Name: {Name}, founding date: {Date}, profile of firm {Profile}, director full nam: {DirectorFullName}, Employee: {EmployeeCount}, Adress: {Address}";
        }

    }
}
