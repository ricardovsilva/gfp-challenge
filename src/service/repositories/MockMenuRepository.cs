using System.Collections.Generic;
using domain.entities;
using domain.factories;
using domain.interfaces;

namespace service.repositories
{
    public class MockMenuRepository : IEntityRepository<Menu>
    {
        private Menu Menu { get; set; }

        public MockMenuRepository()
        {
            this.Menu = MenuFactory.GetDefault();
        }

        public IEnumerable<Menu> GetAll()
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