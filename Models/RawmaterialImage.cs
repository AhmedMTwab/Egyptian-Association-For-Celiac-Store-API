using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("ImagePath", "MaterialId")]
[Table("rawmaterial_image")]
public partial class RawMaterialImage
{
    [Column("material_image")]
    [NotMapped]
    public IFormFile Material_Image { get; set; }

    [Column("image_path")]
    public string ImagePath { get; set; }

    [Column("material_id")]
    public int MaterialId { get; set; }

    [ForeignKey("MaterialId")]
    public virtual RawMaterial Material { get; set; } = null!;
}
