using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animax.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        [ForeignKey("MensagemId")]
        public Mensagem Mensagem { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [DisplayName("Criado em:")]
        public DateTime CreatedDate { get; set; }
        public string Autor { get; set; }
    }
}
