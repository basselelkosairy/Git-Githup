namespace EcommerceSystem.Domain.Entities
{
    public class CartItem
    {
        public Product Product { get; }
        public int Quantity { get; }
        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
} 