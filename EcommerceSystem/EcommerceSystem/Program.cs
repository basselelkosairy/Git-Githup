using System;
using EcommerceSystem.Domain.Entities;
using EcommerceSystem.Application.Services;
using EcommerceSystem.Infrastructure.Services;

namespace EcommerceSystem
{


    public class Program
    {
        static void Main(string[] args)
        {
            // Replace the incorrect instantiation of the abstract class 'Product' with the instantiation of its derived classes.

            var cheese = new Product("Cheese", 100, 10, DateTime.Now.AddDays(5), 0.4); // 400g, expirable, shippable
            var biscuits = new Product("Biscuits", 150, 5, DateTime.Now.AddDays(2), 0.7); // 700g, expirable, shippable
            var tv = new Product("TV", 5000, 3,null, 8.2); // 8kg, shippable
            var mobile = new Product("Mobile", 3000, 10); // not expirable, not shippable
            var scratchCard = new Product("ScratchCard", 50, 100); // not expirable, not shippable

            var customer = new Customer("Hassan", 1000);
            var cart = new Cart();
            var addToCartService = new AddToCartService();
            var shippingService = new ShippingService();
            var checkoutService = new CheckoutService(shippingService);
            try
            {
                addToCartService.AddToCart(cart, cheese, 2);
                addToCartService.AddToCart(cart, biscuits, 1);
                // addToCartService.AddToCart(cart, tv, 3); // Test out-of-stock
                addToCartService.AddToCart(cart, scratchCard, 1);
                checkoutService.Checkout(customer, cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
