using Egyptian_association_of_cieliac_patients_api.Repositories;
using Egyptian_association_of_cieliac_patients_api.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Egyptian_association_of_cieliac_patients_api.Models;

namespace Egyptian_association_of_cieliac_patients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class doctorController : ControllerBase
    {
        private readonly ICRUDRepo<Doctor> doctor_Crud;
        private readonly ICRUDRepo<Clinic> clinicRepo;

        public doctorController(ICRUDRepo<Doctor> doctor_crud, ICRUDRepo<Clinic> ClinicRepo)
        {
            doctor_Crud = doctor_crud;
            clinicRepo = ClinicRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var doctors = doctor_Crud.FindAll();
            List<DoctorDto> DoctorDtos = new List<DoctorDto>();
            if (doctors != null)
            {
                foreach (var doctor in doctors)
                {
                    DoctorDto DoctorDto = new DoctorDto();
                    DoctorDto.doctorid = doctor.DoctorId;
                    DoctorDto.DoctorName = doctor.Name;
                    DoctorDto.DoctorMajor = doctor.Major;
                    foreach (DoctorPhone phone in doctor.DoctorPhones)
                    {
                        DoctorDto.PhoneNumbers.Add(phone.PhoneNumber);
                    }
                    foreach (DoctorClinicWork clinic in doctor.clinics)
                    {
                        DoctorDto.ClinicNames.Add(clinic.Clinic.Name);
                        DoctorDto.ClinicArrivalTimes.Add(clinic.ArriveTime.ToTimeSpan());
                        DoctorDto.ClinicLeaveTimes.Add(clinic.LeaveTime.ToTimeSpan());
                    }
                    DoctorDtos.Add(DoctorDto);
                }
                return Ok(DoctorDtos);
            }
            else { return NotFound(); }
        }
        [HttpGet("{id:int}", Name = "GetOneDocRoute")]
        public IActionResult Details(int id)
        {
            var doctor = doctor_Crud.FindById(id);
            DoctorDto DoctorDto = new DoctorDto();
            if (doctor != null)
            {
                DoctorDto.doctorid = doctor.DoctorId;
                DoctorDto.DoctorName = doctor.Name;
                DoctorDto.DoctorMajor = doctor.Major;
                foreach (DoctorPhone phone in doctor.DoctorPhones)
                {
                    DoctorDto.PhoneNumbers.Add(phone.PhoneNumber);
                }
                foreach (DoctorClinicWork clinic in doctor.clinics)
                {
                    DoctorDto.ClinicNames.Add(clinic.Clinic.Name);
                    DoctorDto.ClinicArrivalTimes.Add(clinic.ArriveTime.ToTimeSpan());
                    DoctorDto.ClinicLeaveTimes.Add(clinic.LeaveTime.ToTimeSpan());
                }

                return Ok(DoctorDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
