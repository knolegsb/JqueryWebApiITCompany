using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JqueryWebApiITCompany.Models
{
    public class Company
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Rank { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Industry { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999.99)]
        public Decimal Revenue { get; set; }

        [Required]
        //[RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year")]
        [Display(Name = "Year")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FiscalYear { get; set; }

        [Required]
        [DisplayFormat(DataFormatString="{0:N}")]
        public int Employees { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999.99)]
        [Display(Name = "Market Cap")]
        public Decimal MarketCap { get; set; }

        [Required]
        public string Headquarters { get; set; }
    }
}