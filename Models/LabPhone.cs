using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("PhoneNumber", "LabId")]
[Table("lab_phone")]
public partial class LabPhone
{
    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [Column("lab_id")]
    public int LabId { get; set; }

    [ForeignKey("LabId")]
    public virtual Lab Lab { get; set; } = null!;
}