using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("LabId", "InsuranceId")]
[Table("lab_insurance_discount")]
public partial class LabInsuranceDiscount
{
    [Column("lab_id")]
    public int LabId { get; set; }

    [Column("insurance_id")]
    public int InsuranceId { get; set; }

    [Column("discount_precentage")]
    public double DiscountPrecentage { get; set; }

    [ForeignKey("LabId")]
    public virtual Lab Lab { get; set; } = null!;

    [ForeignKey("InsuranceId")]
    public virtual HealthInsurance Insurance { get; set; } = null!;
}
