using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("HospitalId", "InsuranceId")]
[Table("hospital_insurance_discount")]
public partial class HospitalInsuranceDiscount
{
    [Column("hospital_id")]
    public int HospitalId { get; set; }

    [Column("insurance_id")]
    public int InsuranceId { get; set; }

    [Column("discount_precentage")]
    public double DiscountPrecentage { get; set; }

    [ForeignKey("HospitalId")]
    public virtual Hospital Hospital { get; set; } = null!;

    [ForeignKey("InsuranceId")]
    public virtual HealthInsurance Insurance { get; set; } = null!;
   
}