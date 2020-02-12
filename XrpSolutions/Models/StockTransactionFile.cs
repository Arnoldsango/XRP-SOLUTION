using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace XrpSolutions.Models
{
    public class StockTransactionFile
    {
        [Key]
        public int StockTransactionId { get; set; }
        [Required(ErrorMessage = "Document Number is required")]
        public int DocumentNo { get; set; }
        [Required(ErrorMessage = "Stock Code is required")]
        public int StockCode { get; set; }
        [Required(ErrorMessage = "date is required")]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }
        [Required(ErrorMessage = "Transation Type  is required")]

        public string TransactionType { get; set; }
        [Required(ErrorMessage = "Quantity is required")]

        public string Qty { get; set; }
        [Required(ErrorMessage = "Unit Cost is required")]

        public string UnitCost { get; set; }
        [Required(ErrorMessage = "Unit Sell is required")]

        public string UnitSell { get; set; }

        [ForeignKey("StockCode")]
        public virtual StockMaster Stock { get; set; }
    }
}