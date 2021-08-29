using ProArch.CodingTest.External;

namespace ProArch.CodingTest.InterfaceRepo
{
    /// <summary>
    /// Interface for the Extenl Sepnd Services   :- IExternalSpendService
    /// Class name :- IExternalSpendService
    /// Date :- 29th Aug 2021
    /// Author :- Nilesh Lonkar
    /// </summary>
    public interface IExternalSpendService
    {
        ExternalInvoice[] GetInvoices(string supplierId);
    }
}
