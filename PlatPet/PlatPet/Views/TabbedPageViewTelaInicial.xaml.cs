using PlatPet.ViewModel.Opcao;
using PlatPet.Views.Cadastros;
using PlatPet.Views.Visualizacao;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
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
            GetActualLocationCommand = new Command(async () => await GetActualLocation());
            //var mapa = new Map(MapSpan.FromCenterAndRadius(new Position(-23.5196648, -46.5962384), Distance.FromKilometers(1)));
             
           //MapContainer.Children.Add(mapa);

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
            GetActualLocationCommand.Execute(null);
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


        public static readonly BindableProperty GetActualLocationCommandProperty =
            BindableProperty.Create(nameof(GetActualLocationCommand), typeof(ICommand), typeof(TabbedPageViewTelaInicial), null, BindingMode.TwoWay);

        public ICommand GetActualLocationCommand
        {
            get { return (ICommand)GetValue(GetActualLocationCommandProperty); }
            set { SetValue(GetActualLocationCommandProperty, value); }
        }

        async Task GetActualLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    mapa.MoveToRegion(MapSpan.FromCenterAndRadius(
                        new Position(location.Latitude, location.Longitude), Distance.FromMiles(0.3)));

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Unable to get actual location", "Ok");
            }
        }
    }
}