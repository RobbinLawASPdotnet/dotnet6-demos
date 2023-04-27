using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Entities
{
    [Table("Schools")]
    public class School
    {
        [Key]
        [Required(ErrorMessage = "You must supply a school code")]
        [StringLength(10)]
        public string SchoolCode { get; set; }
        [Required(ErrorMessage = "You must supply a school name")]
        [StringLength(50)]
        public string SchoolName { get; set; }

        [InverseProperty(nameof(Program.School))]
		public virtual ICollection<Program> Programs { get; set; }
    }
}
