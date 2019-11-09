using System;
using System.Collections.Generic;
using System.Text;

namespace PlatPet.Models
{
    public class Servico
    {
        public int IdServico { get; set; }
        public string NomeServico { get; set; }
        public string DescServico { get; set; }
        //public string ValorServico { get; set; } Avisar o anderson para que crie esta propriedade na API
    }
}
