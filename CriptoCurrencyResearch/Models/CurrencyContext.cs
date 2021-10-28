using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriptoCurrencyResearch.Models
{
    public class CurrencyContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }

        public CurrencyContext(DbContextOptions<CurrencyContext> options) : base(options)
        {

        }
    }
}
