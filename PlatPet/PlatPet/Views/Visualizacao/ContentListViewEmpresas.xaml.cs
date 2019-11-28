using PlatPet.Models;
using PlatPet.ViewModel.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlatPet.Views.Visualizacao
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentListViewEmpresas : ContentPage
    {
        ListaEmpresasViewModel listaEmpresasViewModel;
        public ContentListViewEmpresas()
        {
            InitializeComponent();
            listaEmpresasViewModel = new ListaEmpresasViewModel();
            BindingContext = listaEmpresasViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(async () =>
            {
                await listaEmpresasViewModel.ObterEmpresa();
            });
            MessagingCenter.Subscribe<Empresa>(this, "Mostrar", async (empresa) =>
            {
                await Navigation.PushAsync(new ContentPageViewAgendarConsulta(empresa, (empresa.NFantasiaEmpresa == "" || empresa.NFantasiaEmpresa == null) ? "Novo Pet" : "Alterar Pet"));
            });
        }
    }
}