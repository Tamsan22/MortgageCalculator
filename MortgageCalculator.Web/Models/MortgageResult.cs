using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MortgageCalculator.Web.Models
{
    public class MortgageResult
    {
        


        public double PrincipalAmount { get; set; }
        public double MonthlyDue { get; set; }
        public double InterestToPay { get; set; }
        public double PrincipalToPay { get; set; }
        public double Outstanding { get; set; }

        
    }
}