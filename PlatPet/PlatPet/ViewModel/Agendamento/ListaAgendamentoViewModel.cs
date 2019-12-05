using PlatPet.Models;
using PlatPet.Services.Pedidos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatPet.ViewModel.Agendamento
{
    public class ListaAgendamentoViewModel : BaseViewModel
    {
        private Pedido ped;
        private Pet pet;
        private IPedidosService pService = new PedidosService();

        public ObservableCollection<Pedido> Pedidos
        {
            get; set;
        }

        public ListaAgendamentoViewModel()
        {
            Pedidos = new ObservableCollection<Pedido>();
            ped = new Pedido();
        }

        public async Task ObterPedidoAsync()
        {            
            ped.IdPessoa = Convert.ToInt32(Application.Current.Properties["PessoaId"].ToString());
            Pedidos = await pService.GetPedidoAsync(ped);
            OnPropertyChanged(nameof(Pedidos));
            
        }

        public Pedido SelPed
        {
            get { return ped; }
            set
            {
                if (value != null)
                {
                    ped = value;
                    MessagingCenter.Send<Pedido>(ped, "Mostrar");
                }
            }
        }
    }
}
