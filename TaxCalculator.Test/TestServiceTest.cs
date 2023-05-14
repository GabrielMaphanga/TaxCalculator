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

            };

            // Act
           var calculated= _taxCalculatorService.CalculateProgressiveTax(newInput);

            // Assert
            //Assert.w(newEntity, _entities);
        }

        [Test]
        public void Can_Calcualte_Flat_Value_Tax()
        {
            // Arrange
            var newInput = new IndividualInput
            {

            };

            // Act
            var calculated = _taxCalculatorService.CalculateFlatValueTax(newInput);

            // Assert
            //Assert.w(newEntity, _entities);
        }
        [Test]
        public void Can_Calcualte_Flat_rate_Tax()
        {
            // Arrange
            var newInput = new IndividualInput
            {

            };

            // Act
            var calculated = _taxCalculatorService.CalculateFlatrateTax(newInput);

            // Assert
            //Assert.w(newEntity, _entities);
        }
        [Test]
        public void Can_Calcualte_ProGressive_Tax()
        {
            // Arrange
            var newInput = new IndividualInput
            {

            };

            // Act
            var calculated = _taxCalculatorService.CalculateProGressiveTax(newInput);

            // Assert
            //Assert.w(newEntity, _entities);
        }
    }
}