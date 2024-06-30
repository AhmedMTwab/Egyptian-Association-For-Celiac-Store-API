using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egyptian_association_of_cieliac_patients_api.Models
{
    [PrimaryKey("MaterialId", "CartId")]
    [Table("cart_Material_have")]
    public class CartMaterialHave
    {
        [Column("Material_id")]
        public int MaterialId { get; set; }
        [Column("cart_id")]
        public int CartId { get; set; }
        [Column("Quantity")]
        public int Quantity { get; set; }


        [ForeignKey("MaterialId")]
        public virtual RawMaterial Material { get; set; } = null!;

        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; } = null!;
    }
}
