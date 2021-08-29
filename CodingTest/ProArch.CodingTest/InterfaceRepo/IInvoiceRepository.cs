using ProArch.CodingTest.DataModel;
using System.Linq;

namespace ProArch.CodingTest.InterfaceRepo
{
    /// <summary>
    /// Interface for Invoice repo   :- IInvoiceRepository
    /// Class name :- IInvoiceRepository
    /// Date :- 29th Aug 2021
    /// Author :- Nilesh Lonkar
    /// </summary>
    public interface IInvoiceRepository
    {
        IQueryable<Invoice> Get();
    }
}
