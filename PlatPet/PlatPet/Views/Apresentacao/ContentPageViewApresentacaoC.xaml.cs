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
	public partial class ContentPageViewApresentacaoC : ContentPage
	{
		public ContentPageViewApresentacaoC ()
		{
			InitializeComponent ();
		}

        async void Pular(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContentPageViewApresentacaoC());
        }

        async void Proximo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MasterDetailsPageView());
        }
    }
}