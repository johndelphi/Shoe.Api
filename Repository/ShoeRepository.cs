using Microsoft.EntityFrameworkCore;
using Shoe.Api.Data;
using Shoe.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Api.Repository
{
    public class ShoeRepository:IShoeRepository
    {
        private readonly ShoeContext context;

        public ShoeRepository(ShoeContext context)
        {
            this.context = context;
        }
        public async Task<List<ShoeModel>> GetShoesByIdAsync()
        {
            var records = await context.Shoes.Select(x=> new ShoeModel()
            {
                Id= x.Id,
                Name=x.Name,
                Colour=x.Colour,
                Description=x.Description,
                ShoeCount=x.ShoeCount
            }).ToListAsync();
            return records;
        }
        public async Task<ShoeModel> GetShoeByIdAsync(int shoeId)
        {
            var records = await context.Shoes.Where(x=>x.Id==shoeId).Select(x => new ShoeModel()
            {
                Id = x.Id,
                Name = x.Name,
                Colour = x.Colour,
                Description = x.Description,
                ShoeCount = x.ShoeCount
            }).FirstOrDefaultAsync();
            return records;
        }
        public async Task<int> AddShoeAsync(ShoeModel shoeModel)
        {
            var shoe = new Shoes()
            { Name= shoeModel.Name,
             Colour=shoeModel.Colour,
             Description=shoeModel.Description,
             ShoeCount=shoeModel.ShoeCount
            
            };
            context.Shoes.Add(shoe);
           await context.SaveChangesAsync();
            return shoe.Id;


        }

     
    }
}
