using System.Collections.Generic;
using domain.entities;

namespace domain.interfaces
{
    public interface IOrderService
    {
        Order Create(string timeOfDay, IEnumerable<int> dishes);
        IEnumerable<Order> All();
    }
}