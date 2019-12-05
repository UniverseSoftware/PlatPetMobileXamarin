using PlatPet.Models;
using PlatPet.ViewModel.Agendamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlatPet.Views.Visualizacao
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContentListViewAgendamento : ContentPage
	{
        ListaAgendamentoViewModel agenda;
        private Pedido ped;
        public ContentListViewAgendamento ()
		{
			InitializeComponent ();
            ped = new Pedido();
            agenda = new ListaAgendamentoViewModel();
            BindingContext = agenda;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(async () =>
            {
                await agenda.ObterPedidoAsync();
            });
            MessagingCenter.Subscribe<Pedido>(this, "Mostrar", async (ped) =>
            {
                await Navigation.PushAsync(new ContentPageViewAgendarConsulta(ped, (ped.IdPedido == 0) ? "Novo Pedido" : "Alterar Pedido"));
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "Mostrar");
        }
    }
}