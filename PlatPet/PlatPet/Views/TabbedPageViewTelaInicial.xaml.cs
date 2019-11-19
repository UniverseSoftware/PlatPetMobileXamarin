using PlatPet.Views.Cadastros;
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
        public TabbedPageViewTelaInicial()
        {
            InitializeComponent();

            var mapa = new Map(MapSpan.FromCenterAndRadius(new Position(-23.4945044, -46.5909981), Distance.FromKilometers(1)));
            MapContainer.Children.Add(mapa);

        }
        async void Banho(object sender, EventArgs e)
        {
            string msg = "Tela em produção";
            await DisplayAlert("Informação", msg, "OK");
            await Navigation.PushAsync(new ContentPageViewAgendarConsulta());
        }

        async void Consulta(object sender, EventArgs e)
        {
            string msg = "Tela em produção";
            await DisplayAlert("Informação", msg, "OK");
            await Navigation.PushAsync(new ContentPageViewAgendarConsulta());
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
    }
}