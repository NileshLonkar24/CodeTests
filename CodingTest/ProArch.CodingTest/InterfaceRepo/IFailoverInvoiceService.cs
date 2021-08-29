using ProArch.CodingTest.DataModel;

namespace ProArch.CodingTest.InterfaceRepo
{
    /// <summary>
    /// Interface for the failed request of invocies services   :- IFailoverInvoiceService
    /// Class name :- IFailoverInvoiceService
    /// Date :- 29th Aug 2021
    /// Author :- Nilesh Lonkar
    /// </summary>
    public interface IFailoverInvoiceService
    {
        FailoverInvoiceCollection GetInvoices(int supplierId);
    }
}
