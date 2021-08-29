using ProArch.CodingTest.DataModel;
using ProArch.CodingTest.InterfaceRepo;

namespace ProArch.CodingTest.Summary
{
    public class ExternalSpendService : SpendService
    {
        private IFaildMaxtries circuitBreaker;

        public ExternalSpendService(
            ISupplierService supplierService,
            IFaildMaxtries circuitBreaker
            )
        {
            this.supplierService = supplierService;
            this.circuitBreaker = circuitBreaker;
        }

        public override SpendSummary GetTotalSpend(int supplierId)
        {
            SpendSummary result = new SpendSummary();

            result.Name = supplierService.GetById(supplierId).Name;
            result.Years = circuitBreaker.GetSpendDetail(supplierId);

            return result;
        }
    }
}
