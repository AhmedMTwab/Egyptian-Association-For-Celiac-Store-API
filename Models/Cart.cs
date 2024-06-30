using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egyptian_association_of_cieliac_patients_api.Models
{
    public class Cart
    {
        [Key]
        [Column("cart_id")]
        public int CartId { get; set; }
        public int PatientId { get; set; }
        [InverseProperty("Cart")]
        public virtual ICollection<Product> Products { get; set; }
        [InverseProperty("Cart")]
        public virtual ICollection<RawMaterial> RawMaterials { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
    }
}
