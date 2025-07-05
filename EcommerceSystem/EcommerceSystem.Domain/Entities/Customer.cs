namespace EcommerceSystem.Domain.Entities
{
    public class Customer
    {
        public string Name { get; }
        public double Balance { get; set; }
        public Customer(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }
    }
} 