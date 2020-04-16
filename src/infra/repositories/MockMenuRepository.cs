using System.Collections.Generic;
using domain.entities;
using domain.factories;
using domain.repositories;

namespace infra.repositories
{
    public class MockMenuRepository : IEntityRepository<Menu>
    {
        private Menu Menu { get; set; }

        public MockMenuRepository()
        {
            this.Menu = MenuFactory.GetDefault();
        }

        public IEnumerable<Menu> All()
        {
            return new[] { Menu };
        }

        public Menu Find(int id)
        {
            return Menu;
        }

        public void Save(Menu target)
        {
            this.Menu = Menu;
        }
    }
}