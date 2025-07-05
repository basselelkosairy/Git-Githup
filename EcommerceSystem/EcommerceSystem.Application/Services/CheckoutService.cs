using System;
using System.Collections.Generic;
using EcommerceSystem.Domain.Entities;
using EcommerceSystem.Domain.Interfaces;

namespace EcommerceSystem.Application.Services
{
    public class CheckoutService
    {
        private const double ShippingFee = 30.0;
        private readonly IShippingService _shippingService;
        public CheckoutService(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }
        public void Checkout(Customer customer, Cart cart)
        {
            if (cart.IsEmpty())
                throw new InvalidOperationException("Cart is empty.");
            double subtotal = 0;
            double shipping = 0;
            var shippableItems = new List<IShippable>();
            foreach (var item in cart.Items)
            {
                if (item.Quantity > item.Product.Quantity)
                    throw new InvalidOperationException($"Not enough stock for {item.Product.Name}.");
                if (item.Product is IExpirable exp && exp.IsExpired())
                    throw new InvalidOperationException($"Product {item.Product.Name} is expired.");
                subtotal += item.Product.Price * item.Quantity;
                if (item.Product is IShippable ship)
                {
                    for (int i = 0; i < item.Quantity; i++)
                        shippableItems.Add(ship);
                }
            }
            if (shippableItems.Count > 0)
                shipping = ShippingFee;
            double total = subtotal + shipping;
            if (customer.Balance < total)
                throw new InvalidOperationException("Customer's balance is insufficient.");
            // Print shipment
            _shippingService.Ship(shippableItems);
            // Print receipt
            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.Items)
            {
                Console.WriteLine($"{item.Quantity}x {item.Product.Name} {item.Product.Price * item.Quantity}");
            }
            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal {subtotal}");
            Console.WriteLine($"Shipping {shipping}");
            Console.WriteLine($"Amount {total}");
            customer.Balance -= total;
            Console.WriteLine($"Customer balance after payment: {customer.Balance}");
            // Decrement stock
            foreach (var item in cart.Items)
            {
                item.Product.Quantity -= item.Quantity;
            }
        }
    }
} 