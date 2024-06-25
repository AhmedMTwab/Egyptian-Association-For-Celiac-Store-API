using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("ClinicId", "DoctorId")]
[Table("doctor_clinic_work")]
public partial class DoctorClinicWork
{
    [Column("clinic_id")]
    public int ClinicId { get; set; }

    [Column("doctor_id")]
    public int DoctorId { get; set; }
    [Column("arrive_time")]
    public TimeOnly ArriveTime { get; set; }

    [Column("leave_time")]
    public TimeOnly LeaveTime { get; set; }

    [ForeignKey("ClinicId")]
    public virtual Clinic Clinic { get; set; } = null!;

    [ForeignKey("DoctorId")]
    public virtual Doctor Doctor { get; set; } = null!;
}
