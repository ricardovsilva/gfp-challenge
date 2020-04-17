using System.Collections.Generic;
using domain.entities;
using domain.interfaces;

namespace service.services
{
    public class OrderService : IOrderService
    {
        private readonly IEntityRepository<Order> OrderRepository;

        public OrderService(IEntityRepository<Order> orderRepository)
        {
            this.OrderRepository = orderRepository;
        }

        public IEnumerable<Order> All()
        {
            return OrderRepository.GetAll();
        }

        public Order Create(string timeOfDay, IEnumerable<int> dishes)
        {
            throw new System.NotImplementedException();
        }
    }
}