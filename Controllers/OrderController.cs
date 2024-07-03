using Egyptian_association_of_cieliac_patients_api.DTO;
using Egyptian_association_of_cieliac_patients_api.Models;
using Egyptian_association_of_cieliac_patients_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Egyptian_association_of_cieliac_patients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly ICRUDRepo<Order> orderrepo;
        private readonly ICRUDRepo<Cart> cartrepo;
        private readonly ICRUDRepo<AssosiationBranch> assosiation_Crud;
        private readonly ICRUDRepo<Patient> patientrepo;
        private readonly ICRUDRepo<Product> productrepo;
        private readonly ICRUDRepo<RawMaterial> Rawmaterialrepo;
        private readonly IWebHostEnvironment hosting;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICRUDRepo<Payment> paymentrepo;

        public OrderController(ICRUDRepo<Order> orderrepo,ICRUDRepo<Cart> cartrepo ,ICRUDRepo<AssosiationBranch> assosiation_crud,ICRUDRepo<Patient> patientrepo, ICRUDRepo<Product> productrepo, ICRUDRepo<RawMaterial> rawmaterialrepo,IWebHostEnvironment hosting,IHttpContextAccessor httpContextAccessor,ICRUDRepo<Payment> paymentrepo)
        {
            this.orderrepo = orderrepo;
            this.cartrepo = cartrepo;
            assosiation_Crud = assosiation_crud;
            this.patientrepo = patientrepo;
            this.productrepo = productrepo;
            Rawmaterialrepo = rawmaterialrepo;
            this.hosting = hosting;
            this.httpContextAccessor = httpContextAccessor;
            this.paymentrepo = paymentrepo;
        }
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            int claim = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
            List<OrderViewDto> orderdtos = new List<OrderViewDto>();
            var orders = orderrepo.FindAll().Where(d => d.PatientId == claim);
            if (orders != null)
            {
                foreach (var order in orders)
                {
                    var orderdto=new OrderViewDto();
                    orderdto.OrderId = order.OrderId;
                    orderdto.ShipmentPhone = order.ShipmentPhone;
                    orderdto.ShipmentTime = order.ShipmentTime;
                    foreach (var product in order.OrderedProducts)
                    {
                        Productdata orderProductdata = new Productdata();
                       orderProductdata.Id = product.ProductId;
                       orderProductdata.Name = product.Product.Name;
                       orderProductdata.Details = product.Product.Details;
                       orderProductdata.ImagePath = product.Product.Images.FirstOrDefault().ImagePath;
                       orderProductdata.Quantity = product.Quantity;
                       orderProductdata.Price = product.Product.Price;
                       orderProductdata.total_price = product.Product.Price * orderProductdata.Quantity;
                        orderdto.Products.Add(orderProductdata);
                    }

                    foreach (var material in order.OrderedMaterials)
                    {
                        MaterialData orderMaterial = new MaterialData();
                        orderMaterial.Id = material.MaterialId;
                        orderMaterial.Name = material.Material.Name;
                        orderMaterial.Details = material.Material.Details;
                        orderMaterial.ImagePath = material.Material.Images.FirstOrDefault().ImagePath;
                        orderMaterial.Quantity = material.Quantity;
                        orderMaterial.Price = material.Material.Price;
                        orderMaterial.total_price = orderMaterial.Price * orderMaterial.Quantity;
                        orderdto.Materials.Add(orderMaterial);
                    }
                    orderdto.Quantity = order.Quantity;
                    orderdto.ShipmentLocation = order.ShipmentLocation;
                    orderdto.OrderDate = order.OrderDate;
                    orderdto.OrderDetails = order.OrderDetails;
                    orderdto.paymenttype=order.Payment.PaymentType;
                    orderdto.TotalCost = order.TotalCost;
                    orderdtos.Add(orderdto);
                }
                return Ok(orderdtos);
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddOrder(OrderDto order) { 
            var Order =new Order();
            int claim = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
            Order.Patient=patientrepo.FindById(claim);
            Order.Cart= Order.Patient.Cart;
            DateTime orderdate = DateTime.Now;
            Order.OrderDate=DateOnly.FromDateTime(orderdate);
            Order.OrderDetails = order.OrderDetails;
            Payment payment =paymentrepo.FindById(order.Paymentid);
            if (payment == null)
            {
                payment=paymentrepo.FindById(4);
            }
            Order.Payment = payment;
            decimal productstotalprice = 0;
            foreach (var item in Order.Cart.Products)
            {
                productstotalprice = productstotalprice + (item.Product.Price * item.Quantity);
            }
            decimal materialstotalprice = 0;
            foreach (var item in Order.Cart.RawMaterials)
            {
                materialstotalprice = materialstotalprice + (item.Material.Price * item.Quantity);
            }
            foreach(var product in Order.Cart.Products)
            {
                var orderdproduct = new OrderProduct()
                {
                    Product = product.Product,
                    Quantity = product.Quantity
                };
                Order.OrderedProducts.Add(orderdproduct);
            }
            foreach (var material in Order.Cart.RawMaterials)
            {
                var orderdmaterial = new OrderMaterial()
                {
                    Material = material.Material,
                    Quantity = material.Quantity
                };
                Order.OrderedMaterials.Add(orderdmaterial);
            }
            Order.TotalCost=productstotalprice+materialstotalprice;
            Order.ShipmentLocation = order.ShipmentLocation;
            Order.Quantity =Order.Cart.Products.Count+Order.Cart.RawMaterials.Count;
            Order.ShipmentTime=TimeOnly.FromDateTime(DateTime.Now.AddDays(1));
            Order.ShipmentPhone = Order.Patient.PhoneNumbers.FirstOrDefault().PhoneNumber;
            if(Order.Cart.Products.IsNullOrEmpty()&& Order.Cart.RawMaterials.IsNullOrEmpty())
            {
                return BadRequest("Cart is empty");
            }
            orderrepo.AddOne(Order);
            var cart=Order.Cart;
            cart.Products.Clear();
            cart.RawMaterials.Clear();
            cartrepo.UpdateOne(cart);
           


        return Ok($"you made Order at {Order.OrderDate}");
        }
        [HttpDelete("{id:int}")]
        public IActionResult deleteorder(int id)
        {
            var order=orderrepo.FindById(id);
            orderrepo.DeleteOne(order);
            return Ok("order canceled succesfully");
        }
    }
}
