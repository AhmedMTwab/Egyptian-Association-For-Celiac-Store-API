using System.Collections.Specialized;

namespace Egyptian_association_of_cieliac_patients_api.DTO
{
    public class CartViewDto
    {
        public int Id { get; set; }
        public List<Productdata> Products { get; set; }=new List<Productdata>();
        public List<MaterialData> Materials { get; set; } = new List<MaterialData>();


    }

}
