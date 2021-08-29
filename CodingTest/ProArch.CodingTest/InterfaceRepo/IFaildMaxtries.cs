using ProArch.CodingTest.DataModel;
using System;
using System.Collections.Generic;

namespace ProArch.CodingTest.InterfaceRepo
{
    /// <summary>
    /// Interface for the failed request max tries   :- IFaildMaxtries
    /// Class name :- IFaildMaxtries
    /// Date :- 29th Aug 2021
    /// Author :- Nilesh Lonkar
    /// </summary>
    public interface IFaildMaxtries
    {
        int MaxTries { get; }

        int ClosedTimeSeconds { get; }

        int ObsoleteDaysLimit { get; }

        bool IsOpenState { get; set; }

        DateTime FailedTimestamp { get; set; }

        void Reset();

        List<SpendDetail> GetSpendDetail(int supplierId);
    }
}
