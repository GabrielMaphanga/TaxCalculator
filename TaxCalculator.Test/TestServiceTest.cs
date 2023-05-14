using NUnit.Framework;
using TaxCalculator.Service;
using TaxCalulator.Core.Entities;
using TaxCalulator.Core.Interfaces;

namespace TaxCalculator.Test
{
    public class TestServiceTest

    {
        private ITaxCalculatorService _taxCalculatorService;
        [SetUp]
        public void Setup()
        {
            _taxCalculatorService = new TaxCalculatorService();
        }

        [Test]
        public void Can_Calcualte_Progressive_Tax()
        {
            // Arrange
            var newInput = new IndividualInput
            {
                AnnualIncome = 80000,
                PostalCodeValue = 100
            };
            var expectedAnswer = new CalculatedAnnualTax
            {
                CalculatedTax = 20000,
                NetPay = 60000

            };

            // Act
            var calculated = _taxCalculatorService.CalculateFlatValueTax(newInput);

            // Assert
            Assert.Equals(calculated.CalculatedTax, expectedAnswer.CalculatedTax);
        }

        [Test]
        public void Can_Calcualte_Flat_Value_Tax()
        {
            // Arrange
            var newInput = new IndividualInput
            {
                AnnualIncome = 80000,
                PostalCodeValue = 7000
            };
            var expectedAnswer = new CalculatedAnnualTax
            {
                CalculatedTax = 2000,
                NetPay = 60000

            };

            // Act
            var calculated = _taxCalculatorService.CalculateFlatValueTax(newInput);

            // Assert
            Assert.Equals(calculated.CalculatedTax, expectedAnswer.CalculatedTax);
        }
        [Test]
        public void Can_Calcualte_Flat_rate_Tax()
        {
            // Arrange
            var newInput = new IndividualInput
            {
                AnnualIncome = 80000,
                PostalCodeValue = 100
            };
            var expectedAnswer = new CalculatedAnnualTax
            {
                CalculatedTax = 14000,
                NetPay = 66000

            };

            // Act
            var calculated = _taxCalculatorService.CalculateFlatrateTax(newInput);

            // Assert
            Assert.Equals(calculated.CalculatedTax, expectedAnswer.CalculatedTax);
        }
        [Test]
        public void Can_Calcualte_ProGressive_Tax()
        {
            // Arrange
            var newInput = new IndividualInput
            {
                AnnualIncome = 80000,
                PostalCodeValue = 1000
            };
            var expectedAnswer = new CalculatedAnnualTax
            {
                CalculatedTax = 20000,
                NetPay = 60000
            };

            // Act
            var calculated = _taxCalculatorService.CalculateProGressiveTax(newInput);

            // Assert
            Assert.Equals(calculated.CalculatedTax, expectedAnswer.CalculatedTax);
        }
    }
}