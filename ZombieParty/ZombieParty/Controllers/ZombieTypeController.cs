
using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;
using ZombieParty.Services;
using ZombieParty.Utility;
using ZombieParty.ViewModels;

namespace ZombieParty.Controllers
{
    public class ZombieTypeController : Controller
    {
        private IZombieTypeService _serviceZT { get; set; }
        private IZombieService _serviceZ { get; set; }

        public ZombieTypeController(IZombieTypeService serviceZT, IZombieService serviceZ)
        {
            _serviceZT = serviceZT;
            _serviceZ = serviceZ;
        }

        // GET: ZombieType
        public async Task<IActionResult> Index()
        {
            return View(await _serviceZT.GetAllAsync());
        }

        // GET: ZombieType/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ZombieType? zombieType = await _serviceZT.GetByIdAsync(id);
            if (zombieType == null)
            {
                return NotFound();
            }

            IReadOnlyList<Zombie> zombies = await _serviceZ.GetAllByZombieTypeAsync(id);

            ZombieTypeVM zombieTypeVM = new()
            {
                ZombieType = zombieType,
                ZombiesList = zombies,
                ZombiesCount = zombies.Count,
                PointsAverage = zombies.Count > 0 ? zombies.Average(p => p.Point) : 0
            };

            return View(zombieTypeVM);
        }

        // GET: ZombieType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZombieType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ZombieType zombieType)
        {
            if (ModelState.IsValid)
            {
                await _serviceZT.CreateAsync(zombieType);

                TempData[AppConstants.Success] =
                    $"{zombieType.TypeName} zombie type added";

                return RedirectToAction(nameof(Index));
            }

            return View(zombieType);
        }

        // GET: ZombieType/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ZombieType? zombieType = await _serviceZT.GetByIdAsync(id);

            if (zombieType == null)
            {
                return NotFound();
            }

            return View(zombieType);
        }

        // POST: ZombieType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ZombieType zombieType)
        {
            if (ModelState.IsValid)
            {
                await _serviceZT.EditAsync(zombieType);

                TempData[AppConstants.Success] =
                    $"ZombieType {zombieType.TypeName} has been modified";

                return RedirectToAction(nameof(Index));
            }

            return View(zombieType);
        }


        // GET: ZombieType/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            ZombieType? zombieType =
                await _serviceZT.GetByIdAsync(id);

            if (zombieType == null)
            {
                return NotFound();
            }

            return View(zombieType);
        }


        //POST: ZombieType/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            ZombieType? zombieType = await _serviceZT.GetByIdAsync(id);
            if (zombieType == null)
            {
                return NotFound();
            }


            await _serviceZT.DeleteAsync(id);
            TempData[AppConstants.Success] = $"ZombieType {zombieType.TypeName} has been removed";


            return RedirectToAction(nameof(Index));
        }
    }
}
