using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XrpSolutions.Models
{
    public class InvoiceHeader
    {

        [Key]
        [Required(ErrorMessage = "Invoice number required.")]
        [Display(Name = "Invoice NUmber")]
        public int InvoiceNo { get; set; }
        [Required(ErrorMessage = "Account Account Code")]
        public int AccountCode { get; set; }

        [Required(ErrorMessage = "Date")]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }
        public double Vat { get; set; }

        public double TotalSellexclVat { get; set; }
        public double TotalCost { get; set; }

        public virtual DebtorsMaster DebtorsMaster{ get; set; }
    }
}