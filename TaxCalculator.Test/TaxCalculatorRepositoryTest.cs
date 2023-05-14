using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.Infrastructure.Data;
using TaxCalulator.Core.Entities;
using TaxCalulator.Core.Interfaces;

namespace TaxCalculator.Test
{
    public class TaxCalculatorRepositoryTest
    {
        private ITaxCalculatorRepository _repository;
        private readonly IConfiguration _config;
        [SetUp]
        public void Setup()
        {
            _repository = new TaxCalculatorRepository(_config);
        }

        [Test]
        public void Create_CalculatedAnnualTax_Should_Add_Entity_To_Repository()
        {
            // Arrange
            var newCalculatedAnnualTax = new CalculatedAnnualTax { CalculatedTax = 3500, NetPay= 66500, DateTime= DateTime.Now };

            // Act
            _repository.CreateCalculatedAnnualTax(newCalculatedAnnualTax);
            var _calculatedAnnualTaxes = _repository.GetCalculatedAnnualTaxes();

            // Assert
            Assert.Contains(newCalculatedAnnualTax, _calculatedAnnualTaxes);
        }

        [Test]
        public void Can_Get_CalculatedAnnual_Tax_From_Repository()
        {
            // Arrange
            var entityId = 1;

            // Act
            var result = _repository.GetCalculatedAnnualTax(entityId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(entityId, result.Id);
        }

        [Test]
        public void Update_CalculatedAnnualTax_Should_Modify_Entity_In_Repository()
        {
            // Arrange
            var entityId = 2;
           var updatedCalculatedAnnualTax = new CalculatedAnnualTax {  };

            // Act
            _repository.UpdateCalculatedAnnualTax(updatedCalculatedAnnualTax);

            // Assert
            var result = _repository.GetCalculatedAnnualTax(entityId);
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedCalculatedAnnualTax.CalculatedTax, result.CalculatedTax);
        }

        [Test]
        public void Delete_CalculatedAnnualTax_Should_Remove_CalculatedAnnualTax_From_Repository()
        {
            // Arrange
            var entityId = 3;

            // Act
           _repository.DeleteCalculatedAnnualTax(entityId);

            // Assert
            var result = _repository.GetCalculatedAnnualTax(entityId);
            Assert.IsNull(result);
        }
    }
}
