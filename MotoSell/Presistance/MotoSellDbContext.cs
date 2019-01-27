using Microsoft.EntityFrameworkCore;
using MotoSell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoSell.Presistance
{
    public class MotoSellDbContext : DbContext
    {
        public MotoSellDbContext(DbContextOptions<MotoSellDbContext> options) : base(options)
        {

        }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }

    }
}

