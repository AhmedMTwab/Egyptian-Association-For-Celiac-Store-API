using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("Drug", "RecordId")]
[Table("medical_record-drug")]
public partial class MedicalRecordDrug
{
    [Column("drug")]
    [StringLength(50)]
    [Unicode(false)]
    public string Drug { get; set; } = null!;

    [Column("record_id")]
    public int RecordId { get; set; }

    [ForeignKey("RecordId")]
    public virtual MedicalRecord Record { get; set; } = null!;
}
