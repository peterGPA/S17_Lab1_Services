using ZombieParty.Models;

namespace ZombieParty.Services
{
    public interface IZombieService : IServiceBaseAsync<Zombie>
    {
        // Liste des zombies pour un ZombieType donné
        Task<IReadOnlyList<Zombie>> GetAllByZombieTypeAsync(int zombieTypeId);

        // Liste des zombies triés par nom, avec leur ZombieType
        Task<IReadOnlyList<Zombie>> GetAllIndexAsync();

        // Vérifie si un zombie avec ce nom existe déjà
        bool ZombieNameExist(string name);
    }
}
