using PlatPet.ViewModel.Opcao;
using PlatPet.Views.Cadastros;
using PlatPet.Views.Visualizacao;
using Plugin.Geolocator;
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
            //Mapa();
            var mapa = new Map(MapSpan.FromCenterAndRadius(new Position(-23.5196648, -46.5962384), Distance.FromKilometers(1)));
            MapContainer.Children.Add(mapa);

        }
        double latitude;
        double longitude;
        protected async Task Mapa()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync();
           
            latitude = position.Latitude;
            longitude = position.Longitude;
        }

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