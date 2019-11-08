using PlatPet.Models;
using PlatPet.ViewModel.Agendamento;
using PlatPet.ViewModel.CadastroUsuario;
using PlatPet.ViewModel.Pets;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlatPet.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContentPageViewAgendarConsulta : ContentPage
	{
        AgendamentoConsultaViewModel agendamentoConsultaViewModel;
        public ContentPageViewAgendarConsulta()
        {
            InitializeComponent();
            agendamentoConsultaViewModel = new AgendamentoConsultaViewModel();
            BindingContext = agendamentoConsultaViewModel;

            var lstServico = new List<string>();
            lstServico.Add("30,00 Banho");
            lstServico.Add("35,00 Banho Tosa");
            
            

            var servico = new Picker { Title = "Selecione seu Pet" };
            servico.ItemsSource = lstServico;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await agendamentoConsultaViewModel.Chamar();
            });
            MessagingCenter.Subscribe<string>(this, "InformacaoCRUD", async (msg) =>
            {
                await DisplayAlert("Informação", msg, "OK");
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
        }
    }
}