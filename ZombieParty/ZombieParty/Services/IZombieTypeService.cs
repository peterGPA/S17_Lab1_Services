using Microsoft.EntityFrameworkCore;
using ZombieParty.Models;


namespace ZombieParty.Services
{
    public interface IZombieTypeService : IServiceBaseAsync<ZombieType>
    {
        Task<bool> HasAssociatedZombies(int id);
    }
}

