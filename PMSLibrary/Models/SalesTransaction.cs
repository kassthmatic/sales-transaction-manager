using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PMSLibrary.Models;

[PrimaryKey("EmployeeId", "ProductCode", "SaleDate")]
[Table("salesTransaction")]
public partial class SalesTransaction
{
    [Key]
    [Column("Employee_Id")]
    [StringLength(10)]
    [Unicode(false)]
    public string EmployeeId { get; set; } = null!;

    [Key]
    [Column("product_code")]
    [StringLength(7)]
    [Unicode(false)]
    public string ProductCode { get; set; } = null!;

    [Column("amount")]
    public int Amount { get; set; }

    [Key]
    [Column("saleDate", TypeName = "datetime")]
    public DateTime SaleDate { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("SalesTransactions")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("ProductCode")]
    [InverseProperty("SalesTransactions")]
    public virtual Product Product { get; set; } = null!;
}
