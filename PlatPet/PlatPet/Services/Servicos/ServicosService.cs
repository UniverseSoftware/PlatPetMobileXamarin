using PlatPet.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PlatPet.Services.Servicos
{
    public class ServicosService : IServicosService
    {
        private readonly IRequest _request;
        private const string ApiUrlBase = "http://universesoftware2019.somee.com/api/Servicos";

        public ServicosService()
        {
            _request = new Request();
        }
        public Task<Servico> DeleteServicoAsync(int servicoId)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<Servico>> GetServicoAsync()
        {
            ObservableCollection<Servico> serv = await
                _request.GetAsync<ObservableCollection<Servico>>(ApiUrlBase);

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
    }
}
