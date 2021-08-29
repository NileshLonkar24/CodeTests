using ProArch.CodingTest.DataModel;

namespace ProArch.CodingTest.InterfaceRepo
{
    /// <summary>
    /// Interface for the supplier  services   :- ISupplierService
    /// Class name :- ISupplierService
    /// Date :- 29th Aug 2021
    /// Author :- Nilesh Lonkar
    /// </summary>
    public interface ISupplierService
    {
        Supplier GetById(int id);
    }
}
