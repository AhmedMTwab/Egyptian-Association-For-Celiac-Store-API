using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Table("pharmacy")]
public partial class Pharmacy
{
    [Key]
    [Column("pharmacy_id")]
    public int pharmacyId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("open_time")]
    public TimeOnly OpenTime { get; set; }

    [Column("close_time")]
    public TimeOnly CloseTime { get; set; }


    [InverseProperty("Pharmacy")]
    public virtual ICollection<PharmacyInsuranceDiscount> insurances { get; set; } = new List<PharmacyInsuranceDiscount>();
    [InverseProperty("Pharmacy")]
    public virtual ICollection<PharmacyAssosiationDiscount> AssosiationBranches { get; set; } = new List<PharmacyAssosiationDiscount>();
    [InverseProperty("Pharmacy")]
    public virtual ICollection<PharmacyAddress> addresses { get; set; } = new List<PharmacyAddress>();
    [InverseProperty("Pharmacy")]
    public virtual ICollection<PharmacyPhone> PhoneNumbers { get; set; } = new List<PharmacyPhone>();
}