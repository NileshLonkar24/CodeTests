using Moq;
using NUnit.Framework;
using ProArch.CodingTest.DataLayerUnitTest;
using ProArch.CodingTest.DataModel;
using ProArch.CodingTest.InterfaceRepo;
using ProArch.CodingTest.Summary;
using ProArch.CodingTest.Suppliers;
using System.Collections.Generic;
using System.Threading;
using Unity;

namespace Proarch.NunitTest
{
    public class ExternalSupplierServiceUnitTest
    {
        private UnityContainer container;
        [SetUp]
        public void Setup()
        {
            container = new UnityContainer();
            container.RegisterType<ISupplierDataService, SupplierDataServiceData>();
            container.RegisterType<ISupplierService, SupplierService>();
            container.RegisterType<IInvoiceRepository, InvoiceRepositoryData>();
            container.RegisterType<IExternalSpendService, ExternalInvoiceServiceData>();
            container.RegisterType<IFaildMaxtries, ExternalSpendServiceInvoker>();
            container.RegisterType<IFailoverInvoiceService, FailoverInvoiceServiceData>();
        }

        
        [Test]
        public void SpendService_ExternalCustomerName()
        {
            // Arrange
            int supplierId = 2;
            SpendService spendService = container.Resolve<ExternalSpendService>();

            // Act
            SpendSummary result = spendService.GetTotalSpend(supplierId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Xyz vendor for Tata moters-External", result.Name);
        }

        [Test]
        public void SpendService_ExternalCustomerSpend()
        {
            // Arrange
            int supplierId = 2;
            SpendService spendService = container.Resolve<ExternalSpendService>();

            // Act
            SpendSummary result = spendService.GetTotalSpend(supplierId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Years.Count);
            Assert.AreEqual(1000, result.Years[0].TotalSpend);
            Assert.AreEqual(1000, result.Years[1].TotalSpend);
        }

        [Test]
        public void SpendService_ExternalCustomerSpend_FailoverCase()
        {
            // Arrange
            int supplierId = 3;
            SpendService spendService = container.Resolve<ExternalSpendService>();

            // Act
            SpendSummary result = spendService.GetTotalSpend(supplierId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Xyz vendor for Tata moters-External (Failover)", result.Name);
            Assert.AreEqual(1, result.Years.Count);
            Assert.AreEqual(800, result.Years[0].TotalSpend);
        }

        [Test]
        public void SpendService_ExternalCustomerSpend_FailoverCase_IsInClosedTime()
        {
            // Arrange
            int supplierId = 3;
            SpendService spendService = container.Resolve<ExternalSpendService>();

            // Act
            SpendSummary result = spendService.GetTotalSpend(supplierId);
            result = spendService.GetTotalSpend(supplierId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Xyz vendor for Tata moters-External (Failover)", result.Name);
            Assert.AreEqual(1, result.Years.Count);
            Assert.AreEqual(800, result.Years[0].TotalSpend);
        }

         

        [Test]
        public void SpendService_ExternalCustomerSpend_ReturnToNormalAfter1Minute()
        {
            // Arrange
            Mock<IFaildMaxtries> mockedInstance = new Mock<IFaildMaxtries>();
            mockedInstance.Setup(mc => mc.ClosedTimeSeconds).Returns(5); // Adjust Timeout to 5 Seconds
            mockedInstance.Setup(mc => mc.GetSpendDetail(2)).Returns( // Set Data
                new List<SpendDetail>(
                    new SpendDetail[] {
                        new SpendDetail() {TotalSpend =1001, Year = 2021 },
                        new SpendDetail() {TotalSpend =1001, Year = 2020 }
                    }
                    ));

            UnityContainer container = new UnityContainer();
            container.RegisterType<ISupplierDataService, SupplierDataServiceData>();
            container.RegisterType<ISupplierService, SupplierService>();
            container.RegisterType<IInvoiceRepository, InvoiceRepositoryData>();
            container.RegisterType<IExternalSpendService, ExternalInvoiceServiceData>();
            container.RegisterType<IFaildMaxtries, ExternalSpendServiceInvoker>();
            container.RegisterType<IFailoverInvoiceService, FailoverInvoiceServiceData>();

            SpendService spendService = container.Resolve<ExternalSpendService>();
            SpendSummary resultFailover = spendService.GetTotalSpend(3);

            Thread.Sleep(1000 * 5 + 1); // Wait 6 Seconds

            // Act
            container.RegisterInstance<IFaildMaxtries>(mockedInstance.Object);
            spendService = container.Resolve<ExternalSpendService>();
            SpendSummary resultNormal = spendService.GetTotalSpend(2);

            // Assert
            Assert.IsNotNull(resultFailover);
            Assert.AreEqual("Xyz vendor for Tata moters-External (Failover)", resultFailover.Name);
            Assert.AreEqual(1, resultFailover.Years.Count);
            Assert.AreEqual(800, resultFailover.Years[0].TotalSpend);

            Assert.IsNotNull(resultNormal);
            Assert.AreEqual("Xyz vendor for Tata moters-External", resultNormal.Name);
            Assert.AreEqual(2, resultNormal.Years.Count);
            Assert.AreEqual(1001, resultNormal.Years[0].TotalSpend);
            Assert.AreEqual(1001, resultNormal.Years[1].TotalSpend);
        }

    }
}