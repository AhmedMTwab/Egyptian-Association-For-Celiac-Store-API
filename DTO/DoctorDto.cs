using Egyptian_association_of_cieliac_patients_api.Models;

namespace Egyptian_association_of_cieliac_patients_api.DTO
{
    public class DoctorDto
    {
        public int id;
        public int doctorid { get; set; }
        public string DoctorName { get; set; }
        public string DoctorMajor { get; set; }
        public List<int> clinicIds { get; set; }= new List<int>();
        public List<string> ClinicNames { get; set; }=new List<string>();
        public List<TimeSpan> ClinicDoctorArrivalTimes { get; set; }= new List<TimeSpan>();
        public List<TimeSpan> ClinicDoctorLeaveTimes { get; set; } = new List<TimeSpan>();
        public List<string> PhoneNumbers { get; set; }=new List<string>();
}
}
