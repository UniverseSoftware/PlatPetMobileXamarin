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
            //agendamentoConsultaViewModel = new AgendamentoConsultaViewModel();
            //BindingContext = agendamentoConsultaViewModel;            
        }

        public ContentPageViewAgendarConsulta(Empresa empresa, string title) : this()
        {
            this.agendamentoConsultaViewModel = new AgendamentoConsultaViewModel(empresa);
            this.BindingContext = this.agendamentoConsultaViewModel;
            this.Title = title;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await agendamentoConsultaViewModel.Popular();
            });
            MessagingCenter.Subscribe<string>(this, "InformacaoCRUD", async (msg) =>
            {
                await DisplayAlert("Informação", msg, "OK");
                await Navigation.PushModalAsync(new MasterDetailsPageView());
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await agendamentoConsultaViewModel.GravarAsync();
        }
    }
}