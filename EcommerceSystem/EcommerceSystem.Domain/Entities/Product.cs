using EcommerceSystem.Domain.Interfaces;

namespace EcommerceSystem.Domain.Entities
{
    public class Product : IExpirable, IShippable
    {
        public string Name { get; }
        public double Price { get; }
        public int Quantity { get; set; }
        public DateTime? ExpiryDate { get; }
        public double? Weight { get; }

        public Product(string name, double price, int quantity, DateTime? expiryDate = null, double? weight = null)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            ExpiryDate = expiryDate;
            Weight = weight;
        }

        // IExpirable implementation
        bool IExpirable.IsExpired()
        {
            return ExpiryDate.HasValue && DateTime.Now > ExpiryDate.Value;
        }
        DateTime IExpirable.ExpiryDate
        {
            get
            {
                if (!ExpiryDate.HasValue)
                    throw new InvalidOperationException("This product does not expire.");
                return ExpiryDate.Value;
            }
        }
        // IShippable implementation
        string IShippable.GetName()
        {
            return Name;
        }
        double IShippable.GetWeight()
        {
            if (!Weight.HasValue)
            {
                throw new InvalidOperationException("This product is not shippable.");
            }
            return Weight.Value;
        }
    }
} 