using MedicineTracker.Controllers;
using MedicineTracker.Models;
using MedicineTracker.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MedicineTracker.UnitTests
{
    public class MedicineControllerTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var medicines = new List<Medicine>()
            {
                new Medicine(){Name="PN45", Brand="Test1", ExpiryDate=DateTime.Now, Quantity=50, Notes= "This is a medicine named PN45", Price=140},
                new Medicine(){ Name="Dispn", Brand="Test2", ExpiryDate=DateTime.Now, Quantity=87, Notes= "This is a medicine named Dispn", Price=200},
                new Medicine(){Name="Sompz", Brand="Test3", ExpiryDate=DateTime.Now, Quantity=35, Notes= "This is a medicine named Sompz", Price=50},
                new Medicine(){ Name="DDO", Brand="Test4", ExpiryDate=DateTime.Now, Quantity=15, Notes= "This is a medicine named DDO", Price=40},
                new Medicine(){Name="Denpr", Brand="Test5", ExpiryDate=DateTime.Now, Quantity=88, Notes= "This is a medicine named Denpr", Price=89},
                new Medicine(){Name="O4", Brand="Test6", ExpiryDate=DateTime.Now, Quantity=55, Notes= "This is a medicine named 04", Price=385}
            };
            var medicineRepositoryMock = new Mock<IMedicineRepository>();
            medicineRepositoryMock.Setup(x => x.GetMedicines()).Returns(Task.Run(()=> medicines.AsEnumerable()));
            var medicineController = new MedicineController(medicineRepositoryMock.Object);

            //act
            var result = medicineController.Index().Result;
            //assert
            medicineRepositoryMock.Verify(x => x.GetMedicines(), Times.Once);
        }
    }
}
