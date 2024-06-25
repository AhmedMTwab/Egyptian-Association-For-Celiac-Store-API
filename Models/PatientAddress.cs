using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;


[Table("patient_address")]
[PrimaryKey("Address","PatientId")]
public partial class PatientAddress
{
    [Column("address")]
    [StringLength(50)]
    [Unicode(false)]

    public string Address { get; set; } = null!;

    [Column("patient_id")]
    [ForeignKey("Patient")]
    public int PatientId { get; set; }
    [InverseProperty("Addresses")]
    public virtual Patient Patient { get; set; } = null!;
}
