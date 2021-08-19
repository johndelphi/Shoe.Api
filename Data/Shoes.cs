using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Api.Data
{
    public class Shoes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }
        public int ShoeCount { get; set; }

    }
}
