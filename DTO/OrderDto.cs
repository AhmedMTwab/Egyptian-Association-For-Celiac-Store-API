using Egyptian_association_of_cieliac_patients_api.Models;

namespace Egyptian_association_of_cieliac_patients_api.DTO
{
    public class OrderDto
    {
        public string OrderDetails { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public string ShipmentLocation { get; set; } = null!;
        public string ShipmentPhone { get; set; }
       
        public List<int> Products { get; set; }=new List<int>();
        public List<int> RawMaterials { get; set; } = new List<int>();


    }
}
