using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemStock
{
    internal class StockItem
    {
        public int ItemAmount { get; private set; } = 0;
        public string ItemName { get; private set; }
        public string ItemCode { get; private set; }


        public StockItem(string itemName, string itemCode)
        {
            this.ItemName = itemName;
            this.ItemCode = itemCode.Length > 0 ? itemCode : RandomString(5);
        }


        public void changeAmountInStock(string input, int plusMinus)
        {
            bool parse = int.TryParse(input, out int amount);
            if (amount > 0)
            {
                

                //Catches user not writing a number
                while (!parse)
                {
                    Console.WriteLine("ERROR, Please write a number");
                    parse = int.TryParse(Console.ReadLine(), out amount);
                }
                this.ItemAmount += plusMinus * amount;
            }
            else
            {
                this.ItemAmount = this.ItemAmount + (plusMinus * 1);
            }
            //Avoids user creating a minus stock value since we cant sell more than we have
            if(this.ItemAmount < 0)
            {
                Console.WriteLine("ERROR: You went below 0. Stock amount set to 0");
                this.ItemAmount = 0;
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void checkAmountOfItemInStock()
        {
            Console.WriteLine("There is {0} of #{1}, {2} in stock", ItemAmount, ItemCode, ItemName);
        }
    }
}
