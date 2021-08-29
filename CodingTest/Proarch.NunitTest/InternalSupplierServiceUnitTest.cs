using NUnit.Framework;
using ProArch.CodingTest.DataLayerUnitTest;
using ProArch.CodingTest.DataModel;
using ProArch.CodingTest.InterfaceRepo;
using ProArch.CodingTest.Summary;
using ProArch.CodingTest.Suppliers;
using Unity;

namespace Proarch.NunitTest
{
    public class InternalSupplierServiceUnitTest {  
        private UnityContainer container;
        [SetUp]
        public void Setup()
        {
            container = new UnityContainer();
            container.RegisterType<ISupplierDataService, SupplierDataServiceData>();
            container.RegisterType<ISupplierService, SupplierService>();
            container.RegisterType<IInvoiceRepository, InvoiceRepositoryData>();
            
        }

        [Test]
        public void SpendService_InternalCustomerName()
        {
            // Arrange
            int supplierId = 1;
            SpendService spendService = container.Resolve<InternalSpendService>();

            // Act
            SpendSummary result = spendService.GetTotalSpend(supplierId);

            // Assert
            // Check supplier is internal
            Assert.IsNotNull(result);
            Assert.AreEqual("Tata motors Spear parts", result.Name);
        }

        [Test]
        public void SpendService_InternalCustomerSpend()
        {
            // Arrange
            int supplierId = 1;
            SpendService spendService = container.Resolve<InternalSpendService>();

            // Act
            SpendSummary result = spendService.GetTotalSpend(supplierId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Years.Count);
            Assert.AreEqual(2000, result.Years[0].TotalSpend);
            Assert.AreEqual(1000, result.Years[1].TotalSpend);
        }
       
    }
}