using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("PhoneNumber", "AssosiationId")]
[Table("assosiation_branch_phone")]
public partial class AssosiationBranchPhone
{
    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [Column("assosiation_id")]
    public int AssosiationId { get; set; }

    [ForeignKey("AssosiationId")]
    public virtual AssosiationBranch Assosiation { get; set; } = null!;
}
