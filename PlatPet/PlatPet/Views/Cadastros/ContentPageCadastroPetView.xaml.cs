using PlatPet.ViewModel.Pets;
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
	public partial class ContentPageCadastroPetView : ContentPage
	{
        //ListaPetViewModel listaPetViewModel;
        CadastroPetViewModel cadastroPetViewModel;
		public ContentPageCadastroPetView ()
		{
			InitializeComponent ();
            cadastroPetViewModel = new CadastroPetViewModel();
            //listaPetViewModel = new ListaPetViewModel();
            BindingContext = cadastroPetViewModel;
            //BindingContext = listaPetViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await cadastroPetViewModel.Popular();
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