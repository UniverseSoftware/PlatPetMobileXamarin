using System;
using System.Collections.Generic;
using System.Text;

namespace PlatPet.Models
{
    public class ServicosComEmpresa
    {
        public int IdServico { get; set; }
        public string NomeServico { get; set; }
        public string DescServico { get; set; }
        public int IdServicoEmpresa { get; set; }
        public int IdEmpresa { get; set; }
        public string VlServicoEmpresa { get; set; }
    }
}
