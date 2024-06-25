using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Table("dises")]
public partial class Dises
{
    [Key]
    [Column("dises_id")]
    public int DisesId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Dises")]
    public virtual ICollection<DisesProductCatogrize> Products { get; set; } = new List<DisesProductCatogrize>();

    [InverseProperty("Dises")]
    public virtual ICollection<DisesMaterialCatogrize> Materials { get; set; } = new List<DisesMaterialCatogrize>();

    [InverseProperty("Dises")]
    public virtual ICollection<PatientDisesHave> patients { get;}=new List<PatientDisesHave>();

    [InverseProperty("Dises")]
    public virtual ICollection<AssosiationDisesFollow> Branches { get; set; } = new List<AssosiationDisesFollow>();
}
