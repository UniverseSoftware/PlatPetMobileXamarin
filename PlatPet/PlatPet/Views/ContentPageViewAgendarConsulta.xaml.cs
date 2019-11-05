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
        CadastroUsuarioViewModel cadastroUsuarioVieModel;
        CadastroEmpresaViewModel cadastroEmpresaViewModel;
        CadastroPetViewModel CadastroPetViewModel;
		public ContentPageViewAgendarConsulta ()
		{
			InitializeComponent ();

            var lstPet = new List<string>();
            lstPet.Add("Alfredo");
            lstPet.Add("Valentina");
            lstPet.Add("Pistolinha");
            lstPet.Add("Maria do Rosario");
            ;

            var pet = new Picker { Title = "Selecione seu Pet" };
            pet.ItemsSource = lstPet;


            var lstServico = new List<string>();
            lstServico.Add("30,00 Banho");
            lstServico.Add("35,00 Banho Tosa");
            
            

            var servico = new Picker { Title = "Selecione seu Pet" };
            servico.ItemsSource = lstServico;

            var lstPagamento = new List<string>();
            lstPagamento.Add("Dinheiro");
            lstPagamento.Add("Cartão de Crédito");
            lstPagamento.Add("Cartão de Débito");
            lstPagamento.Add("PetCash");
           

            var pagamento = new Picker { Title = "Selecione seu Pet" };
            pagamento.ItemsSource = lstPagamento;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
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