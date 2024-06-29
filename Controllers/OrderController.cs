using Egyptian_association_of_cieliac_patients_api.DTO;
using Egyptian_association_of_cieliac_patients_api.Models;
using Egyptian_association_of_cieliac_patients_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Egyptian_association_of_cieliac_patients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICRUDRepo<Order> orderrepo;
        private readonly ICRUDRepo<AssosiationBranch> assosiation_Crud;
        private readonly ICRUDRepo<Patient> patientrepo;
        private readonly ICRUDRepo<Product> productrepo;
        private readonly ICRUDRepo<RawMaterial> Rawmaterialrepo;
        private readonly IWebHostEnvironment hosting;
        private readonly IHttpContextAccessor httpContextAccessor;

        public OrderController(ICRUDRepo<Order> orderrepo, ICRUDRepo<AssosiationBranch> assosiation_crud,ICRUDRepo<Patient> patientrepo, ICRUDRepo<Product> productrepo, ICRUDRepo<RawMaterial> rawmaterialrepo,IWebHostEnvironment hosting,IHttpContextAccessor httpContextAccessor)
        {
            this.orderrepo = orderrepo;
            assosiation_Crud = assosiation_crud;
            this.patientrepo = patientrepo;
            this.productrepo = productrepo;
            Rawmaterialrepo = rawmaterialrepo;
            this.hosting = hosting;
            this.httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        public IActionResult AddOrder(OrderDto order) { 
            var Order =new Order();
            int claim = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
            Order.Patient=patientrepo.FindById(claim);
            DateTime orderdate = DateTime.Now;
            Order.OrderDate=DateOnly.FromDateTime(orderdate);
            Order.OrderDetails = order.OrderDetails;
            Order.Quantity =order.Products.Count+order.RawMaterials.Count;
            Order.TotalCost = order.TotalCost;
            Order.ShipmentLocation = order.ShipmentLocation;
            Order.ShipmentTime=TimeOnly.FromDateTime(DateTime.Now.AddDays(1));
            Order.ShipmentPhone = order.ShipmentPhone;

            //foreach (var item in order.Products)
            //{
            //        var product = productrepo.FindById(item);
            //        if(product !=null)
            //        //Order.products.Add(product);
                
            //}

            //foreach (var item in order.RawMaterials)
            //{

            //    RawMaterial? rawmaterial = Rawmaterialrepo.FindById(item);
            //    if (rawmaterial != null)
            //        //Order.Matrerials.Add(rawmaterial);

            //}
          
            orderrepo.AddOne(Order);


        return Ok(order);
        }

    }
}
