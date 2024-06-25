using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egyptian_association_of_cieliac_patients_api.Models
{
    [PrimaryKey("Address", "PharmacyId")]
    [Table("pharmacy_address")]
    public partial class PharmacyAddress
    {
        [Column("pharmacy_address")]
        public string Address { get; set; }

        [Column("pharmacy_id")]
        public int PharmacyId { get; set; }

        [ForeignKey("PharmacyId")]
        public virtual Pharmacy Pharmacy { get; set; } = null!;
    }
}