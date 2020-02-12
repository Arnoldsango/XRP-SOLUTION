using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace XrpSolutions.Models
{
    public class DebtorTransactionFile
    {
        [Key]
        public int DbTransactionId { get; set; }
        [Required(ErrorMessage = "Document Number is Required")]
        public int DocumentNo { get; set; }
        [Required(ErrorMessage = "Document Number is Required")]
        public int AccountCode { get; set; }
        [Required(ErrorMessage = "Date is Required")]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }
        [Required(ErrorMessage = "Transaction Type is Required")]
        public string TransactionType { get; set; }

        [Required(ErrorMessage = "Gross Transaction Value is Required")]
        public double GrossTransactionValue { get; set; }

        [Required(ErrorMessage = "Input a whole number"), Range(minimum:0, maximum:100)]
        public double VatValue { get; set; }

          
        [ForeignKey("AccountCode")]
        public virtual DebtorsMaster DebtorsMaster { get; set; }

        public double VatValueCalc()
        {
            return VatValue / 100;
        }
    }
}