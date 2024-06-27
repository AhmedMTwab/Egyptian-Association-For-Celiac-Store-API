using Egyptian_association_of_cieliac_patients_api.DTO;
using Egyptian_association_of_cieliac_patients_api.Models;
using Egyptian_association_of_cieliac_patients_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Egyptian_association_of_cieliac_patients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ICRUDRepo<Patient> patientrepo;
        private readonly IConfiguration config;

        public LoginController(ICRUDRepo<Patient> patientrepo,IConfiguration config)
        {
            this.patientrepo = patientrepo;
            this.config = config;
        }
        [HttpPost]
        public IActionResult Login(LoginDto logindata)
        {
            if (logindata != null && ModelState.IsValid == true)
            {
                var patient=patientrepo.FindAll().First(p => p.Ssn == logindata.ssn);
                if (patient != null)
                {
                    if(patient.Dob.Year.ToString() == logindata.Password)
                    {
                        var claims=new List<Claim>();
                        claims.Add(new Claim("ID",patient.PatientId.ToString()));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()));
                        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecretKey"]));
                        SigningCredentials signincred=new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
                        JwtSecurityToken token = new JwtSecurityToken(
                            issuer: config["JWT:Issuer"],
                            audience: config["JWT:Audiance"],
                            claims: claims,
                            expires:DateTime.Now.AddHours(1),
                            signingCredentials:signincred
                            );
                        return Ok(new
                        {
                            token=new JwtSecurityTokenHandler().WriteToken(token),
                            expiration=token.ValidTo
                        });
                    }
                }
                return Unauthorized();

            }
            return Unauthorized();
        }
    }
}
