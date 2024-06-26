namespace Egyptian_association_of_cieliac_patients_api.DTO
{
    public class LabDto
    {
        public int Labid { get; set; }
        public string LabName { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public List<string> PhoneNumbers { get; set; } = new List<string>();
        public List<string> Addresses { get; set; } = new List<string>();

        public List<string> AssosiationBranches { get; set; } = new List<string>();
        public List<double> AssosiationDiscounds { get; set; } = new List<double>();
        public List<string> Insurances { get; set; } = new List<string>();
        public List<double> InsuranceDiscounds { get; set; } = new List<double>();
        public string LabType { get; set; }
    }
}
