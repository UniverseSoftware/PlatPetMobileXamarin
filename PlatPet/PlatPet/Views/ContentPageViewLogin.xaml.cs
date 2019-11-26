using PlatPet.ViewModel.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlatPet.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContentPageViewLogin : ContentPage
	{
        LoginViewModel loginViewModel;
		public ContentPageViewLogin ()
		{
			InitializeComponent ();
            loginViewModel = new LoginViewModel();
            BindingContext = loginViewModel;
		}

        public void Login(object sender, EventArgs e)
        {
            //Entrar();
        }

        public async void Entrar()
        {
            await Navigation.PushModalAsync(new MasterDetailsPageView());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "InformacaoCRUD", async (msg) =>
            {
                await DisplayAlert("Informação", msg, "OK");
                if (msg == "Bem Vindo!")
                {
                    await Navigation.PushModalAsync(new MasterDetailsPageView());
                }
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();            
            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
        }

        async void Cadastro(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ContentPageCadastroUsuarioView());
        }
    }
}