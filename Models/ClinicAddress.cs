using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egyptian_association_of_cieliac_patients_api.Models
{
    [PrimaryKey("Address", "ClinicId")]
    [Table("clinic_address")]
    public partial class ClinicAddress
    {
        [Column("clinic_address")]
        public string Address { get; set; }

        [Column("clinic_id")]
        public int ClinicId { get; set; }

        [ForeignKey("ClinicId")]
        public virtual Clinic Clinic { get; set; } = null!;
    }
}