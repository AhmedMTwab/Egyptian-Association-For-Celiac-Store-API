using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Table("doctor")]
public partial class Doctor
{
    [Key]
    [Column("doctor_id")]
    public int DoctorId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("major")]
    [StringLength(50)]
    [Unicode(false)]
    public string Major { get; set; } = null!;

    
    [InverseProperty("Doctor")]
    public virtual ICollection<DoctorPhone> DoctorPhones { get; set; }=new List<DoctorPhone>();
    [InverseProperty("Doctor")]
    public virtual ICollection<DoctorClinicWork> clinics { get; set; } = new List<DoctorClinicWork>();
    [InverseProperty("Doctor")]
    public virtual ICollection<DoctorMedicalrecordVeiw> medicalrecords { get; set; } = new List<DoctorMedicalrecordVeiw>();
}
