namespace hwOOP2
{
    internal class Program
    {
        class Calculator
        {
            public double Add(double a, double b) {  return a + b; }
            public double Sub(double a, double b) {  return a - b; }
            public double Mul(double a, double b) { 
                return a * b;
            }

            public double Div(double a, double b)
            {
                if (b == 0)
                    throw new Exception("Dividing by zero is impossible");
                return a / b;
            }
        }
        static int Choice()
        {
            int num = 0;
            bool valid = true;
            while (valid)
            {
                Console.WriteLine("Your choice: ");
                string choice = Console.ReadLine();
                if (int.TryParse(choice, out num))
                {
                    Console.WriteLine("Ok\n");
                    valid = false;
                }
                else
                {
                    Console.WriteLine("Error, not a number\n");
                }
            }
            return num;
        }
        static double ChoiceForD()
        {
            double num = 0;
            bool valid = true;
            while (valid)
            {
                Console.WriteLine("Enter number: ");
                string choice = Console.ReadLine();
                if (double.TryParse(choice, out num))
                {
                    Console.WriteLine("Ok\n");
                    valid = false;
                }
                else
                {
                    Console.WriteLine("Error, not a number\n");
                }
            }
            return num;
        }
        static int ChoiceRange(int min, int max)
        {
            while (true)
            {
                int num = Choice();
                if (num >= min && num <= max)
                    return num;
                Console.WriteLine($"Enter number from {min} to {max}");
            }
        }
        static void ShowMenu() {
            Console.WriteLine(@"Menu(Enter your choice 1-5):
            1: Add
            2: Sub
            3: Mul
            4: Div
            5: Exit");
        }
        static void AskNum(ref double a, ref double b) {
            a = ChoiceForD();
            b = ChoiceForD();
        } 
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            do {
                Calculator calc = new Calculator();
                double a = 0;
                double b = 0;
                ShowMenu();
                int choice = ChoiceRange(1, 5);
                try
                {
                    if (choice == 1)
                    {
                        AskNum(ref a, ref b);
                        Console.WriteLine(calc.Add(a, b));
                    }
                    else if (choice == 2)
                    {
                        AskNum(ref a, ref b);
                        Console.WriteLine(calc.Sub(a, b));
                    }
                    else if (choice == 3)
                    {
                        AskNum(ref a, ref b);
                        Console.WriteLine(calc.Mul(a, b));
                    }
                    else if (choice == 4)
                    {
                        AskNum(ref a, ref b);
                        Console.WriteLine(calc.Div(a, b));
                    }
                    else if (choice == 5)
                    {
                        break;
                    }
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                }
                


            } while (true);
        }
    }
}
