using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Animax.Models
{
    public class Membro : IdentityUser
    {
        [DisplayName("Digite seu nome:")]
        public string Nome { get; set; }
        [DisplayName("Escolha um nome de usuário:")]
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }
}
