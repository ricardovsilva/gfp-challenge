namespace domain.entities
{
    public class OrderDish : IEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int Id { get; set; }
    }
}