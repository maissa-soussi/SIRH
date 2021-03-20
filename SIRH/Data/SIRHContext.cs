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
    }
}
