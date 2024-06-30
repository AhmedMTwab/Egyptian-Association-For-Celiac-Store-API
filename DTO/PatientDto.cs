namespace Egyptian_association_of_cieliac_patients_api.DTO
{
    public class PatientDto
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientBloodType { get; set; }
        public DateOnly Dob { get; set; }
        public string Ssn { get; set; }
        public List<string> PatientAddress { get; set; } = new List<string>();
        public List<string> PatientPhone { get; set; } = new List<string>();
        public string assosiation { get; set; }
        public string? medicaltestpath { get; set; }
        public List<string> disses { get; set; } = new List<string>();
    }
}
