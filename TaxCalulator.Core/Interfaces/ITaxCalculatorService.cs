using System;
using System.Collections.Generic;
using System.Text;
using TaxCalulator.Core.Entities;

namespace TaxCalulator.Core.Interfaces
{
    public interface ITaxCalculatorService
    {
        public CalculatedAnnualTax CalculateProgressiveTax(IndividualInput individualInput);
        public CalculatedAnnualTax CalculateFlatValueTax(IndividualInput individualInput);
        public CalculatedAnnualTax CalculateProGressiveTax(IndividualInput individualInput);
        public CalculatedAnnualTax CalculateFlatrateTax(IndividualInput individualInput);
    }
}
