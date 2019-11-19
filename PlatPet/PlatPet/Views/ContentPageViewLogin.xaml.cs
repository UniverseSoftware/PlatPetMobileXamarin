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
            Entrar();
        }

        public async void Entrar()
        {
            await Navigation.PushAsync(new TabbedPageViewTelaInicial());
        }
    }
}