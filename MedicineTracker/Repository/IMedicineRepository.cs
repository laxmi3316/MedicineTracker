using MedicineTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineTracker.Repository
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicine>> GetMedicines();
        Task<Medicine> GetMedicineById(Guid Id);
        Task<Medicine> AddMedicine(Medicine medicine);
    }
}