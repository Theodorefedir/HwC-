using System;
using System.Data;
using System.Diagnostics;

namespace hw2Enum
{
    enum Pizza 
    { 
        Hawaiian = 0,
        Sicilian = 1,
        Roman = 2,
        Margherita = 3
    }

    enum Drinks { 
        Water = 0,
        Tea = 1,
        Coffee = 2,
        Smoothie = 3,
        Wine = 4
    }

    enum Menu
    {
        ShowMenu = 1,
        MakeOrder = 2,
        Exit = 3
    }
    internal class Program
    {
        static List<int> pizzaPrices = new List<int>() { 45, 50, 60, 38 };
        static List<int> drinksPrices = new List<int>() { 3, 5, 7, 12, 23 };
        static int[] pizzaCount = new int[4];
        static int[] drinkCount = new int[5];

        static int Choice() {
            int num = 0;
            bool valid = true;
            while (valid) {
                Console.WriteLine("Your choice: ");
                string choice = Console.ReadLine();
                if (int.TryParse(choice, out num))
                {
                    Console.WriteLine("Ok\n");
                    valid = false;
                }
                else {
                    Console.WriteLine("Error, not a number\n");
                }
            }
            return num;
        }

        static void ShowMenu() {
            int i = 0;
            int j = 0;
            foreach (Pizza pizza in Enum.GetValues(typeof(Pizza))) {
                Console.WriteLine($"id: {(int)pizza}, {pizza} price: {pizzaPrices[i]}\n");
                i++;
            }
            foreach (Drinks drink in Enum.GetValues(typeof(Drinks)))
            {
                Console.WriteLine($"id: {(int)drink}, {drink} price: {drinksPrices[j]}\n");
                j++;
            }
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
        static void MakeAnOrder() {
            Console.WriteLine("1 - Pizza");
            Console.WriteLine("2 - Drink");
            int type = ChoiceRange(1, 2);
            if (type == 1)
            {
                ShowMenu();
                Console.WriteLine("Enter pizza id:");
                int id = ChoiceRange(0, pizzaCount.Length - 1);
                Console.WriteLine("Quantity:");
                int qty = ChoiceRange(1, 100);
                pizzaCount[id] += qty;
            }
            else
            {
                ShowMenu();
                Console.WriteLine("Enter drink id:");
                int id = ChoiceRange(0, drinkCount.Length - 1);
                Console.WriteLine("Quantity:");
                int qty = ChoiceRange(1, 100);
                drinkCount[id] += qty;
            }
        }
        static void MainMenu() {
            int choice;
            Console.WriteLine("1 - Show menu;\n2 - make an order\n3 - exit");
            while (true)
            {
                int ask = Choice();
                if (ask <= 3 && ask >= 1)
                {
                    choice = ask;
                    if (choice == (int)Menu.ShowMenu)
                    {
                        ShowMenu();
                    }
                    else if (choice == (int)Menu.MakeOrder)
                    {
                        MakeAnOrder();
                    }
                    else if (choice == (int)Menu.Exit)
                    {
                        break;
                    }
                }
                else { 
                    Console.WriteLine("Wrong number");
                    continue;
                }
            }       
        }
        static void Receipt() {
            Console.WriteLine("You ordered: \n");
            for (int i = 0; i < pizzaCount.Length; i++) {
                if (pizzaCount[i] > 0) {
                    Console.WriteLine($"Pizza {(Pizza)i} x {pizzaCount[i]} price: {pizzaPrices[i] * pizzaCount[i]}");
                }                
            }
            for (int i = 0; i < drinkCount.Length; i++)
            {
                if (drinkCount[i] > 0)
                {
                    Console.WriteLine($"Drink: {(Drinks)i} x {drinkCount[i]} price: {drinksPrices[i] * drinkCount[i]}");
                }
            }
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to our pizzeria!");
            MainMenu();
            Receipt();
        }
    }
}
