using MedicineTracker.Models;
using MedicineTracker.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MedicineTracker.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class MedicineController : Controller
    {
        private readonly IMedicineRepository medicineRepository;

        public MedicineController(IMedicineRepository medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }
        [Route("")]
        [Route("[action]")]
        [HttpGet]
        public async Task<ViewResult> Index()
        {
            var medicines = await this.medicineRepository.GetMedicines();
            return View(medicines);
        }

        [Route("[action]/{id?}")]
        public ViewResult Details(Guid id)
        {
            var medicine = this.medicineRepository.GetMedicineById(id);
            return  View(medicine);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Index([FromBody]Medicine medicine)
        {
           if(ModelState.IsValid)
            {
                var result = await medicineRepository.AddMedicine(medicine);
                return RedirectToAction("index", "Medicine");
            }
            return View(medicine);
        }
    }
}
