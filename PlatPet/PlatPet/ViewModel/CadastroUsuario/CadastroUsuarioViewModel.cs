using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PlatPet.Models;
using System.Windows.Input;
using PlatPet.Services.UsuarioPessoas;

namespace PlatPet.ViewModel.CadastroUsuario
{
    public class CadastroUsuarioViewModel : BaseViewModel
    {
        private IUsuarioPessoaService uService = new UsuarioPessoaService();

        private UsuarioPessoa UsuarioPessoa;
        public ICommand GravarCommand { get; set; }
        public ICommand NovoCommand { get; set; }


        public CadastroUsuarioViewModel()
        {
            RegistrarCommands();
            UsuarioPessoa = new UsuarioPessoa();
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
            var ehNovoUsuario = (UsuarioPessoa.IdEP == 0 ? true : false);
            UsuarioPessoa.TipoUsuario = 2;
            UsuarioPessoa.StatusUsuario = 1;
            UsuarioPessoa.IdUsuario = 0;
            await uService.PostUsuarioPessoaAsync(UsuarioPessoa);

            //Chamada ao método que limpa os campos da tela
            AtualizarPropriedadesParaVisao(ehNovoUsuario);
        }

        //Método que limpa as propriedades da ViewModel, que por sua vez, limpa a View
        private void AtualizarPropriedadesParaVisao(bool ehNovoObjeto)
        {
             if (ehNovoObjeto)
            {
                this.Nome = string.Empty;
                this.Sobrenome = string.Empty;
                this.Usuario = string.Empty;
                this.Senha = string.Empty;
                this.Nome = string.Empty;
                this.Sobrenome = string.Empty;
                this.CPF = string.Empty;
                this.Telefone = string.Empty;
                this.Email = string.Empty;
                this.Endereco = string.Empty;
                this.UsuarioPessoa = new UsuarioPessoa();
            }
        }

        public string Usuario
        {
            get { return this.UsuarioPessoa.UserUsuario; }
            set
            {
                this.UsuarioPessoa.UserUsuario = value;
                OnPropertyChanged();
            }
        }

        public string Nome
        {
            get { return this.UsuarioPessoa.NomeEP; }
            set
            {
                //Atribuirá valor a propriedade
                this.UsuarioPessoa.NomeEP = value;

                //Atuálizará a propriedade ligada a view
                //Método presente na classe herdada
                OnPropertyChanged();
            }
        }

        public string Sobrenome
        {
            get { return this.UsuarioPessoa.SnomeEP; }
            set
            {
                this.UsuarioPessoa.SnomeEP = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get { return this.UsuarioPessoa.PassUsuario; }
            set
            {
                this.UsuarioPessoa.PassUsuario = value;
                OnPropertyChanged();
            }
        }

        public string CPF
        {
            get { return this.UsuarioPessoa.CGCEP; }
            set
            {
                this.UsuarioPessoa.CGCEP = value;
                OnPropertyChanged();
            }
        }

        public string Telefone
        {
            get { return this.UsuarioPessoa.TelEP; }
            set
            {
                this.UsuarioPessoa.TelEP = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return this.UsuarioPessoa.EmailEP; }
            set
            {
                this.UsuarioPessoa.EmailEP = value;
                OnPropertyChanged();
            }
        }

        public string Endereco
        {
            get { return this.UsuarioPessoa.EndEP; }
            set
            {
                this.UsuarioPessoa.EndEP = value;
                OnPropertyChanged();
            }
        }

    }
}
