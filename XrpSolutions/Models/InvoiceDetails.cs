using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XrpSolutions.Models
{
    public class InvoiceDetails
    {
        [Key]
        public int InvoiceDetailsID { get; set; }

        [Required(ErrorMessage = "Intem Number is Required")]
        public int ItemNo { get; set; }

        [Required(ErrorMessage = "Invoice Number is Required")]
        public int InvoiceNo { get; set; }

        [Required(ErrorMessage = "Stock Code is Description")]
       
        public int StockCode { get; set; }

        [Required(ErrorMessage = "Quantity Sold is Required")]

        public int QtySold { get; set; }
        [Required(ErrorMessage = "Unit Cost is Required")]
        public double UnitCost { get; set; }
        [Required(ErrorMessage = "Unit Sell is Required")]
        public double UnitSell { get; set; }
        [Required(ErrorMessage = "Discount is Required")]

        
        public double Disc { get; set; }

        public double Total { get; set; }

        [ForeignKey("ItemNo")]
        public virtual InvoiceHeader InvoiceHeader { get; set; }
        [ForeignKey("StockCode")]
        public virtual StockMaster StockMaster { get; set; }
    }
}