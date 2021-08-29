
using ProArch.CodingTest.External;
using ProArch.CodingTest.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ProArch.CodingTest.DataLayerUnitTest
{
    /// <summary>
    /// This class is to genrate data for testing for Service :- ExternalInvoiceServiceData
    /// Class name :- ExternalInvoiceServiceData
    /// Date :- 29th Aug 2021
    /// Author :- Nilesh Lonkar
    /// </summary>
    public class ExternalInvoiceServiceData : IExternalSpendService
    {

        /// <summary>
        /// This methid is to set the fake data for Unit testing 
        /// </summary>
        /// <param name="supplierId"> string supplier id - this is string beacause external supllier id can be anything</param>
        /// <returns></returns>
        public ExternalInvoice[] GetInvoices(string supplierId)
        {
            int numberofyears = 2;
            if (int.Parse(supplierId) > 2)
                throw new Exception("Custom Error :  Web Timeout Exception");

            IList<ExternalInvoice> result = new List<ExternalInvoice>();
            // Genrate fake data for year and total amount 
            for (int i = 0; i < numberofyears; i++)
            {
                result.Add(new ExternalInvoice() { Year = 2000+ i, TotalAmount = 1000 });
            }
            
            return result.ToArray();
        }
    }
}
