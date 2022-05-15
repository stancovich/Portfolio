namespace StockAPITest
{
    public interface IStockMemoryRepository
    {
        void AddItem(Item item);
        public List<Item> GetItems();
        Item FindItemByItemCode(string itemCode);
    }
    public class StockMemoryRepository : IStockMemoryRepository
    {
        public  List<Item> Items { get; private set; } = new List<Item>();
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public List<Item> GetItems()
        {
            return Items;
        }
        public Item FindItemByItemCode(string itemCode)
        {
            var output = Items.Find(x => x.ItemCode == itemCode);
            return output;
        }
    }
}
