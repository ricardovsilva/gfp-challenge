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
        private readonly IDishService DishService;
        private readonly IEntityRepository<OrderDish> OrderDishRepository;

        public OrderService(IEntityRepository<Order> orderRepository, IEntityRepository<OrderDish> orderDishRepository, IDishService dishService)
        {
            this.OrderRepository = orderRepository;
            OrderDishRepository = orderDishRepository;
            this.DishService = dishService;
        }

        public IQueryable<Order> All()
        {
            return OrderRepository.GetAll();
        }

        public Order Create(string timeOfDayText, IEnumerable<int> dishesTypes)
        {
            var order = new Order();
            var dishes = DishService.All();
            var timeOfDay = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), timeOfDayText);
            dishesTypes
                .Select(dishType => dishes.First(_ => _.DishType == (DishTypes)dishType && _.TimeOfDay == timeOfDay))
                .ToList()
                .ForEach(dish => order.AddDish(dish));

            this.OrderRepository.Save(order);
            return order;
        }
    }
}