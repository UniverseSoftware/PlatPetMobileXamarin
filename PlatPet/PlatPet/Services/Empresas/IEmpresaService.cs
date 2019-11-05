using PlatPet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PlatPet.Services.Empresas
{
    public interface IEmpresaService
    {
        Task<ObservableCollection<Empresa>> GetEmpresaAsync();

        Task<Empresa> PostEmpresaAsync(Empresa e);

        Task<Empresa> PutEmpresaAsync(Empresa e);

        Task<Empresa> DeleteEmpresaAsync(int empresaId);
    }
}
