using PlatPet.Models;
using PlatPet.Services.Pets;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatPet.ViewModel.Pets
{
    public class CadastroPetViewModel : BaseViewModel
    {
        private IPetService uService = new PetService();

        private Pet Pet;
        public ICommand GravarCommand { get; set; }
        public ICommand NovoCommand { get; set; }

        public CadastroPetViewModel()
        {
            RegistrarCommands();
            Pet = new Pet();
        }

        private void RegistrarCommands()
        {
            GravarCommand = new Command(async () =>
            {
                await GravarAsync();
                MessagingCenter.Send<string>("Dado salvo com sucesso.", "InformacaoCRUD");
            });
        }

        private async Task GravarAsync()
        {
            var ehNovoUsuario = (Pet.IdPet == 0 ? true : false);
            Pet.IdPessoa = 18;
            await uService.PostPetAsync(Pet);

            //Chamada ao método que limpa os campos da tela
            AtualizarPropriedadesParaVisao(ehNovoUsuario);
        }

        //Método que limpa as propriedades da ViewModel, que por sua vez, limpa a View
        private void AtualizarPropriedadesParaVisao(bool ehNovoObjeto)
        {
            if (ehNovoObjeto)
            {
                this.NomePet = string.Empty;
                this.RG = string.Empty;
                this.SubEspecie = 0;
                this.Observacao = string.Empty;
                this.Pet = new Pet();
            }
        }
        public string NomePet
        {
            get { return this.Pet.NomePet; }
            set
            {
                this.Pet.NomePet = value;
                OnPropertyChanged();
            }
        }

        public int SubEspecie
        {
            get { return this.Pet.IdSubespecie; }
            set
            {
                this.Pet.IdSubespecie = value;
                OnPropertyChanged();
            }
        }

        public string RG
        {
            get { return this.Pet.RGPet; }
            set
            {
                this.Pet.RGPet = value;
                OnPropertyChanged();
            }
        }

        public string Observacao
        {
            get { return this.Pet.ObsPet; }
            set
            {
                this.Pet.ObsPet = value;
                OnPropertyChanged();
            }
        }
    }
}
