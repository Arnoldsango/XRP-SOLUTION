using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XrpSolutions.Models
{
    public class StockMaster
    {
        [Key]   
        public int StockId { get; set; }

        [Required(ErrorMessage = "Stock Code is required")]
        public int StockCode { get; set; }

        [Required(ErrorMessage = "Stock Description is required")]
        public string StockDescription { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        public double Cost { get; set; }

        [Required(ErrorMessage = "Selling Price is required")]
        public double SellingPrice { get; set; }

        [Required(ErrorMessage = "Quantity Purchased is required")]
        public int QtyPurchased { get; set; }

        [Required(ErrorMessage = "Quantity Sold is required")]
        public int QtySold { get; set; }

        [Required(ErrorMessage = "Stock on Hand is required")]
        public int StockOnHand { get; set; }

        public double TotalPurchasesExclVat { get; set; }
        public double TotalSalesexclvat { get; set; }

        public int StockOnHandCalc()
        {
            StockOnHand += QtyPurchased;
            return StockOnHand;
        }

        public int calcSold()
        {
            StockOnHand = StockOnHand - QtySold;
            return StockOnHand;
        }

    }
}