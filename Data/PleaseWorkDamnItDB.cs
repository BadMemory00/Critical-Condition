using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PleaseWorkDamnIt.Models;

namespace PleaseWorkDamnIt.Data
{
    public class PleaseWorkDamnItDB : DbContext
    {
        public PleaseWorkDamnItDB (DbContextOptions<PleaseWorkDamnItDB> options)
            : base(options)
        {
        }

        public DbSet<Device> Device { get; set; }


    }
}
