using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PlatPet.Models;
using PlatPet.Services.Pagamentos;
using PlatPet.Services.Pets;
using PlatPet.Services.Servicos;
using PlatPet.Services.UsuarioPessoas;

namespace PlatPet.Services.Agendamento
{
    public class AgendamentoConsultaService : IPetService, IUsuarioPessoaService, IFormaPagarService, IServicosService
    {

        #region Constantes
        private readonly IRequest _request;
        private const string ApiUrlBasePet = "http://universesoftware2019.somee.com/api/Pets";
        private const string ApiUrlBasePagamento = "http://universesoftware2019.somee.com/api/Pagamentos";
        private const string ApiUrlBaseServico = "http://universesoftware2019.somee.com/api/Servicos";

        #endregion

        public AgendamentoConsultaService()
        {
            _request = new Request();
        }

        #region Usuário Pessoa

        public Task<UsuarioPessoa> DeleteUsuarioPessoaAsync(int pessoaId)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioPessoa> GetUsuarioPessoaAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioPessoa> PostUsuarioPessoaAsync(UsuarioPessoa c)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioPessoa> PutUsuarioPessoaAsync(UsuarioPessoa c)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Pet

        public async Task<ObservableCollection<Pet>> GetPetAsync()
        {
            ObservableCollection<Pet> pet = await
                _request.GetAsync<ObservableCollection<Pet>>(ApiUrlBasePet);
            return pet;
        }
        public Task<Pet> PostPetAsync(Pet p)
        {
            throw new NotImplementedException();
        }

        public Task<Pet> PutPetAsync(Pet p)
        {
            throw new NotImplementedException();
        }

        public Task<Pet> DeletePetAsync(int petId)
        {
            throw new NotImplementedException();
        }

#endregion

        #region Forma Pagamento
        public async Task<ObservableCollection<FormaPagamento>> GetFormaPagarAsync()
        {
            ObservableCollection<FormaPagamento> pag = await
               _request.GetAsync<ObservableCollection<FormaPagamento>>(ApiUrlBasePet);
            return pag;
        }

        public Task<FormaPagamento> PostFormaPagarAsync(FormaPagamento p)
        {
            throw new NotImplementedException();
        }

        public Task<FormaPagamento> PutFormaPagarAsync(FormaPagamento p)
        {
            throw new NotImplementedException();
        }

        public Task<FormaPagamento> DeleteFormaPagarAsync(int petId)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Pet>> GetSubEspecieAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Pet>> GetEspecieAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Serviços
        public async Task<ObservableCollection<Servico>> GetServicoAsync()
        {
            ObservableCollection<Servico> serv = await
                _request.GetAsync<ObservableCollection<Servico>>(ApiUrlBaseServico);

            return serv;
        }

        public Task<Servico> PostServicoAsync(Servico s)
        {
            throw new NotImplementedException();
        }

        public Task<Servico> PutServicoAsync(Servico s)
        {
            throw new NotImplementedException();
        }

        public Task<Servico> DeleteServicoAsync(int servicoId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
