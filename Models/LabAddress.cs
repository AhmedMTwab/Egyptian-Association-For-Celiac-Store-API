using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egyptian_association_of_cieliac_patients_api.Models
{
    [PrimaryKey("Address", "LabId")]   
    [Table("lab_address")]
    public partial class LabAddress
    {
        [Column("lab_address")]
        public string Address { get; set; }

        [Column("lab_id")]
        public int LabId { get; set; }

        [ForeignKey("labId")]
        public virtual Lab Lab { get; set; } = null!;
    }
}