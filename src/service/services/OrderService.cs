using System;
using System.Collections.Generic;
using System.Linq;
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

        public Order Create(string timeOfDay, IEnumerable<int> dishesTypes)
        {
            var order = new Order();
            dishesTypes
                .Select(dishType =>
                    new Dish()
                    {
                        DishType = (DishTypes)dishType,
                        TimeOfDay = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), timeOfDay)
                    })
                .ToList()
                .ForEach(dish => order.AddDish(dish));

            this.OrderRepository.Save(order);
            return order;
        }
    }
}