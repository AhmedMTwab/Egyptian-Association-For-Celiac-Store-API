using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Table("hospital")]
public partial class Hospital
{
    [Key]
    [Column("hospital_id")]
    public int HospitalId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;


    [InverseProperty("Hospital")]
    public virtual ICollection<HospitalInsuranceDiscount> insurances { get; set; } = new List<HospitalInsuranceDiscount>();
    [InverseProperty("Hospital")]
    public virtual ICollection<HospitalAddress> addresses { get; set; } = new List<HospitalAddress>();
    [InverseProperty("Hospital")]
    public virtual ICollection<HospitalPhone> PhoneNumbers { get; set; } = new List<HospitalPhone>();
    [InverseProperty("Hospital")]
    public virtual ICollection<HospitalType> types { get; set; } = new List<HospitalType>();
}