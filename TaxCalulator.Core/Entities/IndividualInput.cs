using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaxCalulator.Core.Enums;

namespace TaxCalulator.Core.Entities
{
   public class IndividualInput
    {
        [Required(ErrorMessage = "Please enter annaul income")]
        public Int64 AnnualIncome { get; set; }
        [Required(ErrorMessage = "Please select postal code value")]
        public int PostalCodeValue { get; set; }
    }
}
