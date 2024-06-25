using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("Address", "InsuranceId")]
[Table("insurance_address")]
public partial class InsuranceAddress
{
    [Column("address")]
    [StringLength(50)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [Column("insurance_id")]
    public int InsuranceId { get; set; }

    [ForeignKey("InsuranceId")]
    public virtual HealthInsurance Insurance { get; set; } = null!;
}
