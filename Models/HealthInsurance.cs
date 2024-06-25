using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Table("health_insurance")]
public partial class HealthInsurance
{
    [Key]
    [Column("insurance_id")]
    public int InsuranceId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public int LicenseCode { get; set; }

    [InverseProperty("Insurance")]
    public virtual ICollection<ClinicInsuranceDiscount> clinics { get; set; } = new List<ClinicInsuranceDiscount>();
    [InverseProperty("Insurance")]
    public virtual ICollection<LabInsuranceDiscount> labs { get; set; } = new List<LabInsuranceDiscount>();
    [InverseProperty("Insurance")]
    public virtual ICollection<PharmacyInsuranceDiscount> pharmacys { get; set; } = new List<PharmacyInsuranceDiscount>();
    [InverseProperty("Insurance")]
    public virtual ICollection<HospitalInsuranceDiscount> hospitals { get; set; } = new List<HospitalInsuranceDiscount>();
    [InverseProperty("Insurance")]
    public virtual ICollection<AssosiationInsuranceProvide> AssosiationBranches { get; set; } = new List<AssosiationInsuranceProvide>();
    [InverseProperty("Insurance")]
    public virtual ICollection<InsuranceAddress> addresses { get; set; } = new List<InsuranceAddress>();
    [InverseProperty("Insurance")]
    public virtual ICollection<InsurancePhone> PhoneNumbers { get; set; } = new List<InsurancePhone>();
}
