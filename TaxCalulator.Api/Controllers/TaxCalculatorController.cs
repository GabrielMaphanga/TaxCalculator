using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalulator.Core.Entities;
using TaxCalulator.Core.Enums;
using TaxCalulator.Core.Interfaces;

namespace TaxCalulator.Api.Controllers
{
    [ApiController]
    public class TaxCalculatorController : ControllerBase
    {
        private ITaxCalculatorService _taxCalculatorService;
        private ITaxCalculatorRepository  _taxCalculatorRepository;

        public TaxCalculatorController(ITaxCalculatorRepository taxCalculatorRepository, ITaxCalculatorService taxCalculatorService)
        {
            _taxCalculatorRepository = taxCalculatorRepository;
            _taxCalculatorService = taxCalculatorService;
        }

        /// <summary>
        /// Creates the calculate annual tax
        /// </summary>
        /// <param name="individualInput">The individual input.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateAndCalculate")]
        public ActionResult<CalculatedAnnualTax> CreateCalculated([FromBody] IndividualInput individualInput)
        {
            CalculatedAnnualTax calculatedAnnualTax = new CalculatedAnnualTax();
           if(individualInput.PostalCodeValue == PostalCode.FlatRate)
            {
                calculatedAnnualTax = _taxCalculatorService.CalculateFlatrateTax(individualInput);
            }
            if (individualInput.PostalCodeValue == PostalCode.FlatValue)
            {
                calculatedAnnualTax = _taxCalculatorService.CalculateFlatValueTax(individualInput);
            }
            if (individualInput.PostalCodeValue == PostalCode.Progressive)
            {
                calculatedAnnualTax = _taxCalculatorService.CalculateProgressiveTax(individualInput);
            }
            if (individualInput.PostalCodeValue == PostalCode.ProGressive)
            {
                calculatedAnnualTax = _taxCalculatorService.CalculateProGressiveTax(individualInput);
            }

           var dbrepsonse = _taxCalculatorRepository.CreateCalculatedAnnualTax(calculatedAnnualTax);

            if(dbrepsonse == true)
            {
               return calculatedAnnualTax;

            }

            return BadRequest();
        }
        /// <summary>
        /// Gets the calculated annual taxes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public List<CalculatedAnnualTax> GetCalculatedAnnualTaxes()
        {
            return _taxCalculatorRepository.GetCalculatedAnnualTaxes();
        }

        /// <summary>
        /// Gets the calculated annual tax.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
       [HttpGet]
        [Route("Get/{id}")]
        public CalculatedAnnualTax GetCalculatedAnnualTax(int id)
        {
            return _taxCalculatorRepository.GetCalculatedAnnualTax(id);
        }



        /// <summary>
        /// Deletes the calculated annual tax.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteCalculatedAnnualTax(int id)
        {
            _taxCalculatorRepository.DeleteCalculatedAnnualTax(id);
        }

        /// <summary>
        /// Updates the calculated annual tax.
        /// </summary>
        /// <param name="calculatedAnnualTax">The calculated annual tax.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        public CalculatedAnnualTax UpdateCalculatedAnnualTax([FromBody] CalculatedAnnualTax calculatedAnnualTax)
        {
           return  _taxCalculatorRepository.UpdateCalculatedAnnualTax(calculatedAnnualTax);
        }


    }
}
