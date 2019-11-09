using PlatPet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PlatPet.Services.Servicos
{
    public interface IServicosService
    {
        Task<ObservableCollection<Servico>> GetServicoAsync();

        Task<Servico> PostServicoAsync(Servico s);

        Task<Servico> PutServicoAsync(Servico s);

        Task<Servico> DeleteServicoAsync(int servicoId);
    }
}
