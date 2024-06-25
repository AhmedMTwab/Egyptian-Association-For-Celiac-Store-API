using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("PharmacyId", "InsuranceId")]
[Table("pharmacy_insurance_discount")]
public partial class PharmacyInsuranceDiscount
{
    [Column("Pharmacy_id")]
    public int PharmacyId { get; set; }

    [Column("insurance_id")]
    public int InsuranceId { get; set; }

    [Column("discount_precentage")]
    public double DiscountPrecentage { get; set; }

    [ForeignKey("PharmacyId")]
    public virtual Pharmacy Pharmacy { get; set; } = null!;

    [ForeignKey("InsuranceId")]
    public virtual HealthInsurance Insurance { get; set; } = null!;
}
