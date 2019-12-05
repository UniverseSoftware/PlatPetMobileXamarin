using System;
using System.Collections.Generic;
using System.Text;

namespace PlatPet.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPessoa { get; set; }
        public int IdPagamento { get; set; }
        public int IdPet { get; set; }
        public double TotPedido { get; set; }
    }
}
