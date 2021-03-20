using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIRH.Models;

namespace SIRH.Data
{
    public class SIRHContext : DbContext
    {
        public SIRHContext (DbContextOptions<SIRHContext> options)
            : base(options)
        {
        }

        public DbSet<SIRH.Models.User> User { get; set; }

        public DbSet<SIRH.Models.Country> Country { get; set; }

        public DbSet<SIRH.Models.ContratType> ContratType { get; set; }

        public DbSet<SIRH.Models.Currency> Currency { get; set; }

        public DbSet<SIRH.Models.Experience> Experience { get; set; }
    }
}
