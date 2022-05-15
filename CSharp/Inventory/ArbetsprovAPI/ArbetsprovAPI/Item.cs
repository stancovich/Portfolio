namespace ArbetsprovAPI
{
    public class Item
    {
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public int Amount { get; private set; } = 0;

        public void IncreaseAmount(int amount)
        {
            if (amount == 0)
            {
                this.Amount++;
            }
            else
            {
                this.Amount += amount;
            }

        }
        public void DecreaseAmount(int amount)
        {
            if (amount == 0)
            {
                this.Amount++;
            }
            else
            {
                this.Amount += amount;
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
