using GScriptNuget;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GScriptApi.Data
{
    public class ScriptsContext : DbContext
    {
        public ScriptsContext(DbContextOptions<ScriptsContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<App> Apps { get; set; }
        public DbSet<Script> Scripts { get; set; }
    }
}
