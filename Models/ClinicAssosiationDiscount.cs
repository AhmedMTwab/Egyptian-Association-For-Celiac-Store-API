using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("ClinicId", "AssosiationId")]
[Table("clinic_assosiation_discount")]
public partial class ClinicAssosiationDiscount
{
    [Column("clinic_id")]
    public int ClinicId { get; set; }

    [Column("assosiation_id")]
    public int AssosiationId { get; set; }

    [Column("discount_precentage")]
    public double DiscountPrecentage { get; set; }

    [ForeignKey("AssosiationId")]
    public virtual AssosiationBranch Assosiation { get; set; } = null!;

    [ForeignKey("ClinicId")]
    public virtual Clinic Clinic { get; set; } = null!;
}
