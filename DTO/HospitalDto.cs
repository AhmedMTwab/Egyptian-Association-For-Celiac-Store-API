namespace Egyptian_association_of_cieliac_patients_api.DTO
{
    public class HospitalDto
    {
        public int Hospitalid { get; set; }
        public string HospitalName { get; set; }

        public List<string> PhoneNumbers { get; set; } = new List<string>();
        public List<string> Addresses { get; set; } = new List<string>();


        public List<string> Insurances { get; set; } = new List<string>();
        public List<double> InsuranceDiscounds { get; set; } = new List<double>();
        public List<string> HospitalTypes { get; set; } = new List<string>();
    }
}
