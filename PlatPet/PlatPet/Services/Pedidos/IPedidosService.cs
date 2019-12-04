using PlatPet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PlatPet.Services.Pedidos
{
    public interface IPedidosService
    {
        Task<ObservableCollection<Pedido>> GetPedidoAsync(Pedido pd);

        Task<ObservableCollection<Pedido>> GetPedidoAsync();

        Task<ObservableCollection<Pedido>> GetPedidoIdAsync(Pedido pd);

        Task<Pedido> PostPedidoAsync(Pedido pd);

        Task<Pedido> PutPedidoAsync(Pedido pd);

        Task<Pedido> DeletePedidoAsync(int pedidoId);
    }
}
