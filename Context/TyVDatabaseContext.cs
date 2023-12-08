using AppTyV.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTyV.Context
{
    public class TyVDatabaseContext : DbContext
    {
        public
       TyVDatabaseContext(DbContextOptions<TyVDatabaseContext> options)
       : base(options)
        {
        }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Partido> Partidos { get; set; }


    }
}
