namespace Delegate
{
    class CreditCard {        
        public string CardNum { get; set; }
        public string Owner { get; set; }
        public DateTime ValidDate { get; set; }
        public int Pin { get; set; }
        public int CreditLimit { get; set; }
        public int Balance { get; set; }

        public event Action<int> OnDeposit;
        public event Action<int> OnSpendMoney;
        public event Action<int> OnSpendCreditMoney;
        public event Action OnChangePin;
        public event Action OnSuccess;

        public CreditCard(string cardNumber, string name, DateTime validDate, int pin, int creditLimit, int Balance)
        {
            CardNum = cardNumber;
            Owner = name;
            ValidDate = validDate;
            Pin = pin;
            CreditLimit = creditLimit;
            this.Balance = Balance;
        }
        public void Deposit(int amount) {
            if (amount > 0)
            {
                Balance += amount;
                OnDeposit?.Invoke(amount);
            }
            else { 
                OnSuccess?.Invoke();
            }
        }
        public void SpendMoney(int amount) {
            if (amount > 0 && Balance>=amount) {
                Balance -= amount;
                OnSpendMoney?.Invoke(amount);
            }
            else
            {
                OnSuccess?.Invoke();
            }
        }
        public void SpendCreditMoney(int amount) {
            if (CreditLimit > amount && amount > 0) { 
                CreditLimit -= amount;
                OnSpendCreditMoney?.Invoke(amount);
            }
            else
            {
                OnSuccess?.Invoke();
            }
        }
        public void ChangePin(int oldPin, int newPin) {
            if (oldPin == Pin && newPin != Pin) { 
                Pin = newPin;
                OnChangePin?.Invoke();
            }
            else
            {
                OnSuccess?.Invoke();
            }
        }
    }

    delegate bool CheckNumber(int number);
    internal class Program
    {
        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
        static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        static bool IsFibonacci(int number)
        {
            if (number < 0) return false;
            int a = 0;
            int b = 1;
            if (number == a || number == b) return true;
            int next = a + b;
            while (next <= number)
            {
                if (next == number) return true;
                a = b;
                b = next;
                next = a + b;
            }
            return false;
        }
        static void PrintArr(int[] arr) {
            Console.WriteLine(string.Join(", ", arr));
        }
        static void ShowCurrentTime()
        {
            Console.WriteLine($"Current time: {DateTime.Now:HH:mm:ss}");
        }
        static void ShowCurrentDate()
        {
            Console.WriteLine($"Current date: {DateTime.Now:yyyy-MM-dd}");
        }
        static void ShowCurrentDayOfWeek()
        {
            Console.WriteLine($"Current day: {DateTime.Now.DayOfWeek}");
        }
        static double CalculateTriangleArea(double baseLength, double height)
        {
            return (baseLength * height) / 2;
        }
        static double CalculateRectangleArea(double width, double height)
        {
            return width * height;
        }

        //4
        static int GetLength(string text)
        {
            return text.Length;
        }
        static int CountVowels(string text)
        {
            int count = 0;
            string vowels = "aeiouAEIOU";

            foreach (char c in text)
            {
                if (char.IsLetter(c) && vowels.Contains(c))
                    count++;
            }
            return count;
        }
        static int CountConsonants(string text)
        {
            int count = 0;
            string vowels = "aeiouAEIOU";

            foreach (char c in text)
            {
                if (char.IsLetter(c) && !vowels.Contains(c))
                    count++;
            }
            return count;
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] result = CheckNumbersMethod(arr, IsEven);
            PrintArr(result);
            Action ShowDay = ShowCurrentDayOfWeek;
            Func<double, double, double> RectangleArea = CalculateRectangleArea;
            ShowDay();
            Console.WriteLine(RectangleArea(10, 25));
            CreditCard card = new CreditCard("1234-5678", "John Doe", DateTime.Now, 1234, 5000, 500);
            card.OnDeposit += (amount) => Console.WriteLine($"Deposit {amount}");
            card.OnSpendCreditMoney += (amount) => Console.WriteLine($"You spent {amount} credit money");
            card.OnSuccess += () => Console.WriteLine("Error");
            card.OnSpendMoney += (amount) => Console.WriteLine($"Ypu spent {amount}");
            card.OnChangePin += () => Console.WriteLine("You changed your pin");
            card.Deposit(100);
            string text = "aaaabbbasad9sa0d8asasjh ";
            Func<string, int> vowelCount = CountVowels;
            Func<string, int> consonantCount = CountConsonants;
            Func<string, int> lengthCount = GetLength;
            Console.WriteLine($"Vowels: {vowelCount(text)}");
            Console.WriteLine($"Consonants: {consonantCount(text)}");
            Console.WriteLine($"Length: {lengthCount(text)}");

        }

        static int[] CheckNumbersMethod(int[] arr, CheckNumber checkNumber)
        {
            List<int> list = new List<int>();
            foreach (int num in arr)
            {
                if (checkNumber(num))
                {
                    list.Add(num);
                }
            }
            return list.ToArray();
        }
    }
}
