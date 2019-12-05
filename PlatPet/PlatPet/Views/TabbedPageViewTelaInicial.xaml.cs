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
             = true;
            MapContainer.Children.Add(mapa);

            Pin pin = new Pin
            {
                Label = "SHOP PET",
                Address = "Teste",
                Type = PinType.SearchResult,
                Position = new Position(-23.5196648, -46.5962384)
            };
            mapa.Pins.Add(pin);
        }
    

        
        double latitude;
        double longitude;
        //protected async Task Mapa()
        //{
            


        //}

        async void Adestramento(object sender, EventArgs e)
        {
            string msg = "Em produção!";
            await DisplayAlert("Informação", msg, "OK");
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            latitude = position.Latitude;
            longitude = position.Longitude;

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