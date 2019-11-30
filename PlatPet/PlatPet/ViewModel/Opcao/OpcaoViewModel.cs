using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatPet.ViewModel.Opcao
{
    public class OpcaoViewModel
    {
        public ICommand BanhoCommand { get; set; }
        public ICommand ConsultaCommand { get; set; }
        public OpcaoViewModel()
        {
            RegistrarCommands();
        }

        private void RegistrarCommands()
        {
            BanhoCommand = new Command(async () =>
            {
                await BanhoAsync();
            });
            ConsultaCommand = new Command(async () =>
            {
                await ConsultaAsync();
            });
        }

        public async Task BanhoAsync()
        {
            MessagingCenter.Send<string>("Entrar", "InformacaoCRUD");
            Application.Current.Properties["Op"] = "1";
        }
        public async Task ConsultaAsync()
        {
            MessagingCenter.Send<string>("Entrar", "InformacaoCRUD");
            Application.Current.Properties["Op"] = "2";
        }
    }
}
