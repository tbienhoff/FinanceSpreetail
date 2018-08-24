using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinanceSpreetail.Models
{
    public class FinanceSpreetailContext : DbContext
    {
        public FinanceSpreetailContext (DbContextOptions<FinanceSpreetailContext> options)
            : base(options)
        {
        }

        public DbSet<FinanceSpreetail.Models.Transaction> Transaction { get; set; }
    }
}
