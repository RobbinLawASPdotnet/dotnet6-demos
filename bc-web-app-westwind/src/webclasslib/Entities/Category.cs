﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class Category
    {
        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        [StringLength(40)]
        public string PictureMimeType { get; set; }

        [InverseProperty(nameof(Product.Category))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
