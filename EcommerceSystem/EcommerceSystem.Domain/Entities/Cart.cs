using System.Collections.Generic;

namespace EcommerceSystem.Domain.Entities
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();
        public IReadOnlyList<CartItem> Items => items;
        public void Add(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");
            if (quantity > product.Quantity)
                throw new InvalidOperationException($"Not enough stock for {product.Name}.");
            items.Add(new CartItem(product, quantity));
        }
        public bool IsEmpty() => items.Count == 0;
    }
} 