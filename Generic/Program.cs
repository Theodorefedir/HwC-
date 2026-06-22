using System.Collections;

namespace Generic
{
    public class Stack<T>
    {
        private List<T> items = new List<T>();
        public int Count => items.Count;

        public void Push(T item) => items.Add(item);
        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty");
            T item = items[Count - 1];
            items.RemoveAt(Count - 1);
            return item;
        }
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty");
            return items[^1];
        }
    }

    public abstract class SeaCreature {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return $"Sea Creature: {Name}, age: {Age}, weight: {Weight} kg";
        }
    }
    public class Fish : SeaCreature {
        public Fish(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"Fish: {Name}, age: {Age}, weight: {Weight} kg";
        }
    }
    public class Dolphin : SeaCreature {
        public Dolphin(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"Dolphin: {Name}, age: {Age}, weight: {Weight} kg";
        }
    }
    public class Shark : SeaCreature {
        public Shark(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"Shark: {Name}, age: {Age}, weight: {Weight} kg";
        }
    }

    public class Oceanarium : IEnumerable<SeaCreature>
    {
        private List<SeaCreature> inhabitants = new List<SeaCreature>();
        public void Add(SeaCreature creature) { 
            inhabitants.Add(creature); 
        }

        public IEnumerator<SeaCreature> GetEnumerator()
        {
            return inhabitants.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class Manager<TKey, TValue>
    {
        private Dictionary<TKey, TValue> employees = new Dictionary<TKey, TValue>();
        public void Add(TKey login, TValue password) {
            employees[login] = password;
        }
        public void Remove(TKey login) { 
            employees.Remove(login);
        }
        public void Update(TKey login, TValue newPassword) {
            employees[login] = newPassword;
        }
        public TValue getPassword(TKey login) { 
            return employees.TryGetValue(login, out var password) ? password: default;
        }
    }
    internal class Program
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            var oceanarium = new Oceanarium();
            var fish = new Fish("Fish", 1, 12);
            var dolphin = new Dolphin("Dolphin", 1, 12);
            var shark = new Shark("Shark", 1, 12);
            oceanarium.Add(fish);
            oceanarium.Add(shark);
            oceanarium.Add(dolphin);
            foreach (var creature in oceanarium)
            {
                Console.WriteLine(creature);
            }

            var manager = new Manager<string, string>();
            manager.Add("john", "pass123");
            manager.Add("jane", "qwerty");
            Console.WriteLine(manager.getPassword("jane"));
        }
    }
}
