using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Animax.Models
{
    public class Mensagem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [DisplayName("Criado em:")]
        public DateTime CreatedDate { get; set; }
        [ForeignKey("AnimeId")]
        public Anime Anime { get; set; }
    }
}
