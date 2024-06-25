using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Table("clinic")]
public partial class Clinic
{
    [Key]
    [Column("clinic_id")]
    public int ClinicId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("open_time")]
    public TimeOnly OpenTime { get; set; }

    [Column("close_time")]
    public TimeOnly CloseTime { get; set; }
    [InverseProperty("Clinic")]
    public virtual ICollection<DoctorClinicWork> Doctors { get; set; } = new List<DoctorClinicWork>();
    [InverseProperty("Clinic")]
    public virtual ICollection<ClinicPhone> clinicphones { get; set; } = new List<ClinicPhone>();
    [InverseProperty("Clinic")]
    public virtual ICollection<ClinicAddress> clinicaddreses { get; set; } = new List<ClinicAddress>();
    [InverseProperty("Clinic")]
    public virtual ICollection<Reservation> patients { get; set; } = new List<Reservation>();
    [InverseProperty("Clinic")]
    public virtual ICollection<ClinicAssosiationDiscount> branches { get; set; } = new List<ClinicAssosiationDiscount>();
    [InverseProperty("Clinic")]
    public virtual ICollection<ClinicInsuranceDiscount> insurences { get; set; } = new List<ClinicInsuranceDiscount>();
}

