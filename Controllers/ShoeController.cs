using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoe.Api.Models;
using Shoe.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
namespace Shoe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
      
        private readonly IShoeRepository _shoeRepository;

        public ShoeController(IShoeRepository shoeRepository,IWebHostEnvironment env)
        {
            _env = env;
            
            _shoeRepository = shoeRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllShoes()
        {
            var shoes = await _shoeRepository.GetShoesByIdAsync();
            return Ok(shoes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoeById([FromRoute] int id)
        {
            var shoe = await _shoeRepository.GetShoeByIdAsync(id);
            if (shoe == null)
            {
                return NotFound();
            }
            return Ok(shoe);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewShoe([FromBody] ShoeModel shoeModel)
        {
            var id = await _shoeRepository.AddShoeAsync(shoeModel);
            return CreatedAtAction(nameof(GetShoeById), new { id = id, Controller = "Shoes" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShoe([FromBody] ShoeModel shoeModel, [FromRoute] int id)
        {
            await _shoeRepository.UpdateShoe(id, shoeModel);
            return Ok();


        }
        [Route("saveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httprequest = Request.Form;
                var postedFile = httprequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPPath = _env.ContentRootPath + "/photos/" + filename;
                using (var stream = new FileStream(physicalPPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            
            catch
            {
                return new JsonResult("anonymous.png");
            }

            }

        }
    }


