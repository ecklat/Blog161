using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Animax.Models;

namespace Animax.Models
{
    public class Context : IdentityDbContext<Membro>
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Anime> Anime { get; set; }

        public DbSet<Mensagem> Mensagem { get; set; }

        public DbSet<Comentario> Comentario { get; set; }
    }
}
