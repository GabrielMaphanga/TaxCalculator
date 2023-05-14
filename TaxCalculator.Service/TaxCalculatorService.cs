using System;
using System.Collections.Generic;
using System.Text;
using TaxCalulator.Core.Entities;
using TaxCalulator.Core.Interfaces;

namespace TaxCalculator.Service
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        public CalculatedAnnualTax CalculateFlatrateTax(IndividualInput individualInput)
        {
            var taxValue = individualInput.AnnualIncome * 0.175;
            var netpay = individualInput.AnnualIncome - taxValue;
            var calculateAnnualTax = new CalculatedAnnualTax
            {
                CalculatedTax = (int)taxValue,
                DateTime = DateTime.Now,
                NetPay = (int)netpay
                
            };
            return calculateAnnualTax;
            
        }

        public CalculatedAnnualTax CalculateFlatValueTax(IndividualInput individualInput)
        {
            var calculateAnnualTax = new CalculatedAnnualTax();
            
            if(individualInput.AnnualIncome < 200000)
            {
                var  taxValue = individualInput.AnnualIncome * 0.05;
                var netpay = individualInput.AnnualIncome - taxValue;
                calculateAnnualTax.CalculatedTax = (int)taxValue;
                calculateAnnualTax.NetPay = (int)netpay;
            }

            return calculateAnnualTax;

        }

        public CalculatedAnnualTax CalculateProgressiveTax(IndividualInput individualInput)
        {
            var calculateAnnualTax = new CalculatedAnnualTax { DateTime = DateTime.Now };
            //10% is the rate
            if(individualInput.AnnualIncome > 0 && individualInput.AnnualIncome <= 8350)
            {
                var taxValue = individualInput.AnnualIncome * 0.10;
                var netpay = individualInput.AnnualIncome - taxValue;
                calculateAnnualTax.CalculatedTax = (int)taxValue;
                calculateAnnualTax.NetPay = (int)netpay;
            }
            //15% is the rate
            if (individualInput.AnnualIncome > 8350 && individualInput.AnnualIncome <= 33951)
            {
                var taxValue = individualInput.AnnualIncome * 0.15;
                var netpay = individualInput.AnnualIncome - taxValue;
                calculateAnnualTax.CalculatedTax = (int)taxValue;
                calculateAnnualTax.NetPay = (int)netpay;
            }
            // 25% is the rate
            if (individualInput.AnnualIncome > 33951 && individualInput.AnnualIncome <= 82250)
            {
                var taxValue = individualInput.AnnualIncome * 0.25;
                var netpay = individualInput.AnnualIncome - taxValue;
                calculateAnnualTax.CalculatedTax = (int)taxValue;
                calculateAnnualTax.NetPay = (int)netpay;
            }
            // 28% is the rate
            if (individualInput.AnnualIncome > 82250 && individualInput.AnnualIncome <= 171550)
            {
                var taxValue = individualInput.AnnualIncome * 0.28;
                var netpay = individualInput.AnnualIncome - taxValue;
                calculateAnnualTax.CalculatedTax = (int)taxValue;
                calculateAnnualTax.NetPay = (int)netpay;
            }

            // 33% is the rate
            if (individualInput.AnnualIncome > 171550 && individualInput.AnnualIncome <= 372950)
            {
                var taxValue = individualInput.AnnualIncome * 0.33;
                var netpay = individualInput.AnnualIncome - taxValue;
                calculateAnnualTax.CalculatedTax = (int)taxValue;
                calculateAnnualTax.NetPay = (int)netpay;
            }
            // 35% is the rate
            if (individualInput.AnnualIncome > 171551 && individualInput.AnnualIncome <= 372950)
            {
                var taxValue = individualInput.AnnualIncome * 0.35;
                var netpay = individualInput.AnnualIncome - taxValue;
                calculateAnnualTax.CalculatedTax = (int)taxValue;
                calculateAnnualTax.NetPay = (int)netpay;

            }


            return calculateAnnualTax;

        }

        public CalculatedAnnualTax CalculateProGressiveTax(IndividualInput individualInput)
        {
            return CalculateProgressiveTax(individualInput);
        }
    }
}
