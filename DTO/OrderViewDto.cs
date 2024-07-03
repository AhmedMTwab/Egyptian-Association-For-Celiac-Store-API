using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Egyptian_association_of_cieliac_patients_api.DTO
{
    public class OrderViewDto
    {
       
        public int OrderId { get; set; }

      
        public DateOnly OrderDate { get; set; }

       
        public string OrderDetails { get; set; } = null!;
      
        public int Quantity { get; set; }

        public string paymenttype {  get; set; }
      
        public decimal TotalCost { get; set; }

        public string ShipmentLocation { get; set; } = null!;

        
        public TimeOnly ShipmentTime { get; set; }

       
        public string ShipmentPhone { get; set; }
        public List<Productdata> Products { get; set; } = new List<Productdata>();
        public List<MaterialData> Materials { get; set; } = new List<MaterialData>();

    }
}
