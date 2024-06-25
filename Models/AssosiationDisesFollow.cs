using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("DisesId", "AssosiationId")]
[Table("assosiation_dises_follow")]
public partial class AssosiationDisesFollow
{
    [Column("dises_id")]
    public int DisesId { get; set; }

    [Column("assosiation_id")]
    public int AssosiationId { get; set; }

    [ForeignKey("AssosiationId")]
    public virtual AssosiationBranch Assosiation { get; set; } = null!;

    [ForeignKey("DisesId")]
    public virtual Dises Dises { get; set; } = null!;
}
