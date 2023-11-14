using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuckTI.Models;

namespace BuckTI.Data
{
    public class dbContext : DbContext
    {
        public dbContext (DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public DbSet<BuckTI.Models.CadClientes> CadClientes { get; set; } = default!;

        public DbSet<BuckTI.Models.CadSetores> CadSetores { get; set; } = default!;

        public DbSet<BuckTI.Models.CadSoftwares> CadSoftwares { get; set; } = default!;

        public DbSet<BuckTI.Models.InventarioMaquinas> InventarioMaquinas { get; set; } = default!;
    }
}
