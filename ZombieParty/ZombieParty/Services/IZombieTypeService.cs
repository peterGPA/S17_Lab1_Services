using Microsoft.AspNetCore.Mvc.Rendering;
using ZombieParty.Models;


namespace ZombieParty.Services
{
    public interface IZombieTypeService : IServiceBaseAsync<ZombieType>
    {
        
        Task<bool> HasAssociatedZombies(int id);

       
        IEnumerable<SelectListItem> ListZombieTypeDisponible();
    }
}
