using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egyptian_association_of_cieliac_patients_api.Models
{
    [PrimaryKey("Type", "LabId")]
    [Table("lab_type")]
    public partial class LabType
    {
        [Column("lab_type")]
        public string Type { get; set; }

        [Column("lab_id")]
        public int LabId { get; set; }

        [ForeignKey("LabId")]
        public virtual Lab Lab { get; set; } = null!;
    }
}