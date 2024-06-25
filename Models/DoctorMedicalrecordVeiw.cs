using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("RecordId", "DoctorId")]
[Table("doctor_medicalrecord_veiw")]
public partial class DoctorMedicalrecordVeiw
{
    [Column("record_id")]
    public int RecordId { get; set; }

    [Column("doctor_id")]
    public int DoctorId { get; set; }

    [ForeignKey("DoctorId")]
    public virtual Doctor Doctor { get; set; } = null!;

    [ForeignKey("RecordId")]
    public virtual MedicalRecord Record { get; set; } = null!;
}
