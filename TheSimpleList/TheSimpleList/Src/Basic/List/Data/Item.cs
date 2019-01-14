namespace TheSimpleList.Src.Basic.List.Data
{
    public class Item
    {

        public Product Product { get; }

        public int Amount { get; }

        public bool Checked { get; set; }

        public Item(Product product, int amount, bool check = false)
        {
            Product = product;
            Amount = amount;
            Checked = check;
        }
    }
}
