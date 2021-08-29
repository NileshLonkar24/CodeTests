using System.Collections.Generic;

namespace ProArch.CodingTest.DataModel
{
    /// <summary>
    /// Data Model for :- SpendSummary
    /// Class name :- SpendSummary
    /// Date :- 29th Aug 2021
    /// Author :- Nilesh Lonkar
    /// </summary>
    public class SpendSummary
    {
        public string Name { get; set; }

        public List<SpendDetail> Years { get; set; }
    }
}