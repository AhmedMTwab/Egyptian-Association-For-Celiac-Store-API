using Egyptian_association_of_cieliac_patients_api.Repositories;
using Egyptian_association_of_cieliac_patients_api.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Egyptian_association_of_cieliac_patients_api.Models;

namespace Egyptian_association_of_cieliac_patients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ICRUDRepo<Doctor> doctor_Crud;
        private readonly ICRUDRepo<Clinic> clinicRepo;

        public DoctorController(ICRUDRepo<Doctor> Doctor_crud, ICRUDRepo<Clinic> ClinicRepo)
        {
            doctor_Crud = Doctor_crud;
            clinicRepo = ClinicRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var doctors = doctor_Crud.FindAll();
            List<DoctorDto> doctorDtos = new List<DoctorDto>();
            foreach (var doctor in doctors)
            {
                DoctorDto doctorDto = new DoctorDto();
                doctorDto.doctorid = doctor.DoctorId;
                doctorDto.DoctorName = doctor.Name;
                doctorDto.DoctorMajor = doctor.Major;
                foreach (DoctorPhone phone in doctor.DoctorPhones)
                {
                    doctorDto.PhoneNumbers.Add(phone.PhoneNumber);
                }
                foreach (DoctorClinicWork clinic in doctor.clinics)
                {
                    doctorDto.ClinicNames.Add(clinic.Clinic.Name);
                    doctorDto.ClinicArrivalTimes.Add(clinic.ArriveTime.ToTimeSpan());
                    doctorDto.ClinicLeaveTimes.Add(clinic.LeaveTime.ToTimeSpan());
                }
                doctorDtos.Add(doctorDto);
            }
            return Ok(doctorDtos);
        }
        [HttpGet("{id:int}", Name = "GetOneDocRoute")]
        public IActionResult Details(int id)
        {
            var doctor = doctor_Crud.FindById(id, "DoctorPhones", "clinics");
            DoctorDto doctorDto = new DoctorDto();
            doctorDto.doctorid = doctor.DoctorId;
            doctorDto.DoctorName = doctor.Name;
            doctorDto.DoctorMajor = doctor.Major;
            foreach(DoctorPhone phone in doctor.DoctorPhones)
            {
                doctorDto.PhoneNumbers.Add(phone.PhoneNumber);
            }
            foreach(DoctorClinicWork clinic in doctor.clinics)
            {
                doctorDto.ClinicNames.Add(clinic.Clinic.Name);
                doctorDto.ClinicArrivalTimes.Add(clinic.ArriveTime.ToTimeSpan());
                doctorDto.ClinicLeaveTimes.Add(clinic.LeaveTime.ToTimeSpan());
            }

            return Ok(doctorDto);
        }
    }
}
