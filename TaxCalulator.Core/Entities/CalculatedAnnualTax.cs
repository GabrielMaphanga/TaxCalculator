using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalulator.Core.Entities
{
    public class CalculatedAnnualTax
    {
        public string Id { get; set; }
        public Int64 CalculatedTax { get; set; }
        public Int64 NetPay { get; set; }
        public DateTime DateTime { get; set; }
    }
}
