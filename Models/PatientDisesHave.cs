using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("PatientId","DisesId")]
[Table("patient_dises-have")]
public partial class PatientDisesHave
{
    [Column("patient_id")]
    public int PatientId { get; set; }

    [Column("dises_id")]
    public int DisesId { get; set; }

    [ForeignKey("DisesId")]
    [InverseProperty("patients")]
    public virtual Dises Dises { get; set; } = null!;

    [ForeignKey("PatientId")]
    [InverseProperty("Diseses")]
    public virtual Patient Patient { get; set; } = null!;
}
