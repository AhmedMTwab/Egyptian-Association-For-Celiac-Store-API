using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[PrimaryKey("PatientId", "ProductId")]
[Table("patient_product_view")]
public partial class PatientProductView
{
    [Column("patient_id")]
    public int? PatientId { get; set; }

    [Column("product_id")]
    public int? ProductId { get; set; }

    [ForeignKey("PatientId")]
    public virtual Patient? Patient { get; set; }

    [ForeignKey("ProductId")]
    public virtual Product? Product { get; set; }
}
