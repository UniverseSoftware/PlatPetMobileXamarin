using PlatPet.Models;
using PlatPet.Services.Empresas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        public ListaEmpresasViewModel()
        {
            Empresa = new ObservableCollection<Empresa>();
            empresa = new Empresa();
        }

        public async Task ObterEmpresa()
        {
            Empresa = await eService.GetEmpresaAsync();
            OnPropertyChanged(nameof(Empresa));
        }

        public Empresa SelEmpresa
        {
            get { return empresa; }
            set
            {
                if (value != null)
                {
                    empresa = value;
                    MessagingCenter.Send<Empresa>(empresa, "Mostrar");
                }
            }
        }
    }
}
