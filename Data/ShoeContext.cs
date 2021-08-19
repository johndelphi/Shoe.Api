﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Api.Data
{
    public class ShoeContext : DbContext
    {
        public ShoeContext(DbContextOptions<ShoeContext> options)
            :base(options)
        {

        }
        public DbSet<Shoes> Shoes { get; set; }
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ShoeShopApi;Intergrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
