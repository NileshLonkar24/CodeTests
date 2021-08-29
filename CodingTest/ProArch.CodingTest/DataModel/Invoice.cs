using System;

namespace ProArch.CodingTest.DataModel
{
    /// <summary>
    /// Data Model for :- Invoice
    /// Class name :- Invoice
    /// Date :- 29th Aug 2021
    /// Author :- Nilesh Lonkar
    /// </summary>
    public class Invoice
    {
        public int SupplierId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal Amount { get; set; }
    }
}
