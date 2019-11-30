using PlatPet.ViewModel.Opcao;
using PlatPet.Views.Cadastros;
using PlatPet.Views.Visualizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace PlatPet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPageViewTelaInicial : TabbedPage
    {
        OpcaoViewModel opcaoViewModel;
        public TabbedPageViewTelaInicial()
        {
            InitializeComponent();
            opcaoViewModel = new OpcaoViewModel();
            BindingContext = opcaoViewModel;
            var mapa = new Map(MapSpan.FromCenterAndRadius(new Position(-23.4945044, -46.5909981), Distance.FromKilometers(1)));
            MapContainer.Children.Add(mapa);

        }
        //async void Banho(object sender, EventArgs e)
        //{
        //    string msg = "Tela em produção";
        //    await DisplayAlert("Informação", msg, "OK");
        //    await Navigation.PushAsync(new ContentPageViewAgendarConsulta());
        //}

        //async void Consulta(object sender, EventArgs e)
        //{
        //    string msg = "Tela em produção";
        //    await DisplayAlert("Informação", msg, "OK");
        //    await Navigation.PushAsync(new ContentPageViewAgendarConsulta());
        //}

        async void Adestramento(object sender, EventArgs e)
        {
            string msg = "Em produção!";
            await DisplayAlert("Informação", msg, "OK");
        }

        async void Servico(object sender, EventArgs e)
        {
            string msg = "Em produção!";
            await DisplayAlert("Informação", msg, "OK");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            MessagingCenter.Subscribe<string>(this, "InformacaoCRUD", async (msg) =>
            {
                await Navigation.PushAsync(new ContentListViewEmpresas("Selecione uma Empresa"));
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "InformacaoCRUD");
        }
    }
}