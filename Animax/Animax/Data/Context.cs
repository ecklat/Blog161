using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Animax.Models;

namespace Animax.Models
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Animax.Models.Anime> Anime { get; set; }

        public DbSet<Animax.Models.Mensagem> Mensagem { get; set; }

        public DbSet<Animax.Models.Comentario> Comentario { get; set; }
    }
}
