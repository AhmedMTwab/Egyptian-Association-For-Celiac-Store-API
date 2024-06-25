using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egyptian_association_of_cieliac_patients_api.Models
{
    [PrimaryKey("Address", "HospitalId")]
    [Table("hospital_address")]
    public partial class HospitalAddress
    {
        [Column("hospital_address")]
        public string Address { get; set; }

        [Column("hospital_id")]
        public int HospitalId { get; set; }

        [ForeignKey("hospitalId")]
        public virtual Hospital Hospital { get; set; } = null!;
    }
}