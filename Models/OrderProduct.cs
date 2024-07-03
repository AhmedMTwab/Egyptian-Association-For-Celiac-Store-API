using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egyptian_association_of_cieliac_patients_api.Models
{
    [PrimaryKey("ProductId", "OrderId")]
    [Table("order_product")]
    public class OrderProduct
    {
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("Quantity")]
        public int Quantity { get; set; }


        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; } = null!;
    }
}
