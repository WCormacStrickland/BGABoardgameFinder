#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BGAWebApp.Models;

namespace BGAWebApp.Data
{
    public class BGAWebAppContext : DbContext
    {
        public BGAWebAppContext (DbContextOptions<BGAWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<BGAWebApp.Models.Game> Game { get; set; }
    }
}
