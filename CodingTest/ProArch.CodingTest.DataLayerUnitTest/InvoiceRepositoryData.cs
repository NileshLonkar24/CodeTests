using ProArch.CodingTest.DataModel;
using ProArch.CodingTest.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProArch.CodingTest.DataLayerUnitTest
{
    /// <summary>
    /// This class is to genrate data for testing for Service : InvoiceRepository
    /// Class name :- InvoiceRepository
    /// Date :- 29th Aug 2021
    /// Author :- Nilesh Lonkar
    /// </summary>
    public class InvoiceRepositoryData : IInvoiceRepository
    {
        public IQueryable<Invoice> Get()
        {
            IList<Invoice> result = new List<Invoice>();

            result.Add(new Invoice() { SupplierId = 1, InvoiceDate = new DateTime(2021, 1, 1), Amount = 1000 });
            result.Add(new Invoice() { SupplierId = 1, InvoiceDate = new DateTime(2021, 2, 1), Amount = 1000 });
            result.Add(new Invoice() { SupplierId = 1, InvoiceDate = new DateTime(2019, 1, 1), Amount = 1000 });

            return result.AsQueryable();
        }
    }
}
