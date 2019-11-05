using PlatPet.ViewModel.CadastroUsuario;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlatPet.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContentPageCadastroUsuarioView : ContentPage
	{
        CadastroUsuarioViewModel cadastroUsuarioViewModel;
        public ContentPageCadastroUsuarioView ()
		{
			InitializeComponent ();
            cadastroUsuarioViewModel = new CadastroUsuarioViewModel();
            BindingContext = cadastroUsuarioViewModel;
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