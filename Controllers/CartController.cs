using Egyptian_association_of_cieliac_patients_api.DTO;
using Egyptian_association_of_cieliac_patients_api.Models;
using Egyptian_association_of_cieliac_patients_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Egyptian_association_of_cieliac_patients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICRUDRepo<Cart> cartrepo;
        private readonly ICRUDRepo<Patient> patientrepo;
        private readonly ICRUDRepo<Product> productrepo;
        private readonly ICRUDRepo<RawMaterial> rawmaterialrepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CartController(ICRUDRepo<Cart> cartrepo, ICRUDRepo<Order> orderrepo, ICRUDRepo<AssosiationBranch> assosiation_crud, ICRUDRepo<Patient> patientrepo, ICRUDRepo<Product> productrepo, ICRUDRepo<RawMaterial> rawmaterialrepo, IWebHostEnvironment hosting, IHttpContextAccessor httpContextAccessor)
        {
            this.cartrepo = cartrepo;
            this.patientrepo = patientrepo;
            this.productrepo = productrepo;
            this.rawmaterialrepo = rawmaterialrepo;
            this.httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult viewcart()
        {
       
            int claim = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
            var cartdto = new CartViewDto();
            var cart = cartrepo.FindAll().Where(d => d.PatientId == claim).FirstOrDefault();

            cartdto.Id = cart.CartId;
            
            foreach (var product in cart.Products)
            {
                Productdata cartProductdata = new Productdata();
                cartProductdata.Id=product.ProductId;
                cartProductdata.Name=product.Product.Name;
                cartProductdata.Details = product.Product.Details;
                cartProductdata.ImagePath=product.Product.Images.FirstOrDefault().ImagePath;
                cartProductdata.Quantity=product.Quantity;
                cartProductdata.Price = product.Product.Price;
                cartProductdata.total_price=product.Product.Price*cartProductdata.Quantity;
                cartdto.Products.Add(cartProductdata);
            }
            
            foreach (var material in cart.RawMaterials)
            {
                MaterialData cartMaterial = new MaterialData();
                cartMaterial.Id = material.MaterialId;
                cartMaterial.Name = material.Material.Name;
                cartMaterial.Details = material.Material.Details;
                cartMaterial.ImagePath = material.Material.Images.FirstOrDefault().ImagePath;
                cartMaterial.Quantity = material.Quantity;
                cartMaterial.Price = material.Material.Price;
                cartMaterial.total_price=cartMaterial.Price*cartMaterial.Quantity;
                cartdto.Materials.Add(cartMaterial);
            }
            


            return Ok(cartdto);
        }
        
    }
}
