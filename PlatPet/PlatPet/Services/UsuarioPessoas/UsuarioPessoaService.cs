using PlatPet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PlatPet.Services.UsuarioPessoas
{
    public class UsuarioPessoaService : IUsuarioPessoaService
    {
        private readonly IRequest _request;
        private const string ApiUrlBase = "http://universesoftware2019.somee.com/api/CadUsuarios";

        public UsuarioPessoaService()
        {
            _request = new Request();
        }

        public async Task<UsuarioPessoa> DeleteUsuarioPessoaAsync(int usuarioId)
        {
            string urlComplementar = string.Format("/{0}", usuarioId);
            await _request.DeleteAsync(ApiUrlBase + urlComplementar);
            return new UsuarioPessoa() { IdUsuario = usuarioId };
        }

        public async Task<UsuarioPessoa> GetUsuarioPessoaAsync()
        {
            UsuarioPessoa usuarioPessoa = await
                _request.GetAsync<UsuarioPessoa>(ApiUrlBase);

            return usuarioPessoa;
        }

        public async Task<UsuarioPessoa> PostUsuarioPessoaAsync(UsuarioPessoa c)
        {
            if (c.IdUsuario == 0)
            {
                string urlComplementar = string.Format("/I/{0}", c.TipoUsuario);
                return await _request.PostAsync(ApiUrlBase + urlComplementar, c);
            }
            else
                return await _request.PutAsync(ApiUrlBase, c);
        }

        public async Task<UsuarioPessoa> PutUsuarioPessoaAsync(UsuarioPessoa c)
        {
            string urlComplementar = string.Format("/U/{0}", c.IdUsuario);
            var result = await _request.PutAsync(ApiUrlBase + urlComplementar, c);
            return result;
        }
    }
}
