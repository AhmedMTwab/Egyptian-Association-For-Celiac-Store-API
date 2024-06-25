using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("PharmacyId", "AssosiationId")]
[Table("pharmacy_assosiation_discount")]
public partial class PharmacyAssosiationDiscount
{
    [Column("pharmacy_id")]
    public int PharmacyId { get; set; }

    [Column("assosiation_id")]
    public int AssosiationId { get; set; }

    [Column("discount_precentage")]
    public double DiscountPrecentage { get; set; }

    [ForeignKey("AssosiationId")]
    public virtual AssosiationBranch Assosiation { get; set; } = null!;

    [ForeignKey("PharmacyId")]
    public virtual Pharmacy Pharmacy { get; set; } = null!;
}
