using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("ProductId", "ImagePath")]
[Table("product_image")]
public partial class ProductImage
{
    [Column("product_image")]
    [NotMapped]
    public IFormFile Product_Image { get; set; }

    [Column("image_path")]
    public string ImagePath { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; } = null!;
}
