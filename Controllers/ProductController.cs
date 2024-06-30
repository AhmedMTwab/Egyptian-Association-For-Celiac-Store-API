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
    public class ProductController : ControllerBase
    {
        private readonly ICRUDRepo<Product> productrepo;
        private readonly ICRUDRepo<Cart> cartrepo;
        private readonly ICRUDRepo<Patient> patientrepo;
        private readonly ICRUDRepo<AssosiationBranch> assosiation_Crud;
        private readonly IWebHostEnvironment hosting;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProductController(ICRUDRepo<Product> productrepo, ICRUDRepo<Cart> cartrepo, ICRUDRepo<Patient> patientrepo, ICRUDRepo<AssosiationBranch> assosiation_crud, IWebHostEnvironment hosting,IHttpContextAccessor httpContextAccessor)
        {
            this.productrepo = productrepo;
            this.cartrepo = cartrepo;
            this.patientrepo = patientrepo;
            assosiation_Crud = assosiation_crud;
            this.hosting = hosting;
            this.httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var products = productrepo.FindAll();
            List<ProductDto> ProductDtos = new List<ProductDto>();
            if (products != null)
            {
                foreach (var product in products)
                {
                    ProductDto ProductDto = new ProductDto();
                    ProductDto.Id = product.ProductId;
                    ProductDto.Name = product.Name;
                    ProductDto.Details = product.Details;
                    ProductDto.Price = product.Price;
                    ProductDto.ImagePath = product.Images.FirstOrDefault().ImagePath;
                    ProductDtos.Add(ProductDto);
                }
                return Ok(ProductDtos);
            }
            else { return NotFound(); }
        }
        [HttpGet("{id:int}", Name = "GetOneProductRoute")]
        public IActionResult Details(int id)
        {
            var product = productrepo.FindById(id);
            ProductDto ProductDto = new ProductDto();
            if (product != null)
            {
                ProductDto.Id = product.ProductId;
                ProductDto.Name = product.Name;
                ProductDto.Details = product.Details;
                ProductDto.Price = product.Price;
                ProductDto.ImagePath = product.Images.FirstOrDefault().ImagePath;
                return Ok(ProductDto);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize]
        [HttpPost("addtocart/{productId:int}/{quantity:int}", Name = "ProductToCartRoute")]
        public IActionResult addproducttocart(int productId,int quantity)
        {
            int claim = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
            var cart = patientrepo.FindAll().FirstOrDefault(d => d.PatientId == claim).Cart;
            if (cart == null)
            {
                Cart newcart = new Cart()
                {
                    PatientId = claim,
                };
                cartrepo.AddOne(newcart);
                return BadRequest("there was no cart for this user Please try again");
            }
                var product = productrepo.FindById(productId);
                var addproduct = new CartProductHave()
                {
                    Cart = cart,
                    Product= product,
                    Quantity = quantity
                };
                cart.Products.Add(addproduct);
                cartrepo.UpdateOne(cart);
            return Ok($"Added {product.Name} to cart succesfully");
        }
    }
}
