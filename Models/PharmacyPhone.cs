using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("PhoneNumber", "PharmacyId")]
[Table("pharmacy_phone")]
public partial class PharmacyPhone
{
    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [Column("pharmacy_id")]
    public int PharmacyId { get; set; }

    [ForeignKey("PharmacyId")]
    public virtual Pharmacy Pharmacy { get; set; } = null!;
}