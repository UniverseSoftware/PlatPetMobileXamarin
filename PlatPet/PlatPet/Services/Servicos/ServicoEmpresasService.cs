using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PlatPet.Models;

namespace PlatPet.Services.Servicos
{
    public class ServicoEmpresasService : IServicoEmpresasService
    {
        private readonly IRequest _request;
        private const string ApiUrlBaseServEmp = "http://universesoftware2019.somee.com/api/ServicoEmpresas";
        public Task<ServicoEmpresas> DeleteServicoEmpresaAsync(int servicoId)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<ServicoEmpresas>> GetServicoEmpresaAsync()
        {
            ObservableCollection<ServicoEmpresas> servEmp = await
                _request.GetAsync<ObservableCollection<ServicoEmpresas>>(ApiUrlBaseServEmp);

            return servEmp;
        }

        public Task<ServicoEmpresas> PostServicoEmpresaAsync(ServicoEmpresas s)
        {
            throw new NotImplementedException();
        }

        public Task<ServicoEmpresas> PutServicoEmpresaAsync(ServicoEmpresas s)
        {
            throw new NotImplementedException();
        }
    }
}
