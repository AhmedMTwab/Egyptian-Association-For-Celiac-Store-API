using System.Collections.Specialized;

namespace Egyptian_association_of_cieliac_patients_api.DTO
{
    public class CartViewDto
    {
        public int Id { get; set; }
        public List<Dictionary<int,int>> products {  get; set; }= new List<Dictionary <int,int>>();
        public List<Dictionary<int, int>> RawMaterials { get; set; } = new List<Dictionary<int, int>>();
    }

}
