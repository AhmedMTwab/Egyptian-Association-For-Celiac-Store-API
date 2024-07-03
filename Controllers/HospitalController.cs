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
    public class HospitalController : ControllerBase
    {

        private readonly ICRUDRepo<Hospital> hospitalRepo;
        private readonly ICRUDRepo<AssosiationBranch> assosiationRepo;
        private readonly ICRUDRepo<HealthInsurance> insuranceRepo;

        public HospitalController(ICRUDRepo<Hospital> HospitalRepo, ICRUDRepo<AssosiationBranch> AssosiationRepo, ICRUDRepo<HealthInsurance> InsuranceRepo)
        {
            hospitalRepo = HospitalRepo;
            assosiationRepo = AssosiationRepo;
            insuranceRepo = InsuranceRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Hospitals = hospitalRepo.FindAll();
            List<HospitalDto> HospitalDtos = new List<HospitalDto>();
            if (Hospitals != null)
            {
                foreach (var hospital in Hospitals)
                {
                    HospitalDto HospitalDto = new HospitalDto();
                    HospitalDto.Hospitalid = hospital.HospitalId;
                    HospitalDto.HospitalName = hospital.Name;
                    
                   

                    foreach (HospitalPhone phone in hospital.PhoneNumbers)
                    {
                        HospitalDto.PhoneNumbers.Add(phone.PhoneNumber);
                    }
                    foreach (HospitalAddress address in hospital.addresses)
                    {
                        HospitalDto.Addresses.Add(address.Address);
                    }
                    foreach (HospitalType type in hospital.types)
                    {
                        HospitalDto.HospitalTypes.Add(type.Type);
                    }
                    foreach (HospitalInsuranceDiscount discount in hospital.insurances)
                    {
                        HospitalDto.Insurances.Add(discount.Insurance.Name);
                        HospitalDto.InsuranceDiscounds.Add(discount.DiscountPrecentage);
                    }
                    HospitalDtos.Add(HospitalDto);
                }
                return Ok(HospitalDtos);
            }
            else { return NotFound(); }
        }
        [HttpGet("{id:int}", Name = "GetOneHospitalRoute")]
        public IActionResult Details(int id)
        {
            var hospital = hospitalRepo.FindById(id);
            HospitalDto HospitalDto = new HospitalDto();
            if (hospital != null)
            {
                HospitalDto.Hospitalid = hospital.HospitalId;
                HospitalDto.HospitalName = hospital.Name;
                

                foreach (HospitalPhone phone in hospital.PhoneNumbers)
                {
                    HospitalDto.PhoneNumbers.Add(phone.PhoneNumber);
                }
                foreach (HospitalAddress address in hospital.addresses)
                {
                    HospitalDto.Addresses.Add(address.Address);
                }
                foreach (HospitalType type in hospital.types)
                {
                    HospitalDto.HospitalTypes.Add(type.Type);
                }
                foreach (HospitalInsuranceDiscount discount in hospital.insurances)
                {
                    HospitalDto.Insurances.Add(discount.Insurance.Name);
                    HospitalDto.InsuranceDiscounds.Add(discount.DiscountPrecentage);
                }

                return Ok(HospitalDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
