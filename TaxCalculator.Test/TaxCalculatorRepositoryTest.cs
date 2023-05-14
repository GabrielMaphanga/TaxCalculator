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
            var calculatedAnnualTax = new CalculatedAnnualTax {  };

            // Act
            _repository.CreateCalculatedAnnualTax(calculatedAnnualTax);

            // Assert
            //Assert.Contains(newEntity, _entities);
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
            //var result = _repository.Read(entityId);
            //Assert.IsNotNull(result);
            //Assert.AreEqual(updatedEntity.Name, result.Name);
        }

        [Test]
        public void _Delete_CalculatedAnnualTax_Should_Remove_CalculatedAnnualTax_From_Repository()
        {
            // Arrange
            var entityId = 3;

            // Act
           _repository.DeleteCalculatedAnnualTax(entityId);

            // Assert
            //var result = _repository.Read(entityId);
           // Assert.IsNull(result);
        }
    }
}
