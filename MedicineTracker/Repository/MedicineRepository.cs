using MedicineTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineTracker.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public MedicineRepository(ApplicationDbContext applicationDbContext)
        {
            // in memory data
            //medicines = new List<Medicine>()
            //{
            //    new Medicine(){Id=1,Name="PN45", Brand="Test1", ExpiryDate=DateTime.Now, Quantity=50, Notes= "This is a medicine named PN45", Price=140},
            //    new Medicine(){Id=2, Name="Dispn", Brand="Test2", ExpiryDate=DateTime.Now, Quantity=87, Notes= "This is a medicine named Dispn", Price=200},
            //    new Medicine(){Id=3, Name="Sompz", Brand="Test3", ExpiryDate=DateTime.Now, Quantity=35, Notes= "This is a medicine named Sompz", Price=50},
            //    new Medicine(){Id=4, Name="DDO", Brand="Test4", ExpiryDate=DateTime.Now, Quantity=15, Notes= "This is a medicine named DDO", Price=40},
            //    new Medicine(){Id=5, Name="Denpr", Brand="Test5", ExpiryDate=DateTime.Now, Quantity=88, Notes= "This is a medicine named Denpr", Price=89},
            //    new Medicine(){Id=6, Name="O4", Brand="Test6", ExpiryDate=DateTime.Now, Quantity=55, Notes= "This is a medicine named 04", Price=385}
            //};
            this.applicationDbContext = applicationDbContext;
        }    

        public async Task<Medicine> GetMedicineById(Guid Id)
        {
            return await applicationDbContext.Medicines.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return await applicationDbContext.Medicines.ToListAsync();
        }

        public async Task<Medicine> AddMedicine(Medicine medicine)
        {
            var result= applicationDbContext.Medicines.AddAsync(medicine);
            if (result.IsCompleted)
            {
                await applicationDbContext.SaveChangesAsync();
            }
            return await applicationDbContext.Medicines.FirstOrDefaultAsync(x => x.Id == medicine.Id);
        }

    }
}
