using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("RecordId", "TestsPath")]
[Table("medical_record-test")]
public partial class MedicalRecordTest
{
    [Column("test")]
    [MaxLength(50)]
    public string TestsPath { get; set; } = null!;
    [NotMapped]
    public IFormFile Tests {  get; set; }

    [Column("record_id")]
    public int RecordId { get; set; }

    [ForeignKey("RecordId")]
    public virtual MedicalRecord Record { get; set; } = null!;
}
