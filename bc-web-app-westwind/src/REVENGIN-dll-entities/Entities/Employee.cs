using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    [Index(nameof(LastName), Name = "LastName")]
    [Index(nameof(AddressId), Name = "UX_Employees_AddressID", IsUnique = true)]
    public partial class Employee
    {
        public Employee()
        {
            InverseReportsToNavigation = new HashSet<Employee>();
            Orders = new HashSet<Order>();
            Territories = new HashSet<Territory>();
        }

        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }
        [StringLength(25)]
        public string TitleOfCourtesy { get; set; }
        [StringLength(30)]
        public string JobTitle { get; set; }
        public int? ReportsTo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime HireDate { get; set; }
        [StringLength(24)]
        public string OfficePhone { get; set; }
        [StringLength(4)]
        public string Extension { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        [Column("AddressID")]
        public int AddressId { get; set; }
        [Required]
        [StringLength(24)]
        public string HomePhone { get; set; }
        public byte[] Photo { get; set; }
        [StringLength(40)]
        public string PhotoMimeType { get; set; }
        [Column(TypeName = "ntext")]
        public string Notes { get; set; }
        public bool? Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TerminationDate { get; set; }
        public bool OnLeave { get; set; }
        [StringLength(80)]
        public string LeaveReason { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReturnDate { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Employee")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(ReportsTo))]
        [InverseProperty(nameof(Employee.InverseReportsToNavigation))]
        public virtual Employee ReportsToNavigation { get; set; }
        [InverseProperty(nameof(Employee.ReportsToNavigation))]
        public virtual ICollection<Employee> InverseReportsToNavigation { get; set; }
        [InverseProperty(nameof(Order.SalesRep))]
        public virtual ICollection<Order> Orders { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty(nameof(Territory.Employees))]
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
