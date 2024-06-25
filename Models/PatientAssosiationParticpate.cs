using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Keyless]
[Table("patient_assosiation_particpate")]
public partial class PatientAssosiationParticpate
{
    [Column("patient_id")]
    public int PatientId { get; set; }

    [Column("assosiation_id")]
    public int AssosiationId { get; set; }

    [Column("start_date")]
    public DateOnly StartDate { get; set; }

    [Column("end_date")]
    public DateOnly EndDate { get; set; }

    [ForeignKey("AssosiationId")]
    public virtual AssosiationBranch Assosiation { get; set; } = null!;

    [ForeignKey("PatientId")]
    public virtual Patient Patient { get; set; } = null!;
}
