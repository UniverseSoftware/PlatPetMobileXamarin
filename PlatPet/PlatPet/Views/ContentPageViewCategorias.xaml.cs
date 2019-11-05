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
	public partial class ContentPageViewCategorias : ContentPage
	{
		public ContentPageViewCategorias ()
		{
			InitializeComponent ();
		}

        async void Banho(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContentPageViewAgendarConsulta());
        }
    }
}