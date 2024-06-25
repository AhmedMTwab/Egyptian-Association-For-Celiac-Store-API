using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Table("assosiation_branch")]
public partial class AssosiationBranch
{
    [Key]
    [Column("assosiation_id")]
    public int AssosiationId { get; set; }

    [Column("open_time")]
    public TimeOnly OpenTime { get; set; }

    [Column("close_time")]
    public TimeOnly CloseTime { get; set; }

    [Column("address")]
    [StringLength(50)]
    [Unicode(false)]
    public string Address { get; set; } = null!;


    [InverseProperty("Assosiation")]
    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    [InverseProperty("Assosiation")]
    public virtual ICollection<ClinicAssosiationDiscount> clinics { get; set; } = new List<ClinicAssosiationDiscount>();

    [InverseProperty("Assosiation")]
    public virtual ICollection<LabAssosiationDiscount> labs { get; set; } = new List<LabAssosiationDiscount>();

    [InverseProperty("Assosiation")]
    public virtual ICollection<PharmacyAssosiationDiscount> pharmacys { get; set; } = new List<PharmacyAssosiationDiscount>();


    [InverseProperty("Assosiation")]
    public virtual ICollection<AssosiationInsuranceProvide> insurances { get; set; } = new List<AssosiationInsuranceProvide>();

    [InverseProperty("Assosiation")]
    public virtual ICollection<AssosiationBranchPhone> PhoneNumbers { get; set; } = new List<AssosiationBranchPhone>();

    [InverseProperty("Assosiation")]
    public virtual ICollection<AssosiationDisesFollow> Dises { get; set; } = new List<AssosiationDisesFollow>();
}
