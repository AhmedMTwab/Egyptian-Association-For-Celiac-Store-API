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
    public class PharmacyController : ControllerBase
    {
        private readonly ICRUDRepo<Pharmacy> pharmacyRepo;
        private readonly ICRUDRepo<AssosiationBranch> assosiationRepo;
        private readonly ICRUDRepo<HealthInsurance> insuranceRepo;

        public PharmacyController(ICRUDRepo<Pharmacy> PharmacyRepo, ICRUDRepo<AssosiationBranch> AssosiationRepo, ICRUDRepo<HealthInsurance> InsuranceRepo)
        {
            pharmacyRepo = PharmacyRepo;
            assosiationRepo = AssosiationRepo;
            insuranceRepo = InsuranceRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Pharmacys = pharmacyRepo.FindAll();
            List<PharmacyDto> PharmacyDtos = new List<PharmacyDto>();
            if (Pharmacys != null)
            {
                foreach (var pharmacy in Pharmacys)
                {
                    PharmacyDto PharmacyDto = new PharmacyDto();
                    PharmacyDto.pharmacyid = pharmacy.pharmacyId;
                    PharmacyDto.PharmacyName = pharmacy.Name;
                    PharmacyDto.OpenTime = pharmacy.OpenTime.ToTimeSpan();
                    PharmacyDto.CloseTime = pharmacy.CloseTime.ToTimeSpan();

                    foreach (PharmacyPhone phone in pharmacy.PhoneNumbers)
                    {
                        PharmacyDto.PhoneNumbers.Add(phone.PhoneNumber);
                    }
                    foreach (PharmacyAddress address in pharmacy.addresses)
                    {
                        PharmacyDto.Addresses.Add(address.Address);
                    }
                    foreach(PharmacyAssosiationDiscount discount in pharmacy.AssosiationBranches)
                    {
                        PharmacyDto.AssosiationBranches.Add(discount.Assosiation.Address);
                        PharmacyDto.AssosiationDiscounds.Add(discount.DiscountPrecentage);
                    }
                    foreach (PharmacyInsuranceDiscount discount in pharmacy.insurances)
                    {
                        PharmacyDto.Insurances.Add(discount.Insurance.Name);
                        PharmacyDto.InsuranceDiscounds.Add(discount.DiscountPrecentage);
                    }
                    PharmacyDtos.Add(PharmacyDto);
                }
                return Ok(PharmacyDtos);
            }
            else { return NotFound(); }
        }
        [HttpGet("{id:int}", Name = "GetOnePharmacyRoute")]
        public IActionResult Details(int id)
        {
            var pharmacy = pharmacyRepo.FindById(id);
            PharmacyDto PharmacyDto = new PharmacyDto();
            if (pharmacy != null)
            {
                PharmacyDto.pharmacyid = pharmacy.pharmacyId;
                PharmacyDto.PharmacyName = pharmacy.Name;
                PharmacyDto.OpenTime = pharmacy.OpenTime.ToTimeSpan();
                PharmacyDto.CloseTime = pharmacy.CloseTime.ToTimeSpan();

                foreach (PharmacyPhone phone in pharmacy.PhoneNumbers)
                {
                    PharmacyDto.PhoneNumbers.Add(phone.PhoneNumber);
                }
                foreach (PharmacyAddress address in pharmacy.addresses)
                {
                    PharmacyDto.Addresses.Add(address.Address);
                }
                foreach (PharmacyAssosiationDiscount discount in pharmacy.AssosiationBranches)
                {
                    PharmacyDto.AssosiationBranches.Add(discount.Assosiation.Address);
                    PharmacyDto.AssosiationDiscounds.Add(discount.DiscountPrecentage);
                }
                foreach (PharmacyInsuranceDiscount discount in pharmacy.insurances)
                {
                    PharmacyDto.Insurances.Add(discount.Insurance.Name);
                    PharmacyDto.InsuranceDiscounds.Add(discount.DiscountPrecentage);
                }

                return Ok(PharmacyDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
