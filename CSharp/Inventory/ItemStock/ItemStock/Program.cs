using System;

namespace ItemStock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool keepConsoleRunning = true;
            string itemName = "";
            string itemCode = "";

            //Initial logic before getting into the menu loop, this will ask to add an item and add an item code.
            StockItem item = new StockItem(itemName, itemCode);
            Console.WriteLine("Please write the name of the item you would like to add to the stock:");
            SetItemName(Console.ReadLine());
            Console.WriteLine("Please add a 5 character item code for {0}, if you would like the system to generate an item code, just press enter.", itemName);
            SetItemCode(Console.ReadLine());
            //Will be able to extend functionality to add more items.
            item = new StockItem(itemName, itemCode);
            Console.WriteLine(item.ItemAmount);
            //Logic to keep our menu running
            while (keepConsoleRunning)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Increase the amount of the item in stock");
                Console.WriteLine("[2] Decrease the amount of the item in stock");
                Console.WriteLine("[3] Show how much there currently is in stock");
                Console.WriteLine("[4] Reset stock and close app");

                int.TryParse(Console.ReadLine(), out int userInputChoice);
                //Menu loop
                switch (userInputChoice)
                {
                    case 1:
                        Console.WriteLine("How much would you like to add? If you just want to increase by 1, press enter");
                        item.changeAmountInStock(Console.ReadLine(),1);
                        break;
                    case 2:
                        Console.WriteLine("How much would you like to remove? If you just want to decrease by 1, press enter");
                        item.changeAmountInStock(Console.ReadLine(), -1);
                        break;
                    case 3:
                        item.checkAmountOfItemInStock();
                        break;
                    case 4:
                        keepConsoleRunning = false;
                        Console.WriteLine("Resetting stock to 0, See you!");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input, please enter a numeric value 1-4!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                }

            }

            //Methods
            void SetItemName(string input)
            {
                itemName = input.ToLower();
            }
            void SetItemCode(string input)
            {
                //Checks if we have a valid input length
                while(input.Length > 5 || (input.Length > 0 && input.Length < 5))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    string message = input.Length > 5 ? "Item code too long, please use a 5 character long code, eg. TYJD6" : "Item code too short, please use a 5 character long code, eg. TYJD6";
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;
                    input = Console.ReadLine();
                }
                itemCode = input;
            }
        }
    }
}
