using Egyptian_association_of_cieliac_patients_api.DTO;
using Egyptian_association_of_cieliac_patients_api.Models;
using Egyptian_association_of_cieliac_patients_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Egyptian_association_of_cieliac_patients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICRUDRepo<Product> productrepo;
        private readonly ICRUDRepo<AssosiationBranch> assosiation_Crud;
        private readonly IWebHostEnvironment hosting;

        public ProductController(ICRUDRepo<Product> productrepo, ICRUDRepo<AssosiationBranch> assosiation_crud, IWebHostEnvironment hosting)
        {
            this.productrepo = productrepo;
            assosiation_Crud = assosiation_crud;
            this.hosting = hosting;
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
    }
}
