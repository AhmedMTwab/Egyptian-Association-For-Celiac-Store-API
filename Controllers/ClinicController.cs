using Egyptian_association_of_cieliac_patients_api.DTO;
using Egyptian_association_of_cieliac_patients_api.Models;
using Egyptian_association_of_cieliac_patients_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Egyptian_association_of_cieliac_patients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClinicController : ControllerBase
    {
        private readonly ICRUDRepo<Clinic> clinicRepo;
        private readonly ICRUDRepo<AssosiationBranch> assosiationRepo;
        private readonly ICRUDRepo<HealthInsurance> insuranceRepo;

        public ClinicController(ICRUDRepo<Clinic> ClinicRepo, ICRUDRepo<AssosiationBranch> AssosiationRepo, ICRUDRepo<HealthInsurance> InsuranceRepo)
        {
            clinicRepo = ClinicRepo;
            assosiationRepo = AssosiationRepo;
            insuranceRepo = InsuranceRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Clinics = clinicRepo.FindAll();
            List<ClinicDto> ClinicDtos = new List<ClinicDto>();
            if (Clinics != null)
            {
                foreach (var clinic in Clinics)
                {
                    ClinicDto ClinicDto = new ClinicDto();
                    ClinicDto.clinicid = clinic.ClinicId;
                    ClinicDto.ClinicName = clinic.Name;
                    ClinicDto.OpenTime = clinic.OpenTime.ToTimeSpan();
                    ClinicDto.CloseTime = clinic.CloseTime.ToTimeSpan();

                    foreach (ClinicPhone phone in clinic.clinicphones)
                    {
                        ClinicDto.PhoneNumbers.Add(phone.PhoneNumber);
                    }
                    foreach (ClinicAddress address in clinic.clinicaddreses)
                    {
                        ClinicDto.Addresses.Add(address.Address);
                    }
                    foreach(DoctorClinicWork doctor in clinic.Doctors)
                    {
                        ClinicDto.Doctors.Add(doctor.Doctor.Name);
                    }
                    foreach (ClinicAssosiationDiscount discount in clinic.branches)
                    {
                        ClinicDto.AssosiationBranches.Add(discount.Assosiation.Address);
                        ClinicDto.AssosiationDiscounds.Add(discount.DiscountPrecentage);
                    }
                    foreach (ClinicInsuranceDiscount discount in clinic.insurences)
                    {
                        ClinicDto.Insurances.Add(discount.Insurance.Name);
                        ClinicDto.InsuranceDiscounds.Add(discount.DiscountPrecentage);
                    }
                    ClinicDtos.Add(ClinicDto);
                }
                return Ok(ClinicDtos);
            }
            else { return NotFound(); }
        }
        [HttpGet("{id:int}", Name = "GetOneClinicRoute")]
        public IActionResult Details(int id)
        {
            var clinic = clinicRepo.FindById(id);
            ClinicDto ClinicDto = new ClinicDto();
            if (clinic != null)
            {
                ClinicDto.clinicid = clinic.ClinicId;
                ClinicDto.ClinicName = clinic.Name;
                ClinicDto.OpenTime = clinic.OpenTime.ToTimeSpan();
                ClinicDto.CloseTime = clinic.CloseTime.ToTimeSpan();

                foreach (ClinicPhone phone in clinic.clinicphones)
                {
                    ClinicDto.PhoneNumbers.Add(phone.PhoneNumber);
                }
                foreach (ClinicAddress address in clinic.clinicaddreses)
                {
                    ClinicDto.Addresses.Add(address.Address);
                }
                foreach (DoctorClinicWork doctor in clinic.Doctors)
                {
                    ClinicDto.Doctors.Add(doctor.Doctor.Name);
                }
                foreach (ClinicAssosiationDiscount discount in clinic.branches)
                {
                    ClinicDto.AssosiationBranches.Add(discount.Assosiation.Address);
                    ClinicDto.AssosiationDiscounds.Add(discount.DiscountPrecentage);
                }
                foreach (ClinicInsuranceDiscount discount in clinic.insurences)
                {
                    ClinicDto.Insurances.Add(discount.Insurance.Name);
                    ClinicDto.InsuranceDiscounds.Add(discount.DiscountPrecentage);
                }

                return Ok(ClinicDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
