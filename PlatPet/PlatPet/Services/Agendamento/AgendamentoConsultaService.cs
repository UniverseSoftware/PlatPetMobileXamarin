using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PlatPet.Models;
using PlatPet.Services.Pagamentos;
using PlatPet.Services.Pets;
using PlatPet.Services.UsuarioPessoas;

namespace PlatPet.Services.Agendamento
{
    public class AgendamentoConsultaService : IPetService, IUsuarioPessoaService, IFormaPagarService
    {
        private readonly IRequest _request;
        private const string ApiUrlBasePet = "http://universesoftware2019.somee.com/api/Pets";
        private const string ApiUrlBasePagamento = "http://universesoftware2019.somee.com/api/Pagamentos";

        public AgendamentoConsultaService()
        {
            _request = new Request();
        }

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
    }
}
