namespace Lab4ShoppingCart.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items;

        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }

        public void AddItem(ProductItem item)
        {
            var match = Items.FirstOrDefault(i => i.ProductCode == item.ProductCode);

            if (match != null){
                match.Quantity++;
            } else
            {
                Items.Add(new CartItem() { ProductCode=item.ProductCode, ProductDescription=item.ProductDescription, ProductPrice=item.ProductPrice, Quantity=1});
            }
            
        }

        public double CalculateCart()
        {
            return Items.Sum(p => p.ProductPrice * p.Quantity);
        }
    }
}
