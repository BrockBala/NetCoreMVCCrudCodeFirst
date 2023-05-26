using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreCrudCodefirst.Data;
using NetCoreCrudCodefirst.Models;
using NetCoreCrudCodefirst.Models.Domain;

namespace NetCoreCrudCodefirst.Controllers
{
    public class FightersController : Controller
    {
        private readonly MVCDemoDBContext mVCDemoDBContext;

        public FightersController(MVCDemoDBContext mVCDemoDBContext)
        {
            this.mVCDemoDBContext = mVCDemoDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var fighters = await mVCDemoDBContext.Fighters.ToListAsync();
            return View(fighters);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddFighterViewModel addFighterRequest)
        {
            var fighter = new Fighter()
            {
                Id = Guid.NewGuid(),
                Name = addFighterRequest.Name,
                Email = addFighterRequest.Email,
                Phone = addFighterRequest.Phone,
                Description = addFighterRequest.Description,
                DOB = addFighterRequest.DOB
            };
            await mVCDemoDBContext.Fighters.AddAsync(fighter);
            await mVCDemoDBContext.SaveChangesAsync();
            ViewBag.Fighter = "Added Successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ViewEmployee(Guid id)
        {
            var fighter = await mVCDemoDBContext.Fighters.FirstOrDefaultAsync(f => f.Id == id);

            if (fighter != null)
            {

                var viewmodel = new UpdateFighterViewModel()
                {
                    Id = fighter.Id,
                    Name = fighter.Name,
                    Phone = fighter.Phone,
                    Description = fighter.Description,
                    DOB = fighter.DOB,
                    Email = fighter.Email
                };
                return await Task.Run(() => View("ViewEmployee", viewmodel));

            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> ViewEmployee(UpdateFighterViewModel model)
        {
            var fighter = await mVCDemoDBContext.Fighters.FindAsync(model.Id);
            if (fighter != null)
            {
                fighter.Name = model.Name;
                fighter.Phone = model.Phone;
                fighter.Email = model.Email;
                fighter.DOB = model.DOB;
                fighter.Description = model.Description;

                await mVCDemoDBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(UpdateFighterViewModel model)
        {
            var fighter = await mVCDemoDBContext.Fighters.FindAsync(model.Id);
            if (fighter != null)
            {
                mVCDemoDBContext.Fighters.Remove(fighter);
                await mVCDemoDBContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");


        }


    }
}
