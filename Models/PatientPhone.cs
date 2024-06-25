using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("PhoneNumber", "PatientId")]
[Table("patient_phone")]
public partial class PatientPhone
{
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    [Column("patient_id")]
    public int? PatientId { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("PhoneNumbers")]
    public virtual Patient? Patient { get; set; }
}
