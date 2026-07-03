namespace LINQ
{
    internal class Program
    {
        static void PrintResult(IEnumerable<Firm> firms) {
            foreach (Firm f in firms) {
                Console.WriteLine(f);
            }
        }

        static void PrintEmployee(IEnumerable<Employee> em)
        {
            foreach (var e in em)
            {
                Console.WriteLine(e);
            }
        }
        static void PrintPhone(IEnumerable<Phone> phone)
        {
            foreach (var el in phone)
            {
                Console.WriteLine(el);
            }
        }
        static void Main(string[] args)
        {
            //task 1
            #region
            // масив для зручності створив чат
            Firm[] firms = new Firm[]
            {
                new Firm("FoodMarket London", new DateTime(2020, 5, 15), BusinessProfile.Food,
                    "John White", 150, "London"),

                new Firm("IT Solutions Corp", new DateTime(2022, 8, 20), BusinessProfile.IT,
                    "Anna Black", 45, "New York"),

                new Firm("Global Marketing Agency", new DateTime(2019, 3, 10), BusinessProfile.Marketing,
                    "Peter Brown", 120, "London"),

                new Firm("FreshFood Delivery", new DateTime(2023, 11, 1), BusinessProfile.Food,
                    "Emma White", 80, "Paris"),

                new Firm("Digital Marketing Hub", new DateTime(2021, 7, 22), BusinessProfile.Marketing,
                    "Robert Black", 200, "London"),

                new Firm("Tech Innovation Lab", new DateTime(2024, 1, 15), BusinessProfile.IT,
                    "Michael Green", 300, "Berlin"),

                new Firm("White Finance Group", new DateTime(2022, 12, 5), BusinessProfile.Finance,
                    "Sarah White", 35, "Manchester"),

                new Firm("WhiteTech Solutions", new DateTime(2023, 6, 10), BusinessProfile.IT,
                    "David Black", 180, "Birmingham"),

                new Firm("London Marketing Pros", new DateTime(2018, 9, 1), BusinessProfile.Marketing,
                    "James White", 100, "London"),

                new Firm("FoodExpress London", new DateTime(2021, 4, 12), BusinessProfile.Food,
                    "Richard Black", 250, "London"),

                new Firm("Tokyo Digital IT", new DateTime(2023, 2, 28), BusinessProfile.IT,
                    "Hiro Tanaka", 50, "Tokyo"),

                new Firm("HealthyFood Australia", new DateTime(2024, 5, 20), BusinessProfile.Food,
                    "Olivia White", 75, "Sydney"),

                new Firm("Brand Marketing Ltd", new DateTime(2022, 10, 14), BusinessProfile.Marketing,
                    "Sophia Black", 90, "London"),

                new Firm("White Data Systems", new DateTime(2017, 11, 5), BusinessProfile.IT,
                    "Thomas White", 500, "London"),

                new Firm("PizzaFood Italy", new DateTime(2024, 7, 30), BusinessProfile.Food,
                    "Marco Rossi", 30, "Rome"),

                new Firm("WhiteFood Company", new DateTime(2023, 3, 5), BusinessProfile.Food,
                    "Charles Black", 60, "Liverpool"),

                new Firm("Special 123 Days Firm", DateTime.Now.AddDays(-123), BusinessProfile.Other,
                    "Test Director", 10, "Test City")
            };

            var all = firms;
            var food = firms.Where(f => f.Name.Contains("Food"));
            var marketing = firms.Where(f => f.Profile == BusinessProfile.Marketing);
            var marketingIT = firms.Where(f => f.Profile == BusinessProfile.Marketing || f.Profile == BusinessProfile.IT);
            var big = firms.Where(f => f.EmployeeCount > 100);
            var big1 = firms.Where(f => f.EmployeeCount >= 100 && f.EmployeeCount <= 300);
            var london = firms.Where(f => f.Address == "London");
            var white = firms.Where(f => f.DirectorFullName.Contains("White"));
            var old = firms.Where(f => (DateTime.Now - f.Date).TotalDays > 365 * 2);
            var days123 = firms.Where(f => (DateTime.Now - f.Date).Days == 123);
            var blackAndWhite = firms.Where(f => f.DirectorFullName.Contains("Black") && f.Name.Contains("White"));

            //PrintResult(all);
            //PrintResult(food);
            //PrintResult(marketing);
            //PrintResult(marketingIT);
            //PrintResult(big);
            //PrintResult(big1);
            //PrintResult(london);
            //PrintResult(white);
            //PrintResult(old);
            //PrintResult(days123);
            //PrintResult(blackAndWhite);

            #endregion

            //task 2
            #region 
            // масиви створював чат
            // 1. FoodMarket London
            Employee[] employees1 = new Employee[]
            {
                new Employee("John White", "Director", "+44123456789", "john.white@foodmarket.com", 75000),
                new Employee("Anna Smith", "Manager", "+44123456790", "anna.smith@foodmarket.com", 45000),
                new Employee("Mike Johnson", "Chef", "+44123456791", "mike.johnson@foodmarket.com", 32000),
                new Employee("Lionel Messi", "Manager", "+44123456792", "lionel.messi@foodmarket.com", 48000),
                new Employee("Emily Davis", "Cashier", "+44123456793", "emily.davis@foodmarket.com", 25000)
            };

            // 2. IT Solutions Corp
            Employee[] employees2 = new Employee[]
            {
                new Employee("Anna Black", "Director", "+44234567890", "anna.black@itsolutions.com", 80000),
                new Employee("David Brown", "Developer", "+44234567891", "david.brown@itsolutions.com", 55000),
                new Employee("Lionel Richie", "Manager", "+44234567892", "lionel.richie@itsolutions.com", 50000),
                new Employee("Sophia White", "Tester", "+44234567893", "sophia.white@itsolutions.com", 35000),
                new Employee("James Green", "DevOps", "+44234567894", "james.green@itsolutions.com", 42000)
            };

            // 3. Global Marketing Agency
            Employee[] employees3 = new Employee[]
            {
                new Employee("Peter Brown", "Director", "+44345678901", "peter.brown@globalmarketing.com", 72000),
                new Employee("Olivia Taylor", "Manager", "+44345678902", "olivia.taylor@globalmarketing.com", 43000),
                new Employee("Lionel Johnson", "Analyst", "+44345678903", "lionel.johnson@globalmarketing.com", 38000),
                new Employee("Diana Prince", "Designer", "+44345678904", "diana.prince@globalmarketing.com", 34000),
                new Employee("Bruce Wayne", "Manager", "+44345678905", "bruce.wayne@globalmarketing.com", 46000)
            };

            // 4. FreshFood Delivery
            Employee[] employees4 = new Employee[]
            {
                new Employee("Emma White", "Director", "+44456789012", "emma.white@freshfood.com", 68000),
                new Employee("Chris Evans", "Manager", "+44456789013", "chris.evans@freshfood.com", 41000),
                new Employee("Lionel Clark", "Driver", "+44456789014", "lionel.clark@freshfood.com", 28000),
                new Employee("Natalie Portman", "Cook", "+44456789015", "natalie.portman@freshfood.com", 30000)
            };

            // 5. Digital Marketing Hub
            Employee[] employees5 = new Employee[]
            {
                new Employee("Robert Black", "Director", "+44567890123", "robert.black@digitalhub.com", 78000),
                new Employee("Scarlett Johansson", "Manager", "+44567890124", "scarlett.j@digitalhub.com", 44000),
                new Employee("Lionel Hunt", "SEO Specialist", "+44567890125", "lionel.hunt@digitalhub.com", 36000),
                new Employee("Tom Hanks", "Content Manager", "+44567890126", "tom.hanks@digitalhub.com", 39000)
            };

            // 6. Tech Innovation Lab
            Employee[] employees6 = new Employee[]
            {
                new Employee("Michael Green", "Director", "+44678901234", "michael.green@techlab.com", 85000),
                new Employee("Diana Ross", "Manager", "+44678901235", "diana.ross@techlab.com", 47000),
                new Employee("Lionel Torres", "Researcher", "+44678901236", "lionel.torres@techlab.com", 52000)
            };

            // ============================================================
            // МАССИВ ФИРМ (передаем массивы сотрудников)
            // ============================================================

            Firm[] firms2 = new Firm[]
            {
                new Firm("FoodMarket London", new DateTime(2020, 5, 15), BusinessProfile.Food,
                    "John White", 5, "London", employees1),

                new Firm("IT Solutions Corp", new DateTime(2022, 8, 20), BusinessProfile.IT,
                    "Anna Black", 5, "New York", employees2),

                new Firm("Global Marketing Agency", new DateTime(2019, 3, 10), BusinessProfile.Marketing,
                    "Peter Brown", 5, "London", employees3),

                new Firm("FreshFood Delivery", new DateTime(2023, 11, 1), BusinessProfile.Food,
                    "Emma White", 4, "Paris", employees4),

                new Firm("Digital Marketing Hub", new DateTime(2021, 7, 22), BusinessProfile.Marketing,
                    "Robert Black", 4, "London", employees5),

                new Firm("Tech Innovation Lab", new DateTime(2024, 1, 15), BusinessProfile.IT,
                    "Michael Green", 3, "Berlin", employees6)
            };

            var firmEmployee = firms2[0].Employees;
            var employeesWithSalary = firms2[0].Employees.Where(e => e.Salary > 8000);
            var Managers = firms2.SelectMany(f => f.Employees).Where(e => e.Position == "Managers");
            var phone23 = firms2.SelectMany(f => f.Employees).Where(e => e.Phone.StartsWith("23"));
            var emailDi = firms2.SelectMany(f => f.Employees).Where(e => e.Email.StartsWith("di"));
            var Lionel = firms2.SelectMany(f => f.Employees).Where(e => e.FullName.Contains("Lionel"));

            //PrintEmployee(Lionel);
            #endregion

            //task3
            #region
            Phone[] phones = new Phone[]
            {
                new Phone("iPhone 15 Pro", "Apple", 1200, new DateTime(2023, 9, 22)),
                new Phone("iPhone 15", "Apple", 900, new DateTime(2023, 9, 22)),
                new Phone("iPhone 14", "Apple", 700, new DateTime(2022, 9, 16)),
                new Phone("Galaxy S24 Ultra", "Samsung", 1300, new DateTime(2024, 1, 31)),
                new Phone("Galaxy S24", "Samsung", 850, new DateTime(2024, 1, 31)),
                new Phone("Galaxy S23", "Samsung", 650, new DateTime(2023, 2, 17)),
                new Phone("Pixel 8 Pro", "Google", 1000, new DateTime(2023, 10, 12)),
                new Phone("Pixel 8", "Google", 700, new DateTime(2023, 10, 12)),
                new Phone("Pixel 7", "Google", 500, new DateTime(2022, 10, 13)),
                new Phone("Xiaomi 14", "Xiaomi", 800, new DateTime(2024, 2, 25)),
                new Phone("Xiaomi 13", "Xiaomi", 600, new DateTime(2023, 2, 26)),
                new Phone("OnePlus 12", "OnePlus", 750, new DateTime(2024, 1, 23)),
                new Phone("OnePlus 11", "OnePlus", 550, new DateTime(2023, 2, 7)),
                new Phone("Motorola Edge 40", "Motorola", 450, new DateTime(2023, 5, 15)),
                new Phone("Motorola G84", "Motorola", 300, new DateTime(2023, 9, 1)),
                new Phone("Nokia G22", "Nokia", 150, new DateTime(2023, 2, 25)),
                new Phone("Nokia X30", "Nokia", 80, new DateTime(2022, 9, 1)),
            };

            var phoneCount = phones.Count();
            var Price100M = phones.Where(p => p.Price > 100);
            var Price400M700 = phones.Where(p => p.Price >= 400 && p.Price <= 700);
            var appleCount = phones.Count(p => p.Manufacturer == "Apple");
            //Console.WriteLine(appleCount);
            var minPricePhone = phones.OrderBy(p => p.Price).First();
            //Console.WriteLine(minPricePhone);
            var maxPrice = phones.Max(p => p.Price);
            //Console.WriteLine(maxPrice);
            var oldestDate = phones.Min(p => p.ReleaseDate);
            //Console.WriteLine(oldestDate);
            var newestDate = phones.Max(p => p.ReleaseDate);
            //Console.WriteLine(newestDate);
            var averagePrice = phones.Average(p => p.Price);
            Console.WriteLine(averagePrice);

            #endregion
        }
    }
}
