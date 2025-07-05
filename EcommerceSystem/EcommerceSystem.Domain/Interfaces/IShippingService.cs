using System.Collections.Generic;

namespace EcommerceSystem.Domain.Interfaces
{
    public interface IShippingService
    {
        void Ship(List<IShippable> items);
    }
} 