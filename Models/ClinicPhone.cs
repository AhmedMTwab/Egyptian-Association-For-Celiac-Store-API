using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("PhoneNumber", "ClinicId")]
[Table("clinic_phone")]
public partial class ClinicPhone
{
    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [Column("clinic_id")]
    public int ClinicId { get; set; }

    [ForeignKey("ClinicId")]
    public virtual Clinic Clinic { get; set; } = null!;
}
