using EcommerceSystem.Domain.Entities;

namespace EcommerceSystem.Application.Services
{
    public class AddToCartService
    {
        public void AddToCart(Cart cart, Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");
            if (quantity > product.Quantity)
                throw new InvalidOperationException($"Not enough stock for {product.Name}.");
            cart.Add(product, quantity);
        }
    }
} 