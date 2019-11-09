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