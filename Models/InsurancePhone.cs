using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("PhoneNumber", "InsuranceId")]
[Table("insurance_phone")]
public partial class InsurancePhone
{
    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [Column("insurance_id")]
    public int InsuranceId { get; set; }

    [ForeignKey("InsuranceId")]
    public virtual HealthInsurance Insurance { get; set; } = null!;
}
