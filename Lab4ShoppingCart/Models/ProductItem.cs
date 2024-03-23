namespace Lab4ShoppingCart.Models
{
    public class ProductItem
    {
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
    }

    public class CartItem : ProductItem
    {
        public int Quantity { get; set; }
    }
}
