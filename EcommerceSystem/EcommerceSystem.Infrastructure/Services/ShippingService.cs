using System;
using System.Collections.Generic;
using EcommerceSystem.Domain.Interfaces;

namespace EcommerceSystem.Infrastructure.Services
{
    public class ShippingService : IShippingService
    {
        public void Ship(List<IShippable> items)
        {
            if (items.Count == 0) return;
            Console.WriteLine("** Shipment notice **");
            double totalWeight = 0;
            var grouped = new Dictionary<string, (int count, double weight)>();
            foreach (var item in items)
            {
                if (!grouped.ContainsKey(item.GetName()))
                    grouped[item.GetName()] = (0, item.GetWeight());
                grouped[item.GetName()] = (grouped[item.GetName()].count + 1, item.GetWeight());
                totalWeight += item.GetWeight();
            }
            foreach (var kv in grouped)
            {
                Console.WriteLine($"{kv.Value.count}x {kv.Key} {kv.Value.weight * kv.Value.count * 1000}g");
            }
            Console.WriteLine($"Total package weight {totalWeight:0.###}kg");
        }
    }
} 