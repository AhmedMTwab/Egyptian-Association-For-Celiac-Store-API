using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egyptian_association_of_cieliac_patients_api.Models
{
    [PrimaryKey("Type", "HospitalId")]
    [Table("hospital_type")]
    public partial class HospitalType
    {
        [Column("hospital_type")]
        public string Type { get; set; }

        [Column("hospital_id")]
        public int HospitalId { get; set; }

        [ForeignKey("HospitalId")]
        public virtual Hospital Hospital { get; set; } = null!;
    }
}