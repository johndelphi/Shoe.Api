using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoe.Api.Models;
using Shoe.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeController : ControllerBase
    {
        private readonly IShoeRepository _shoeRepository;

        public ShoeController(IShoeRepository shoeRepository)
        {
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
        public async Task<IActionResult> AddNewShoe([ FromBody] ShoeModel shoeModel)
        {
            var id = await _shoeRepository.AddShoeAsync(shoeModel);
            return CreatedAtAction(nameof(GetShoeById), new { id = id, Controller = "Shoes" }, id);
        }

    }
}

