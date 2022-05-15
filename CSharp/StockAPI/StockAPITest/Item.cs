namespace StockAPITest
{
    public class Item
    {
        public string? ItemCode { get; set; }
        public string? Name { get; set; }
        public int Amount { get; private set; } = 0;

        public void SetItemCode(string itemCode)
        {
            this.ItemCode = itemCode;
        }
        public void ChangeAmount(int amount)
        {
            Amount = Amount + amount;
            if(Amount < 0)
            {
                Amount = 0;
            }
        }
        private Random random = new Random();
        public string ItemCodeGenerator(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
