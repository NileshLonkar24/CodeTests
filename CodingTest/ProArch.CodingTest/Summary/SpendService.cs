using ProArch.CodingTest.DataModel;
using ProArch.CodingTest.InterfaceRepo;

namespace ProArch.CodingTest.Summary
{
    public abstract class SpendService
    {
        protected ISupplierService supplierService;

        public abstract SpendSummary GetTotalSpend(int supplierId);
    }
}
