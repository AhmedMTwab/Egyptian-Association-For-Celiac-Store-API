using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Table("product")]
public partial class Product
{
    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("details", TypeName = "text")]
    public string Details { get; set; } = null!;

    [Column("price", TypeName = "money")]
    public decimal Price { get; set; }
    [Column("CartId")]
    public int? CartId { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();

    [InverseProperty("Product")]
    public virtual ICollection<DisesProductCatogrize> dises { get; set; } = new List<DisesProductCatogrize>();

    [InverseProperty("Product")]
    public virtual ICollection<PatientProductView> patients { get; set; } = new List<PatientProductView>();
    [ForeignKey("CartId")]
    [InverseProperty("Products")]
    public virtual Cart? Cart { get; set; }


}
