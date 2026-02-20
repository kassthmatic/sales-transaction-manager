using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PMSLibrary.Models;

[Table("product")]
public partial class Product
{
    [Key]
    [Column("code")]
    [StringLength(7)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("inventory")]
    public int Inventory { get; set; }

    [Column("price", TypeName = "decimal(18, 0)")]
    public decimal Price { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<SalesTransaction> SalesTransactions { get; set; } = new List<SalesTransaction>();
}
