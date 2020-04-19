using System.Collections.Generic;
using System.Linq;
using domain.entities;

namespace domain.interfaces
{
    public interface IOrderService
    {
        Order Create(string timeOfDay, IEnumerable<int> dishes);
        IQueryable<Order> All();
    }
}