using System.Collections.Generic;
using domain.entities;
using domain.repositories;

namespace infra.repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(IDatabase database)
            : base(database) { }
    }
}