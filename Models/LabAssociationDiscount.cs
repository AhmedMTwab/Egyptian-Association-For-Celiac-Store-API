using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("LabId", "AssosiationId")]
[Table("lab_assosiation_discount")]
public partial class LabAssosiationDiscount
{
    [Column("lab_id")]
    public int LabId { get; set; }

    [Column("assosiation_id")]
    public int AssosiationId { get; set; }

    [Column("discount_precentage")]
    public double DiscountPrecentage { get; set; }

    [ForeignKey("AssosiationId")]
    public virtual AssosiationBranch Assosiation { get; set; } = null!;

    [ForeignKey("LabId")]
    public virtual Lab Lab { get; set; } = null!;
}
