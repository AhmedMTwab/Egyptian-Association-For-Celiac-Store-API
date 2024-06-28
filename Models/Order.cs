using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Egyptian_association_of_cieliac_patients_api.Models;

[Table("order")]
public partial class Order
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("order_date")]
    public DateOnly OrderDate { get; set; }

    [Column("order_details", TypeName = "text")]
    public string OrderDetails { get; set; } = null!;
    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("total_cost", TypeName = "money")]
    public decimal TotalCost { get; set; }

    [Column("shipment_location")]
    [StringLength(50)]
    [Unicode(false)]
    public string ShipmentLocation { get; set; } = null!;

    [Column("shipment_time")]
    public TimeOnly ShipmentTime { get; set; }

    [Column("shipment_phone")]
    public string ShipmentPhone { get; set; }

    //[Column("product_id")]
    //public int ProductId { get; set; }

    //[Column("material_id")]
    //public int MaterialId { get; set; }

    [Column("patient_id")]
    public int PatientId { get; set; }

   


    [ForeignKey("PatientId")]
    [InverseProperty("Orders")]
    public virtual Patient Patient { get; set; } = null!;

   
    [InverseProperty("Order")]
    public virtual ICollection<Product> products { get; set; } = new List<Product>();

    [InverseProperty("Order")]
    public virtual ICollection<RawMaterial> Matrerials { get; set; } = new List<RawMaterial>();
}
