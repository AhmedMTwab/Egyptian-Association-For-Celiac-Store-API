using Egyptian_association_of_cieliac_patients_api.DTO;
using Egyptian_association_of_cieliac_patients_api.Models;
using Egyptian_association_of_cieliac_patients_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Egyptian_association_of_cieliac_patients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICRUDRepo<Order> orderrepo;
        private readonly ICRUDRepo<AssosiationBranch> assosiation_Crud;
        private readonly IWebHostEnvironment hosting;

        public OrderController(ICRUDRepo<Order> orderrepo, ICRUDRepo<AssosiationBranch> assosiation_crud, IWebHostEnvironment hosting)
        {
            this.orderrepo = orderrepo;
            assosiation_Crud = assosiation_crud;
            this.hosting = hosting;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrder(OrderDto order) { 
            var Order =new Order();
            //Order.Patient.PatientId = order.PatientId;
            DateTime orderdate = DateTime.Now;
            Order.OrderDate=DateOnly.FromDateTime(orderdate);
            Order.OrderDetails = order.OrderDetails;
            Order.Quantity = order.Quantity;
            Order.TotalCost = order.TotalCost;
            Order.ShipmentLocation = order.ShipmentLocation;
            Order.ShipmentTime=order.ShipmentTime;
            Order.ShipmentPhone = order.ShipmentPhone;


        return Ok(order);
        }

    }
}
