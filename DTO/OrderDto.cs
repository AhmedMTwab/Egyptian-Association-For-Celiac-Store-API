using Egyptian_association_of_cieliac_patients_api.Models;

namespace Egyptian_association_of_cieliac_patients_api.DTO
{
    public class OrderDto
    {
        public string? OrderDetails { get; set; }
        public string ShipmentLocation { get; set; } = null!;
        public int Paymentid { get; set; }

        }



    }
