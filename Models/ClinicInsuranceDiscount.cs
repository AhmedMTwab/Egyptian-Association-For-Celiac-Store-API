using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("ClinicId", "InsuranceId")]
[Table("clinic_insurance_discount")]
public partial class ClinicInsuranceDiscount
{
    [Column("clinic_id")]
    public int ClinicId { get; set; }

    [Column("insurance_id")]
    public int InsuranceId { get; set; }

    [Column("discount_precentage")]
    public double DiscountPrecentage { get; set; }

    [ForeignKey("ClinicId")]
    public virtual Clinic Clinic { get; set; } = null!;

    [ForeignKey("InsuranceId")]
    public virtual HealthInsurance Insurance { get; set; } = null!;
}
