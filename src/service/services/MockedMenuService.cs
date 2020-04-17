using System;
using domain.entities;
using domain.factories;
using domain.interfaces;

namespace service.services
{
    public class MockedMenuService : IMenuService
    {
        public Menu GetDefaultMenu()
        {
            return MenuFactory.GetDefault();
        }

        public Menu FindById(int id)
        {
            if (id == 1)
            {
                return MenuFactory.GetDefault();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}