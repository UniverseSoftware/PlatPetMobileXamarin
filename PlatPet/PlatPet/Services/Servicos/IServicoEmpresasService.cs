using PlatPet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PlatPet.Services.Servicos
{
    public interface IServicoEmpresasService
    {
        Task<ObservableCollection<ServicoEmpresas>> GetServicoEmpresaAsync();

        Task<ObservableCollection<ServicoEmpresas>> GetServicosEmpresaAsync(ServicoEmpresas s);

        Task<ServicoEmpresas> PostServicoEmpresaAsync(ServicoEmpresas s);

        Task<ServicoEmpresas> PutServicoEmpresaAsync(ServicoEmpresas s);

        Task<ServicoEmpresas> DeleteServicoEmpresaAsync(int servicoId);
    }
}
