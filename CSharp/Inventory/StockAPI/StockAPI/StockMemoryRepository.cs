namespace StockAPI
{
    public class StockMemoryRepository
    {
        public  string? ItemName { get; private set; }
        public  int Stock { get; private set; }
        public  void setStock(int amount)
        {
            this.Stock += amount;
            if(this.Stock < 0)
            {
                this.Stock = 0;
                throw new ArgumentOutOfRangeException();
            }
        }
        public void setItemName(string name)
        {
            this.ItemName = name;
            if(this.ItemName == null)
            {
                throw new ArgumentNullException("name");
            }
        }

        public StockMemoryRepository() { }
        public StockMemoryRepository(StockMemoryRepository stockItem) =>
            (ItemName, Stock) = (this.ItemName, this.Stock);

        
    }
}
