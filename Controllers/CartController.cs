using Egyptian_association_of_cieliac_patients_api.DTO;
using Egyptian_association_of_cieliac_patients_api.Models;
using Egyptian_association_of_cieliac_patients_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Egyptian_association_of_cieliac_patients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        //    var cartview = new CartViewDto();
            int claim = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
            var cartdto = new CartViewDto();
            var cart = cartrepo.FindAll().Where(d => d.PatientId == claim).FirstOrDefault();

            cartdto.Id = cart.CartId;
            foreach (var product in cart.Products) {
                cartdto.cartproductsId.Add(product.ProductId);
            }
            foreach (var material in cart.RawMaterials)
            {
                cartdto.cartmaterialsId.Add(material.MaterialId);
            }


            return Ok(cartdto);
        }
        
    }
}
