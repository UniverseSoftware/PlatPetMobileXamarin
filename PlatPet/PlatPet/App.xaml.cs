using PlatPet.Views;
using PlatPet.Views.Cadastros;
using PlatPet.Views.Visualizacao;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PlatPet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new MasterDetailsPageView());
            //MainPage = new ContentListViewPet();

            //MainPage = new ContentPageViewLogin();
            MainPage = new MasterDetailsPageView();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
