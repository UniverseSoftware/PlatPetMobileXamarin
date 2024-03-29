﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PlatPet.Models;

namespace PlatPet.Services.Pedidos
{
    public class PedidosService : IPedidosService
    {
        private readonly IRequest _request;
        private const string ApiUrlBase = "http://universesoftware2019.somee.com/api/Pedidos";
        private const string ApiUrlBasePessoa = "http://universesoftware2019.somee.com/api/PedidosPessoa";
        public PedidosService()
        {
            _request = new Request();
        }
        public Task<Pedido> DeletePedidoAsync(int pedidoId)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<Pedido>> GetPedidoAsync(Pedido pd)
        {
            string urlComplementar = string.Format("/{0}", pd.IdPessoa);
            ObservableCollection<Pedido> ped = await
                _request.GetAsync<ObservableCollection<Pedido>>(ApiUrlBasePessoa + urlComplementar);

            return ped;
        }

        public Task<ObservableCollection<Pedido>> GetPedidoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Pedido>> GetPedidoIdAsync(Pedido pd)
        {
            throw new NotImplementedException();
        }

        public async Task<Pedido> PostPedidoAsync(Pedido pd)
        {
            if (pd.IdPedido == 0)
            {
                return await _request.PostAsync(ApiUrlBase, pd);

            }
            else
                return await _request.PutAsync(ApiUrlBase, pd);
        }

        public Task<Pedido> PutPedidoAsync(Pedido pd)
        {
            throw new NotImplementedException();
        }
    }
}
