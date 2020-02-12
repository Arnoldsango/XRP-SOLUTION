using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XrpSolutions.Models
{
    public class DebtorsMaster
    {
        [Key]
        public int DebtorId { get; set; }

        [Required(ErrorMessage = "Account Code is required")]
        public int AccountCode { get; set; }

        [Required(ErrorMessage = "Address 1.")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Address 2.")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Address 3.")]
        public string Address3 { get; set; }


        //Calculation
        public double CostYearToDate { get; set; }
        public double salesYearToDate { get; set; }
        public double Balance { get; set; }

        //how can you have two ints to make a double?


        public double CalcBalance()
        {
            return Balance = (salesYearToDate - CostYearToDate);
        }

    }
}