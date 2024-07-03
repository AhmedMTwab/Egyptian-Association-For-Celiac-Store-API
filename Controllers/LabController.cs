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
    public class LabController : ControllerBase
    {

        private readonly ICRUDRepo<Lab> labRepo;
        private readonly ICRUDRepo<AssosiationBranch> assosiationRepo;
        private readonly ICRUDRepo<HealthInsurance> insuranceRepo;

        public LabController(ICRUDRepo<Lab> LabRepo, ICRUDRepo<AssosiationBranch> AssosiationRepo, ICRUDRepo<HealthInsurance> InsuranceRepo)
        {
            labRepo = LabRepo;
            assosiationRepo = AssosiationRepo;
            insuranceRepo = InsuranceRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Labs = labRepo.FindAll();
            List<LabDto> LabDtos = new List<LabDto>();
            if (Labs != null)
            {
                foreach (var lab in Labs)
                {
                    LabDto LabDto = new LabDto();
                    LabDto.Labid = lab.LabId;
                    LabDto.LabName = lab.Name;
                    LabDto.OpenTime = lab.OpenTime.ToTimeSpan();
                    LabDto.CloseTime = lab.CloseTime.ToTimeSpan();
                    if (lab.types.Count > 1)
                    {
                        LabDto.LabType = "Both";
                    }
                    else
                    {
                        foreach (var type in lab.types)
                        {
                            LabDto.LabType = type.Type;
                        }
                    }
                    foreach (LabPhone phone in lab.PhoneNumbers)
                    {
                        LabDto.PhoneNumbers.Add(phone.PhoneNumber);
                    }
                    foreach (LabAddress address in lab.addresses)
                    {
                        LabDto.Addresses.Add(address.Address);
                    }
                    foreach (LabAssosiationDiscount discount in lab.AssosiationBranches)
                    {
                        LabDto.AssosiationBranches.Add(discount.Assosiation.Address);
                        LabDto.AssosiationDiscounds.Add(discount.DiscountPrecentage);
                    }
                    foreach (LabInsuranceDiscount discount in lab.insurances)
                    {
                        LabDto.Insurances.Add(discount.Insurance.Name);
                        LabDto.InsuranceDiscounds.Add(discount.DiscountPrecentage);
                    }
                    LabDtos.Add(LabDto);
                }
                return Ok(LabDtos);
            }
            else { return NotFound(); }
        }
        [HttpGet("{id:int}", Name = "GetOneLabRoute")]
        public IActionResult Details(int id)
        {
            var lab = labRepo.FindById(id);
            LabDto LabDto = new LabDto();
            if (lab != null)
            {
                LabDto.Labid = lab.LabId;
                LabDto.LabName = lab.Name;
                LabDto.OpenTime = lab.OpenTime.ToTimeSpan();
                LabDto.CloseTime = lab.CloseTime.ToTimeSpan();
                if (lab.types.Count > 1)
                {
                    LabDto.LabType = "Both";
                }
                else
                {
                    foreach (var type in lab.types)
                    {
                        LabDto.LabType = type.Type;
                    }
                }
                foreach (LabPhone phone in lab.PhoneNumbers)
                {
                    LabDto.PhoneNumbers.Add(phone.PhoneNumber);
                }
                foreach (LabAddress address in lab.addresses)
                {
                    LabDto.Addresses.Add(address.Address);
                }
                foreach (LabAssosiationDiscount discount in lab.AssosiationBranches)
                {
                    LabDto.AssosiationBranches.Add(discount.Assosiation.Address);
                    LabDto.AssosiationDiscounds.Add(discount.DiscountPrecentage);
                }
                foreach (LabInsuranceDiscount discount in lab.insurances)
                {
                    LabDto.Insurances.Add(discount.Insurance.Name);
                    LabDto.InsuranceDiscounds.Add(discount.DiscountPrecentage);
                }

                return Ok(LabDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
