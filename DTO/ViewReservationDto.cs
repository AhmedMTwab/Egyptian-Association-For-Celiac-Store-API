namespace Egyptian_association_of_cieliac_patients_api.DTO
{
    public class ViewReservationDto
    {
        public int ReservationId { get; set; }
        public DateOnly ReservationDate { get; set;}
        public string ClinicName { get; set;}
        public TimeOnly ReservationTime { get; set;}
        public DateOnly BookDate { get; set;}
        public TimeOnly BookTime { get; set;}


    }
}
