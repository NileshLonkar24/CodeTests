using ProArch.CodingTest.External;
using ProArch.CodingTest.InterfaceRepo;

namespace ProArch.CodingTest.Summary
{
    public class ExternalSpendServiceWrapper : IExternalSpendService
    {
        public ExternalInvoice[] GetInvoices(string supplierId)
        {
            var result = ExternalInvoiceService.GetInvoices(supplierId);

            return result;
        }
    }
}
