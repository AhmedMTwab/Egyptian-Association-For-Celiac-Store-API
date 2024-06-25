using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Table("payment")]
public partial class Payment
{
    [Key]
    [Column("payment_id")]
    public int PaymentId { get; set; }

    [Column("payment_type")]
    [StringLength(10)]
    public string PaymentType { get; set; } = null!;

    [Column("total_paid", TypeName = "money")]
    public decimal TotalPaid { get; set; }
}
