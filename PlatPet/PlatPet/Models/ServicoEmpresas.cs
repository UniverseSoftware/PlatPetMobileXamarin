using System;
using System.Collections.Generic;
using System.Text;

namespace PlatPet.Models
{
    public class ServicoEmpresas
    {
        public int IdServicoEmpresa { get; set; }
        public int IdEmpresa { get; set; }
        public int IdServico { get; set; }
        public string VlServicoEmpresa { get; set; }
        public string NomeServico { get; set; }
    }
}
