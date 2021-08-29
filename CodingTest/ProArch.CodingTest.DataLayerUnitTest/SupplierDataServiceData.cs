using ProArch.CodingTest.DataModel;
using ProArch.CodingTest.InterfaceRepo;
using System.Collections.Generic;
using System.Linq;

namespace ProArch.CodingTest.DataLayerUnitTest
{
    /// <summary>
    /// This class is to genrate data for testing :- SupplierDataService
    /// Class name :- ExternalInvoiceServiceData
    /// Date :- 29th Aug 2021
    /// Author :- Nilesh Lonkar
    /// </summary>
    public class SupplierDataServiceData : ISupplierDataService
    {
        private IList<Supplier> list = new List<Supplier>();

        public SupplierDataServiceData()
        {
            // 
            list.Add(new Supplier() { Id = 1, IsExternal = false, Name = "Tata motors Spear parts" });
            list.Add(new Supplier() { Id = 2, IsExternal = true, Name = "Xyz vendor for Tata moters-External" });
            list.Add(new Supplier() { Id = 3, IsExternal = true, Name = "Xyz vendor for Tata moters-External (Failover)" });
            list.Add(new Supplier() { Id = 4, IsExternal = true, Name = "Xyz vendor for Tata moters-External (Obsolete Data)" });
            list.Add(new Supplier() { Id = 5, IsExternal = false, Name = "Supplier Internal 2" });
            list.Add(new Supplier() { Id = 6, IsExternal = true, Name = "Supplier External 2" });
        }

        /// <summary>
        /// Get supplier by id
        /// </summary>
        /// <param name="id"> Pass ID as int </param>
        /// <returns></returns>
        public Supplier GetById(int id)
        {
            Supplier result = list.Where(s => s.Id == id).FirstOrDefault();
            return result;
        }
    }
}
