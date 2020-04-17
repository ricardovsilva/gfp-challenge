using domain.entities;
using domain.factories;
using domain.interfaces;

namespace service.services
{
    public class MockedMenuService : IMenuService
    {
        public Menu GetMenu()
        {
            return MenuFactory.GetDefault();
        }
    }
}