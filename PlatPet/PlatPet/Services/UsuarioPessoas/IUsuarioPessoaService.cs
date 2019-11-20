using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PlatPet.Models;

namespace PlatPet.Services.UsuarioPessoas
{
    public interface IUsuarioPessoaService
    {
        Task <ObservableCollection<UsuarioPessoa>> GetUsuarioPessoaAsync(string usuario);

        Task<UsuarioPessoa> PostUsuarioPessoaAsync(UsuarioPessoa c);

        Task<UsuarioPessoa> PutUsuarioPessoaAsync(UsuarioPessoa c);

        Task<UsuarioPessoa> DeleteUsuarioPessoaAsync(int pessoaId);
    }
}
