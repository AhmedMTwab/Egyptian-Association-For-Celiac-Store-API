using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egyptian_association_of_cieliac_patients_api.Models
{
    [PrimaryKey("MaterialId", "OrderId")]
    [Table("order_material")]
    public class OrderMaterial
    {
        [Column("Material_id")]
        public int MaterialId { get; set; }
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("Quantity")]
        public int Quantity { get; set; }


        [ForeignKey("MaterialId")]
        public virtual RawMaterial Material { get; set; } = null!;

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; } = null!;
    }
}
