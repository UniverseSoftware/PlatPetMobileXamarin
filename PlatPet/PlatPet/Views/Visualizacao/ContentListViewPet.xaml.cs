using PlatPet.Models;
using PlatPet.ViewModel.Pets;
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
	public partial class ContentListViewPet : ContentPage
	{
        ListaPetViewModel listaPetViewModel;
		public ContentListViewPet ()
		{
			InitializeComponent ();
            listaPetViewModel = new ListaPetViewModel();
            BindingContext = listaPetViewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(async () =>
            {
                await listaPetViewModel.ObterPetAsync();
            });
        }

    }
}