using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ViewModels
{

    public class ProductList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Supplier { get; set; }
        public string Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public short? MinimumOrderQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsOnOrder { get; set; }
        public bool Discontinued { get; set; }
    }
}
