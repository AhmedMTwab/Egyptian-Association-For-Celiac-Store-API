using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Table("lab")]
public partial class Lab
{
    [Key]
    [Column("lab_id")]
    public int LabId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("open_time")]
    public TimeOnly OpenTime { get; set; }

    [Column("close_time")]
    public TimeOnly CloseTime { get; set; }


    [InverseProperty("Lab")]
    public virtual ICollection<LabInsuranceDiscount> insurances { get; set; } = new List<LabInsuranceDiscount>();
    [InverseProperty("Lab")]
    public virtual ICollection<LabAssosiationDiscount> AssosiationBranches { get; set; } = new List<LabAssosiationDiscount>();
    [InverseProperty("Lab")]
    public virtual ICollection<LabAddress> addresses { get; set; } = new List<LabAddress>();
    [InverseProperty("Lab")]
    public virtual ICollection<LabPhone> PhoneNumbers { get; set; } = new List<LabPhone>();
    [InverseProperty("Lab")]
    public virtual ICollection<LabType> types { get; set; } = new List<LabType>();
}