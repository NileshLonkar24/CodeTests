using ProArch.CodingTest.External;
using System;

namespace ProArch.CodingTest.DataModel
{
    /// <summary>
    /// Data Model for :- FailoverInvoiceCollection
    /// Class name :- FailoverInvoiceCollection
    /// Date :- 29th Aug 2021
    /// Author :- Nilesh Lonkar
    /// </summary>
    public class FailoverInvoiceCollection
    {
        public DateTime Timestamp { get; set; }
        public ExternalInvoice[] Invoices { get; set; }

        public FailoverInvoiceCollection()
        {
            this.Invoices = new ExternalInvoice[0];
        }
    }
}