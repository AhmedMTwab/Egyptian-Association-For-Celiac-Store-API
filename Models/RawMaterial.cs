using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Table("raw_material")]
public partial class RawMaterial
{
    [Key]
    [Column("material_id")]
    public int MaterialId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("details", TypeName = "text")]
    public string Details { get; set; } = null!;

    [Column("price", TypeName = "money")]
    public decimal Price { get; set; }


    [InverseProperty("Material")]
    public virtual ICollection<RawMaterialImage> Images { get; set; } = new List<RawMaterialImage>();

    [InverseProperty("Material")]
    public virtual ICollection<DisesMaterialCatogrize> dises { get; set; } = new List<DisesMaterialCatogrize>();

    [InverseProperty("Material")]
    public virtual ICollection<PatientRawmaterialVeiw> patients { get; set; } = new List<PatientRawmaterialVeiw>();
}
