using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("PhoneNumber", "HospitalId")]
[Table("hospital_phone")]
public partial class HospitalPhone
{
    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [Column("hospital_id")]
    public int HospitalId { get; set; }

    [ForeignKey("HospitalId")]
    public virtual Hospital Hospital { get; set; } = null!;
}