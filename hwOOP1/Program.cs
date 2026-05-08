namespace hwOOP1
{
    internal class Program
    {
        class Freezer {
            private string brand;
            private double temperature;
            private bool isFrost;
            private int shelvesCount;
            private string model;
            public string Brand
            {
                get { return brand; }
                set { brand = value; }
            }
            public double Temperature 
            { 
                get { return temperature; }
                set {
                    if (value < 10 && value > -10)
                    {
                        temperature = value;
                    }
                    else { 
                        temperature = 2.0;
                    }
                }
            }
            public bool IsFrost
            {
                get { return isFrost; }
                set { isFrost = value; }
            }
            public string Model
            {
                get { return model; }
                set { model = value; }
            }
            public int ShelvesCount
            {
                get { return shelvesCount; }
                set
                {
                    if (value > 0)
                    {
                        shelvesCount = value;
                    }
                    else {
                        shelvesCount = 3;
                    }
                }
            }
            public Freezer()
            {
                brand = "unknown";
                temperature = 3.5;
                isFrost = true;
                shelvesCount = 4;
                model = "unknown";
            }
            public Freezer(string brand, double temperature, bool isFrost, int shelvesCount, string model)
            {
                this.brand = brand;
                this.temperature = temperature;
                this.isFrost = isFrost;
                this.shelvesCount = shelvesCount;
                this.model = model;
            }
            public Freezer(string brand, string model) : this(brand, -2.0, true, 3, model)
            {
                Console.WriteLine($"Created Freezer {brand} {model} with common settings");
            }
            public override string ToString()
            {
                return ($"Freezer: {brand} {model} tempreture: {temperature}C " +
                       $"is frost available: {isFrost} with: {shelvesCount} shelves");
            }
        }

        static void Main(string[] args)
        {
            Freezer[] freezers = new Freezer[3];
            freezers[0] = new Freezer();
            freezers[1] = new Freezer("Samsung", -5.5, true, 5, "sdfdfsfs55567");
            freezers[2] = new Freezer("Bosch", "s df hsdf ds");
            for (int i = 0; i < freezers.Length; i++)
            {
                Console.WriteLine($"{i + 1} {freezers[i].ToString()}");
            }
            Console.WriteLine(freezers[0].Brand);
        }
    }
}
