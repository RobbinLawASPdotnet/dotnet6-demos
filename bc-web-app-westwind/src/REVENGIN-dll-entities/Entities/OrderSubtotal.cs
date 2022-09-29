﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    [Keyless]
    public partial class OrderSubtotal
    {
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column(TypeName = "money")]
        public decimal? Subtotal { get; set; }
    }
}
