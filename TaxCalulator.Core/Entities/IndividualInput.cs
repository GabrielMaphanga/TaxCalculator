using System;
using System.Collections.Generic;
using System.Text;
using TaxCalulator.Core.Enums;

namespace TaxCalulator.Core.Entities
{
   public class IndividualInput
    {
        public Int64 AnnualIncome { get; set; }
        public int PostalCodeValue { get; set; }
    }
}
