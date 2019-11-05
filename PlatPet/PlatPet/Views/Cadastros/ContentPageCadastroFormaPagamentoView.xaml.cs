using PlatPet.Models;
using PlatPet.Services.Pagamentos;
using PlatPet.ViewModel.Pagamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlatPet.Views.Cadastros
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContentPageCadastroFormaPagamentoView : ContentPage
	{
        CadastroFormaPagarViewModel cadastroFormaPagarViewModel;
		public ContentPageCadastroFormaPagamentoView ()
		{
			InitializeComponent ();
            cadastroFormaPagarViewModel = new CadastroFormaPagarViewModel();
            BindingContext = cadastroFormaPagarViewModel;
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            cadastroFormaPagarViewModel.ChamarAsync();

        }



    }
}