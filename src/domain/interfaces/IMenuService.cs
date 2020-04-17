using domain.entities;

namespace domain.interfaces
{
    public interface IMenuService
    {
        Menu GetDefaultMenu();
        Menu FindById(int id);
    }
}