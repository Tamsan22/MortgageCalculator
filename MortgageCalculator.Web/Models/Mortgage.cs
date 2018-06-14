using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace MortgageCalculator.Web.Models
{
    
    public class Mortgage
    {
        [Key]
        

        public int MortgageId { get; set; }
        [Required]
        public string MortgageType { get; set; }
        [Required]

        public int Interest { get; set; }
        [Required]
        
        public int LoanAmount { get; set; }
        [Required]
        public int TermsInYear { get; set; }


        //public double InterestandPrinciple { get; set;}

        //public double Interesttopay { get; set; }



    }
}