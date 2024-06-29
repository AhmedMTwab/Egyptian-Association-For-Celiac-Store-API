using Egyptian_association_of_cieliac_patients_api.DTO;
using Egyptian_association_of_cieliac_patients_api.Models;
using Egyptian_association_of_cieliac_patients_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Egyptian_association_of_cieliac_patients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ICRUDRepo<Reservation> reservationrepo;
        private readonly ICRUDRepo<Patient> patientrepo;
        private readonly ICRUDRepo<Clinic> clinicrepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ReservationController(ICRUDRepo<Reservation> reservationrepo, ICRUDRepo<Patient> patientrepo, ICRUDRepo<Clinic> clinicrepo, IHttpContextAccessor httpContextAccessor)
        {
            this.reservationrepo = reservationrepo;
            this.patientrepo = patientrepo;
            this.clinicrepo = clinicrepo;
            this.httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult ViewReservation()
        {
            var viewDtos=new List<ViewReservationDto>();
            int claim = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
            var Reservations = reservationrepo.FindAll().Where(d => d.PatientId == claim).ToList();
            foreach (var Reservation in Reservations)
            {
                var viewDto = new ViewReservationDto();
                viewDto.ReservationId = Reservation.ReservationId;
                viewDto.ReservationDate = Reservation.ReservationDate;
                var clinic=clinicrepo.FindById(Reservation.clinic.ClinicId);
                viewDto.ClinicName = clinic.Name;
                viewDto.ReservationTime = Reservation.ReservationTime;
                viewDto.BookDate = Reservation.BookDate;
                viewDto.BookTime = Reservation.BookTime;
                viewDtos.Add(viewDto);
            }
            if (viewDtos.Count > 0)
            {
                return Ok(viewDtos);
            }
            else
                return NoContent();

        }
        [HttpPost("{ClinicId:int}")]
        public IActionResult AddReservation(int ClinicId, ReservationDto reservationData)
        {
            
                var Reservation = new Reservation();
                int claim = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
                Reservation.Patient = patientrepo.FindById(claim);
                Reservation.ReservationDate = DateOnly.FromDateTime(reservationData.ReservationDate);
                var clinic = clinicrepo.FindById(ClinicId);
                if (clinic != null)
                {
                    Reservation.clinic = clinic;
                    Reservation.ReservationTime = clinic.OpenTime;
                    Reservation.BookDate = DateOnly.FromDateTime(DateTime.Now);
                    Reservation.BookTime = TimeOnly.FromDateTime(DateTime.Now);
                    reservationrepo.AddOne(Reservation);
                    return Created();
                }
            
            return BadRequest();
        }
        [HttpDelete("{ReservationId:int}")]
        public IActionResult DeleteReservation(int ReservationId)
        {
            var reservation= reservationrepo.FindById(ReservationId);
            if (reservation != null)
            {
                reservationrepo.DeleteOne(reservation);
                return Ok("Deleted Succesfully");
            }
            return NoContent();
        }
    }
    
}
