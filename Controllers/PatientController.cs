using Egyptian_association_of_cieliac_patients_api.DTO;
using Egyptian_association_of_cieliac_patients_api.Models;
using Egyptian_association_of_cieliac_patients_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Egyptian_association_of_cieliac_patients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ICRUDRepo<Patient> patientrepo;
        private readonly ICRUDRepo<AssosiationBranch> assosiation_Crud;
        private readonly ICRUDRepo<Dises> dises_Crud;

        public PatientController(ICRUDRepo<Patient> patientrepo, ICRUDRepo<Cart> cartrepo, ICRUDRepo<AssosiationBranch> assosiation_crud, ICRUDRepo<Dises> dises_crud, IWebHostEnvironment hosting)
        {
            this.patientrepo = patientrepo;
            assosiation_Crud = assosiation_crud;
            dises_Crud = dises_crud;
        }
        [HttpGet]
        public IActionResult viewallpatients()
        {
            var patients=patientrepo.FindAll().ToList();
            var patientdtos=new List<PatientDto>();
            foreach (var patient in patients)
            {
                var dto=new PatientDto();
                dto.PatientId = patient.PatientId;
                dto.PatientName = patient.PatientName;
                dto.Dob = patient.Dob;
                dto.PatientBloodType = patient.PatientBloodtype;
                dto.Ssn=patient.Ssn;
                dto.assosiation = patient.Assosiation.Address;
                dto.medicaltestpath = patient.Medicalrecords.FirstOrDefault().Tests.FirstOrDefault().TestsPath;
                foreach (var phone in patient.PhoneNumbers)
                {
                    dto.PatientPhone.Add(phone.PhoneNumber);
                }
                foreach (var address in patient.Addresses)
                {
                    dto.PatientAddress.Add(address.Address);
                }
                foreach (var disses in patient.Diseses)
                {
                    dto.disses.Add(disses.Dises.Name);
                }
                patientdtos.Add(dto);
                
            }
            return Ok(patientdtos);
        }
        [HttpGet("{id:int}")]
        public IActionResult viewonepatient(int id)
        {
            var patient = patientrepo.FindById(id);
            var dto = new PatientDto();
            dto.PatientId = patient.PatientId;
            dto.PatientName = patient.PatientName;
            dto.Dob = patient.Dob;
            dto.PatientBloodType = patient.PatientBloodtype;
            dto.Ssn = patient.Ssn;
            dto.assosiation = patient.Assosiation.Address;
            dto.medicaltestpath = patient.Medicalrecords.FirstOrDefault().Tests.FirstOrDefault().TestsPath;
            foreach (var phone in patient.PhoneNumbers)
            {
                dto.PatientPhone.Add(phone.PhoneNumber);
            }
            foreach (var address in patient.Addresses)
            {
                dto.PatientAddress.Add(address.Address);
            }
            foreach (var disses in patient.Diseses)
            {
                dto.disses.Add(disses.Dises.Name);
            }

            return Ok(dto);
    }
    }
}
