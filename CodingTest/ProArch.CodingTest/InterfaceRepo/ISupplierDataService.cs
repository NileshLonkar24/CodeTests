using ProArch.CodingTest.DataModel;

namespace ProArch.CodingTest.InterfaceRepo
{
    /// <summary>
    /// Interface for the supplier data services   :- ISupplierDataService
    /// Class name :- ISupplierDataService
    /// Date :- 29th Aug 2021
    /// Author :- Nilesh Lonkar
    /// </summary>
    public interface ISupplierDataService
    {
        Supplier GetById(int id);
    }
}
