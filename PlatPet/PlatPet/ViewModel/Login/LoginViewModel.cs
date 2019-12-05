using PlatPet.Models;
using PlatPet.Services.UsuarioPessoas;
using PlatPet.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Security.Cryptography;
using System.Text;

namespace PlatPet.ViewModel.Login
{
    public class LoginViewModel : BaseViewModel
    {
        private UsuarioPessoa usuarioPessoa;
        private IUsuarioPessoaService uService = new UsuarioPessoaService();
        public ICommand EntrarCommand { get; set; }

        public LoginViewModel()
        {
            RegistrarCommands();
            usuarioPessoa = new UsuarioPessoa();           
        }

        private void RegistrarCommands()
        {
            EntrarCommand = new Command(async () =>
            {
                await ConsultarUsuario();
            });
        }
        string senha;
        public async Task ConsultarUsuario()
        {
            senha = usuarioPessoa.PassUsuario;
            usuarioPessoa = await uService.GetUsuarioPessoaAsync(usuarioPessoa.UserUsuario);
            OnPropertyChanged(nameof(usuarioPessoa));
            Validacao();
        }

        public string User
        {
            get { return this.usuarioPessoa.UserUsuario; }
            set
            {
                this.usuarioPessoa.UserUsuario = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get { return this.usuarioPessoa.PassUsuario; }
            set
            {
                this.usuarioPessoa.PassUsuario = value;
                OnPropertyChanged();
            }
        }

        public void Validacao()
        {
            if (usuarioPessoa == null)
            {
                usuarioPessoa = new UsuarioPessoa();
            }

            string crip = MD5Hash(senha);
            //crip = crip.ToUpper();            

            if (usuarioPessoa.IdUsuario == null || usuarioPessoa.IdUsuario == 0 || usuarioPessoa.PassUsuario != crip)
            {
                MessagingCenter.Send<string>("Usuário e/ou Senha inválido.", "InformacaoCRUD");
                AtualizarPropriedadesParaVisao();
            }
            else
            {
                ContentPageViewLogin login = new ContentPageViewLogin();
                MessagingCenter.Send<string>("Bem Vindo!", "InformacaoCRUD");
                Application.Current.Properties["PessoaId"] = usuarioPessoa.IdEP;
                Application.Current.Properties["UsuId"] = usuarioPessoa.IdUsuario;
                Application.Current.Properties["Nome"] = usuarioPessoa.NomeEP;
            }
        }                
        
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void AtualizarPropriedadesParaVisao()
        {
         
                this.User = string.Empty;
                this.Senha = string.Empty;         
                this.usuarioPessoa = new UsuarioPessoa();
       
        }
    }
}
