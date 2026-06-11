namespace Interfaces
{
    interface IOutput
    {
        void Show();
        void Show(string info);
    }
    interface IMath
    {
        int Max();
        int Min();
        float Avg();
        bool Search(int valueToSearch);
    }
    public interface ISort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }
    class MyArray : IOutput, IMath, ISort
    {
        private int[] numbers;
        public MyArray(int[] numbers)
        {
            this.numbers = numbers;
        }
        public void Show()
        {
            Console.WriteLine(string.Join(", ", numbers));
        }
        public void Show(string info)
        {
            Console.WriteLine($"Info: {info}");
            Console.WriteLine(string.Join(", ", numbers));
        }
        public int Max() {
            if (numbers.Length > 0) {
                return numbers.Max();
            }
            return 0;
        }
        public int Min() {
            if (numbers.Length > 0) { return numbers.Min(); }
            return 0;
        }
        public float Avg() {
            if (numbers.Length > 0) { return (float)numbers.Average();  }
            return 0;
        }
        public bool Search(int valueToSearch)
        {
            foreach (int num in numbers)
            {
                if (num == valueToSearch) return true;
            }
            return false;
        }
        public void SortAsc()
        {
            Array.Sort(numbers);
        }

        public void SortDesc()
        {
            Array.Sort(numbers);
            Array.Reverse(numbers);
        }

        public void SortByParam(bool isAsc)
        {
            if (isAsc)
                SortAsc();
            else
                SortDesc();
        }
    }
    internal class Program
    {        
        static void Main(string[] args)
        {
            MyArray arr = new MyArray(new int[] { 1, 2, 3, 4, 5, 8, 0, 67, 88, 1 });
            arr.Show();
            int searchValue = 5;
            Console.WriteLine($"Search {searchValue} is {arr.Search(searchValue)}");
            arr.SortDesc();
            arr.Show("Sorted arr by Desc");
            arr.SortByParam(true);
            arr.Show("Sorted by Asc");
            Console.WriteLine($"Min: {arr.Min()}");
        }
    }
}
