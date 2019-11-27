using PlatPet.Models;
using PlatPet.Services.Empresas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PlatPet.ViewModel.Empresas
{
    public class ListaEmpresasViewModel : BaseViewModel
    {
        private Empresa empresa;
        public IEmpresaService eService = new EmpresaService();

        public ObservableCollection<Empresa> Empresa
        {
            get; set;
        }
    }
}
