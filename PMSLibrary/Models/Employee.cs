using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PMSLibrary.Models;

[Table("employee")]
public partial class Employee
{
    [Key]
    [Column("id")]
    [StringLength(10)]
    [Unicode(false)]
    public string Id { get; set; } = null!;

    [Column("fname")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Fname { get; set; }

    [Column("lname")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Lname { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<SalesTransaction> SalesTransactions { get; set; } = new List<SalesTransaction>();
}
