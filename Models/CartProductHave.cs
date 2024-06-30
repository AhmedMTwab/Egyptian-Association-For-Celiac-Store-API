using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egyptian_association_of_cieliac_patients_api.Models
{
    [PrimaryKey("ProductId", "CartId")]
    [Table("cart_product_have")]
    public class CartProductHave
    {
        [Column("product_id")]
        public int ProductId {  get; set; }
        [Column("cart_id")]
        public int CartId { get; set; }
        [Column("Quantity")]
        public int Quantity { get; set; }

       
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;

        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; } = null!;
    }
}
