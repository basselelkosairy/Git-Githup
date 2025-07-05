namespace EcommerceSystem.Domain.Interfaces
{
    public interface IExpirable
    {
        DateTime ExpiryDate { get; }
        bool IsExpired();
    }
} 