using System.ComponentModel.DataAnnotations;

namespace Egyptian_association_of_cieliac_patients_api.DTO
{
    public class LoginDto
    {
        [Required]
        [MinLength(14)]
        public string ssn { get; set; }
        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
