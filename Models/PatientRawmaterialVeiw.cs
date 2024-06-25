using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("PatientId", "MaterialId")]
[Table("patient_rawmaterial_veiw")]
public partial class PatientRawmaterialVeiw
{
    [Column("patient_id")]
    public int PatientId { get; set; }

    [Column("material_id")]
    public int MaterialId { get; set; }

    [ForeignKey("MaterialId")]
    public virtual RawMaterial Material { get; set; } = null!;

    [ForeignKey("PatientId")]
    public virtual Patient Patient { get; set; } = null!;
}
