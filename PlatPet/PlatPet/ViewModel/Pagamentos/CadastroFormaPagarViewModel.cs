using PlatPet.Models;
using PlatPet.Services.Pagamentos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatPet.ViewModel.Pagamentos
{
    public class CadastroFormaPagarViewModel : BaseViewModel
    {
        private IFormaPagarService uService = new FormaPagarService();

        private FormaPagamento FormaPagamento;
        private ICommand GravarCommand { get; set; }
        private ICommand NovoCommand { get; set; }

        public CadastroFormaPagarViewModel()
        {
            RegistrarCommands();
            FormaPagamento = new FormaPagamento();
        }

        public async Task ChamarAsync()
        {
            await GravarAsync();
            Mensagem();
        }

        private void Mensagem()
        {
            MessagingCenter.Send<string>("Dado salvo com sucesso.", "InformacaoCRUD");
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
            var ehNovoUsuario = (FormaPagamento.IdPagemento == 0 ? true : false);

            await uService.PostFormaPagarAsync(FormaPagamento);

            //Chamada ao método que limpa os campos da tela
            AtualizarPropriedadesParaVisao(ehNovoUsuario);
        }

        private void AtualizarPropriedadesParaVisao(bool ehNovoObjeto)
        {
            if (ehNovoObjeto)
            {
                this.Descricao = string.Empty;
                this.FormaPagamento = new FormaPagamento();
            }

            
        }

        public string Descricao
        {
            get { return this.FormaPagamento.DescPagamento; }
            set
            {
                this.FormaPagamento.DescPagamento = value;
                OnPropertyChanged();
            }
        }
    }
}
