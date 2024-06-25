using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("DisesId", "ProductId")]
[Table("dises_product_catogrize")]
public partial class DisesProductCatogrize
{
    [Column("dises_id")]
    public int DisesId { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("catogert_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string CatogertName { get; set; } = null!;

    [ForeignKey("DisesId")]
    public virtual Dises Dises { get; set; } = null!;

    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; } = null!;
}
