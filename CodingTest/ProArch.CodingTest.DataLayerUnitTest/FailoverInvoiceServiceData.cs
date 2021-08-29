using ProArch.CodingTest.DataModel;
using ProArch.CodingTest.External;
using ProArch.CodingTest.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProArch.CodingTest.DataLayerUnitTest
{
    /// <summary>
    /// This class is to genrate data for testing for Service : FailoverInvoiceService
    /// Class name :- FailoverInvoiceServiceData
    /// Date :- 29th Aug 2021
    /// Author :- Nilesh Lonkar
    /// </summary>
    public class FailoverInvoiceServiceData : IFailoverInvoiceService
    {
        /// <summary>
        /// Get invoices method - Genrate fake data for FailoverInvoiceService it will retrun the FailoverInvoiceCollection 
        /// Supplier wise data 
        /// </summary>
        /// <param name="supplierId"> Superlier id - int</param>
        /// <returns></returns>
        public FailoverInvoiceCollection GetInvoices(int supplierId)
        {
            FailoverInvoiceCollection result = new FailoverInvoiceCollection();
            IList<ExternalInvoice> externallist = new List<ExternalInvoice>();

            switch (supplierId)
            {
                case 2:
                    externallist = new List<ExternalInvoice>();
                    externallist.Add(new ExternalInvoice() { Year = 2021, TotalAmount = 800 }); // Only 1 Year
                    result.Timestamp = DateTime.Now;
                    result.Invoices = externallist.ToArray();
                break;

                case 3:
                    externallist  = new List<ExternalInvoice>();
                    externallist.Add(new ExternalInvoice() { Year = 2021, TotalAmount = 800 }); // Only 1 Year
                    result.Timestamp = DateTime.Now;
                    result.Invoices = externallist.ToArray();
                    break;
                case 4:
                    externallist = new List<ExternalInvoice>();
                    externallist.Add(new ExternalInvoice() { Year = 2020, TotalAmount = 1200 });
                    result.Timestamp = DateTime.Now.AddDays(-32); // Obsolete Date
                    result.Invoices = externallist.ToArray();
                    break;
                default:
                    throw new InvalidOperationException("No Valid supplier in test data");
            }
            return result;
        }
    }
}
