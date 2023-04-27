using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Entities
{
    [Table("Programs")]
    public class Program
    {
        [Key]
        [Column("ProgramID")]
        public int ProgramId { get; set; }
        [Required(ErrorMessage = "You must supply a program name")]
        [StringLength(100)]
        public string ProgramName { get; set; }
        [StringLength(100)]
        public string DiplomaName { get; set; }
        [Required(ErrorMessage = "You must supply a school code")]
        [StringLength(10)]
        public string SchoolCode { get; set; }
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "You must supply a tuition")]
        public decimal Tuition { get; set; }
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "You must supply an international tuition")]
        public decimal InternationalTuition { get; set; }

        [ForeignKey(nameof(SchoolCode))]
		[InverseProperty("Programs")]
		public virtual School School { get; set; }
    }
}
