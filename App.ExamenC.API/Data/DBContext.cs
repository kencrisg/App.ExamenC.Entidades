using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using App.ExamenC.Entidades;

    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<App.ExamenC.Entidades.Conferencia> Conferencia { get; set; } = default!;
        public DbSet<App.ExamenC.Entidades.Ponente> Ponente { get; set; } = default!;
    }
