using Egyptian_association_of_cieliac_patients_api.DTO;
using Egyptian_association_of_cieliac_patients_api.Models;
using Egyptian_association_of_cieliac_patients_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Egyptian_association_of_cieliac_patients_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawMatrialController : ControllerBase
    {
        private readonly ICRUDRepo<RawMaterial> materialrepo;
        private readonly ICRUDRepo<AssosiationBranch> assosiation_Crud;
        private readonly IWebHostEnvironment hosting;

        public RawMatrialController(ICRUDRepo<RawMaterial> materialrepo, ICRUDRepo<AssosiationBranch> assosiation_crud, IWebHostEnvironment hosting)
        {
            this.materialrepo = materialrepo;
            assosiation_Crud = assosiation_crud;
            this.hosting = hosting;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var rawmaterials = materialrepo.FindAll();
            List<RawMaterialDto> RawmaterialDtos = new List<RawMaterialDto>();
            if (rawmaterials != null)
            {
                foreach (var rawmaterial in rawmaterials)
                {
                    RawMaterialDto RawmaterialDto = new RawMaterialDto();
                    RawmaterialDto.Id = rawmaterial.MaterialId;
                    RawmaterialDto.Name = rawmaterial.Name;
                    RawmaterialDto.Details = rawmaterial.Details;
                    RawmaterialDto.Price = rawmaterial.Price;
                    RawmaterialDto.ImagePath = rawmaterial.Images.FirstOrDefault().ImagePath;
                    RawmaterialDtos.Add(RawmaterialDto);
                }
                return Ok(RawmaterialDtos);
            }
            else { return NotFound(); }
        }
        [HttpGet("{id:int}", Name = "GetOneRawmaterialRoute")]
        public IActionResult Details(int id)
        {
            var rawmaterial = materialrepo.FindById(id);
            RawMaterialDto RawmaterialDto = new RawMaterialDto();
            if (rawmaterial != null)
            {
                RawmaterialDto.Id = rawmaterial.MaterialId;
                RawmaterialDto.Name = rawmaterial.Name;
                RawmaterialDto.Details = rawmaterial.Details;
                RawmaterialDto.Price = rawmaterial.Price;
                RawmaterialDto.ImagePath = rawmaterial.Images.FirstOrDefault().ImagePath;
                return Ok(RawmaterialDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
