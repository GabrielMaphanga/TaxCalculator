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

        [HttpPost]
        [Route("Create")]
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

    }
}
