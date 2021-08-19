using Shoe.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shoe.Api.Repository
{
    public interface IShoeRepository
    {
        Task<List<ShoeModel>> GetShoesByIdAsync();
        Task<ShoeModel> GetShoeByIdAsync(int shoeId);
        Task<int> AddShoeAsync(ShoeModel shoeModel);

    }
}