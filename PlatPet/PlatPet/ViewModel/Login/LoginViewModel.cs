﻿using PlatPet.Models;
using PlatPet.Services.UsuarioPessoas;
using PlatPet.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatPet.ViewModel.Login
{
    public class LoginViewModel : BaseViewModel
    {
        private UsuarioPessoa usuarioPessoa;
        private IUsuarioPessoaService uService = new UsuarioPessoaService();
        public ICommand EntrarCommand { get; set; }
        public UsuarioPessoa Usuario
        {
            get; set;
        }

        public LoginViewModel()
        {
            Usuario = new UsuarioPessoa();
            RegistrarCommands();
        }

        private void RegistrarCommands()
        {
            EntrarCommand = new Command(async () =>
            {
                await ConsultarUsuario();
            });
        }

        public async Task ConsultarUsuario()
        {
            Usuario = await uService.GetUsuarioPessoaAsync();
            OnPropertyChanged(nameof(Usuario));
            Validacao();
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

        public string User
        {
            get { return this.usuarioPessoa.UserUsuario; }
            set
            {
                this.usuarioPessoa.UserUsuario = value;
                OnPropertyChanged();
            }
        }

       

        public void Validacao()
        {
            if (usuarioPessoa.IdUsuario != null || usuarioPessoa.IdUsuario == 0)
            {
                MessagingCenter.Send<string>("Usuário e/ou Senha inválido.", "InformacaoCRUD");
            }
            else
            {
                ContentPageViewLogin login = new ContentPageViewLogin();
                login.Entrar();
            }
        }
    }
}