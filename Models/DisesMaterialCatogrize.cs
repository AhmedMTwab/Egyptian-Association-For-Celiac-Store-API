using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("DisesId", "MaterialId")]
[Table("dises_material_catogrize")]
public partial class DisesMaterialCatogrize
{
    [Column("dises_id")]
    public int DisesId { get; set; }

    [Column("material_id")]
    public int MaterialId { get; set; }

    [Column("catogery_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string CatogeryName { get; set; } = null!;

    [ForeignKey("DisesId")]
    public virtual Dises Dises { get; set; } = null!;

    [ForeignKey("MaterialId")]
    public virtual RawMaterial Material { get; set; } = null!;
}
