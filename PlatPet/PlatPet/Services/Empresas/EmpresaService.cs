using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PlatPet.Models;

namespace PlatPet.Services.Empresas
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IRequest _request;
        private const string ApiUrlBase = "http://universesoftware2019.somee.com/api/Empresas";
        private const string ApiUrlBaseServico = "http://universesoftware2019.somee.com/api/ServicoEmpresas";

        public EmpresaService()
        {
            _request = new Request();
        }

        public async Task<Empresa> DeleteEmpresaAsync(int empresaId)
        {
            string urlComplementar = string.Format("/{0}", empresaId);
            await _request.DeleteAsync(ApiUrlBase + urlComplementar);
            return new Empresa() { IdEmpresa = empresaId };
        }

        public async Task<ObservableCollection<Empresa>> GetEmpresaAsync()
        {
            ObservableCollection<Empresa> empresa = await
                _request.GetAsync<ObservableCollection<Empresa>>(ApiUrlBase);

            return empresa;
        }

        public async Task<ObservableCollection<Empresa>> GetServEmpresaAsync()
        {
            ObservableCollection<Empresa> empresa = await
                 _request.GetAsync<ObservableCollection<Empresa>>(ApiUrlBaseServico);

            return empresa;
        }

        public async Task<Empresa> PostEmpresaAsync(Empresa e)
        {
            if (e.IdEmpresa == 0)
            {
                return await _request.PostAsync(ApiUrlBase, e);

            }
            else
                return await _request.PutAsync(ApiUrlBase, e);
        }

        public async Task<Empresa> PutEmpresaAsync(Empresa e)
        {
            string urlComplementar = string.Format("/{0}", e.IdEmpresa);
            var result = await _request.PutAsync(ApiUrlBase, e);
            return result;
        }        
    }
}
