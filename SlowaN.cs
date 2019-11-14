using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Orto
{
    class SlowaN:DbContext{
        public DbSet<Przyklady>BazaSlow {get; set;}

         protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");
    }
}