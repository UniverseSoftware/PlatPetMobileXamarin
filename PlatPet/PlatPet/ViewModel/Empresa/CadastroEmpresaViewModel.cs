using PlatPet.Models;
using PlatPet.Services.Empresas;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatPet.ViewModel.CadastroUsuario
{
    public class CadastroEmpresaViewModel : BaseViewModel
    {
        private IEmpresaService uService = new EmpresaService();

        private Empresa Empresa;
        private ICommand GravarCommand { get; set; }
        private ICommand NovoCommand { get; set; }

        public CadastroEmpresaViewModel()
        {
            RegistrarCommands();
            Empresa = new Empresa();
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
            var ehNovoUsuario = (Empresa.IdEmpresa == 0 ? true : false);

            await uService.PostEmpresaAsync(Empresa);

            //Chamada ao método que limpa os campos da tela
            AtualizarPropriedadesParaVisao(ehNovoUsuario);
        }

        //Método que limpa as propriedades da ViewModel, que por sua vez, limpa a View
        private void AtualizarPropriedadesParaVisao(bool ehNovoObjeto)
        {
            if (ehNovoObjeto)
            {
                this.Razao = string.Empty;
                this.NomeFantasia = string.Empty;
                this.CNPJ = string.Empty;
                this.Email = string.Empty;
                this.Telefone = string.Empty;
                this.Endereco = string.Empty;
                this.Empresa = new Empresa();
            }
        }

        public string Razao
        {
            get { return this.Empresa.RazaoEmpresa; }
            set
            {
                this.Empresa.RazaoEmpresa = value;
                OnPropertyChanged();
            }
        }

        public string NomeFantasia
        {
            get { return this.Empresa.NFantasiaEmpresa; }
            set
            {
                this.Empresa.NFantasiaEmpresa = value;
                OnPropertyChanged();
            }
        }

        public string CNPJ
        {
            get { return this.Empresa.CNPJEmpresa; }
            set
            {
                this.Empresa.CNPJEmpresa = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return this.Empresa.EmailEmpresa; }
            set
            {
                this.Empresa.EmailEmpresa = value;
                OnPropertyChanged();
            }
        }

        public string Telefone
        {
            get { return this.Empresa.TelEmpresa; }
            set
            {
                this.Empresa.TelEmpresa = value;
                OnPropertyChanged();
            }
        }

        public string Endereco
        {
            get { return this.Empresa.EndEmpresa; }
            set
            {
                this.Empresa.EndEmpresa = value;
                OnPropertyChanged();
            }
        }
    }
}
