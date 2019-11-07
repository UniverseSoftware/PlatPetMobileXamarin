using PlatPet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlatPet.Services.Agendamento
{
    public interface IAgendamentoConsultaService
    {
        Task<Pet> GetPetAsync();
        Task<UsuarioPessoa> GetUsuarioPessoaAsync();

        Task<UsuarioPessoa> PostUsuarioPessoaAsync(UsuarioPessoa c);

        Task<UsuarioPessoa> PutUsuarioPessoaAsync(UsuarioPessoa c);

        Task<UsuarioPessoa> DeleteUsuarioPessoaAsync(int pessoaId);
    }
}
