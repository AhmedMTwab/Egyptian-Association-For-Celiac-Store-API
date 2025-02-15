﻿using Egyptian_association_of_cieliac_patients_api.DTO;
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
    public class RawMatrialController : ControllerBase
    {
        private readonly ICRUDRepo<RawMaterial> materialrepo;
        private readonly ICRUDRepo<Cart> cartrepo;
        private readonly ICRUDRepo<Patient> patientrepo;
        private readonly ICRUDRepo<AssosiationBranch> assosiation_Crud;
        private readonly IWebHostEnvironment hosting;
        private readonly IHttpContextAccessor httpContextAccessor;

        public RawMatrialController(ICRUDRepo<RawMaterial> materialrepo,ICRUDRepo<Cart> cartrepo, ICRUDRepo<Patient> patientrepo, ICRUDRepo<AssosiationBranch> assosiation_crud, IWebHostEnvironment hosting, IHttpContextAccessor httpContextAccessor)
        {
            this.materialrepo = materialrepo;
            this.cartrepo = cartrepo;
            this.patientrepo = patientrepo;
            assosiation_Crud = assosiation_crud;
            this.hosting = hosting;
            this.httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var rawmaterials = materialrepo.FindAll().ToList();
           
            if (rawmaterials != null)
            {
                List<RawMaterialDto> RawmaterialDtos = new List<RawMaterialDto>();
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
        [Authorize]
        [HttpPost("addtocart/{materialId:int}/{quantity:int}", Name = "MaterialToCartRoute")]
        public IActionResult addmaterialtocart(int materialId,int quantity)
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
            var material = materialrepo.FindById(materialId);
            foreach (var item in cart.RawMaterials)
            {
                if (item.MaterialId == material.MaterialId)
                {
                    var oldcartmaterial = cart.RawMaterials.FirstOrDefault(d => d.MaterialId == item.MaterialId);
                    oldcartmaterial.Quantity += quantity;
                    cartrepo.UpdateOne(cart);
                    return Ok($"added more {quantity}  {material.Name} to cart");
                }
            }
            var addmaterial = new CartMaterialHave()
            {
                Cart = cart,
                Material = material,
                Quantity= quantity,
                
            };
            cart.RawMaterials.Add(addmaterial);
            cartrepo.UpdateOne(cart);
            return Ok($"Added {material.Name} to cart succesfully");
        }
        [HttpDelete("removefromcart/{id:int}")]
        public IActionResult romovematerialfromcart(int id)
        {
            var material = materialrepo.FindById(id);
            int claim = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID").Value);
            var cart = patientrepo.FindAll().FirstOrDefault(d => d.PatientId == claim).Cart;
            var removematerial = cart.RawMaterials.FirstOrDefault(d => d.MaterialId == material.MaterialId);
            cart.RawMaterials.Remove(removematerial);
            cartrepo.UpdateOne(cart);
            return Ok($"{material.Name} removed from cart succesfully");
        }
    }
}
