using System;
using System.Collections.Generic;
using System.Text;
using TaxCalulator.Core.Entities;

namespace TaxCalulator.Core.Interfaces
{
    public interface ITaxCalculatorRepository
    {
        CalculatedAnnualTax GetCalculatedAnnualTax(int calculatedAnnualTaxId);
        List<CalculatedAnnualTax> GetCalculatedAnnualTaxes();
        bool DeleteCalculatedAnnualTax(int calculatedAnnualTaxId);
        CalculatedAnnualTax UpdateCalculatedAnnualTax(CalculatedAnnualTax  calculatedAnnualTax);
        bool CreateCalculatedAnnualTax(CalculatedAnnualTax calculatedAnnualTax);

       // CalculatedAnnualTax Find(int movieId);
    }
}
