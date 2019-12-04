using PlatPet.Models;
using PlatPet.Services.Pagamentos;
using PlatPet.Services.Pedidos;
using PlatPet.Services.Pets;
using PlatPet.Services.Servicos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatPet.ViewModel.Agendamento
{
    public class AgendamentoConsultaViewModel : BaseViewModel
    {
        private Pet pet;
        private FormaPagamento pag;
        private Empresa emp;
        private ServicoEmpresas sEmp;
        private Pedido ped;
        private ServicosComEmpresa servCEmp;
        private IPetService pService = new PetService();
        private IFormaPagarService fService = new FormaPagarService();
        private IServicosService sService = new ServicosService();
        private IServicoEmpresasService seService = new ServicoEmpresasService();
        private IPedidosService pdService = new PedidosService();
        private ICommand GravarCommand { get; set; }

        #region Observables
        public ObservableCollection<Pet> PetsP
        {
            get; set;
        }

        public ObservableCollection<Pet> PetsG
        {
            get; set;
        }

        public ObservableCollection<FormaPagamento> PagP
        {
            get; set;
        }

        public ObservableCollection<FormaPagamento> PagG
        {
            get; set;
        }

        public ObservableCollection<Servico> ServicosP
        {
            get; set;
        }

        public ObservableCollection<ServicoEmpresas> ServicosG
        {
            get; set;
        }

        public ObservableCollection<ServicoEmpresas> ServicosEmpP
        {
            get; set;
        }

        public ObservableCollection<ServicoEmpresas> ServicosEmpG
        {
            get; set;
        }

        public ObservableCollection<ServicosComEmpresa> ServComEmp
        {
            get; set;
        }
        #endregion
        public AgendamentoConsultaViewModel(Empresa empresa)
        {
            emp = new Empresa();
            PetsP = new ObservableCollection<Pet>();
            PetsG = new ObservableCollection<Pet>();
            PagP = new ObservableCollection<FormaPagamento>();
            PagG = new ObservableCollection<FormaPagamento>();
            ServicosP = new ObservableCollection<Servico>();
            ServicosG = new ObservableCollection<ServicoEmpresas>();
            ServicosEmpP = new ObservableCollection<ServicoEmpresas>();
            ServicosEmpG = new ObservableCollection<ServicoEmpresas>();
            ServComEmp = new ObservableCollection<ServicosComEmpresa>();
            pet = new Pet();
            Application.Current.Properties["EmpID"] = empresa.IdEmpresa;
            int id = Convert.ToInt32(Application.Current.Properties["PessoaId"].ToString());
            nmEmpresa = empresa.NFantasiaEmpresa;
            servico = Application.Current.Properties["Op"].ToString();
            RegistraCommands();
        }

        string servico;
        string nmEmpresa;

        //public AgendamentoConsultaViewModel()
        //{
        //    PetsP = new ObservableCollection<Pet>();
        //    PetsG = new ObservableCollection<Pet>();
        //    PagP = new ObservableCollection<FormaPagamento>();
        //    PagG = new ObservableCollection<FormaPagamento>();
        //    ServicosP = new ObservableCollection<Servico>();
        //    ServicosG = new ObservableCollection<ServicoEmpresas>();
        //    ServicosEmpP = new ObservableCollection<ServicoEmpresas>();
        //    ServicosEmpG = new ObservableCollection<ServicoEmpresas>();
        //    ServComEmp = new ObservableCollection<ServicosComEmpresa>();
        //    pet = new Pet();
        //    int id = Convert.ToInt32(Application.Current.Properties["PessoaId"].ToString());
        //}

        private void RegistraCommands()
        {
            GravarCommand = new Command(async () =>
            {
                await GravarAsync();
                MessagingCenter.Send<string>("Dado salvo com sucesso.", "InformacaoCRUD");
            });
        }

        public async Task GravarAsync()
        {
            //var ehNovoUsuario = (ped.IdPedido == 0 ? true : false);
            ped = new Pedido();
            ped.IdEmpresa = Convert.ToInt32(Application.Current.Properties["EmpID"].ToString());
            ped.IdPagamento = Convert.ToInt32(Application.Current.Properties["IdPagamento"]);
            ped.IdPet = Convert.ToInt32(Application.Current.Properties["IdPet"]);
            ped.TotPedido = Convert.ToDouble(Application.Current.Properties["IdPagamento"]);
            await pdService.PostPedidoAsync(ped);
            MessagingCenter.Send<string>("Dado salvo com sucesso.", "InformacaoCRUD");
            //Chamada ao método que limpa os campos da tela
            //AtualizarPropriedadesParaVisao(ehNovoUsuario);
        }

        public async Task Popular()
        {
            ObterPetAsync();
            ObterFormaPagamentoAsync();
            ObterServComEmp();
        }

        public async Task ObterPetAsync()
        {
            pet.IdPessoa = Convert.ToInt32(Application.Current.Properties["PessoaId"].ToString());
            PetsP = await pService.GetPetAsync(pet);
            OnPropertyChanged(nameof(PetsG));

            foreach (var pets in PetsP)
            {
                PetsG.Add(new Pet
                {
                    NomePet = pets.NomePet,
                    IdPet = pets.IdPet
                });
            }
        }

        public async Task ObterFormaPagamentoAsync()
        {
            PagP = await fService.GetFormaPagarAsync();
            OnPropertyChanged(nameof(PagG));

            foreach (var pags in PagP)
            {
                PagG.Add(new FormaPagamento
                {
                    DescPagamento = pags.DescPagamento,
                    IdPagemento = pags.IdPagemento
                });
            }
        }

        public async Task ObterServComEmp()
        {
            sEmp = new ServicoEmpresas();
            sEmp.IdEmpresa = Convert.ToInt32(Application.Current.Properties["EmpID"].ToString());
            ServicosG = await seService.GetServicosEmpresaAsync(sEmp);
            OnPropertyChanged(nameof(ServComEmp));


            foreach (var servEmp in ServicosG)
            {
                ServComEmp.Add(new ServicosComEmpresa
                {
                    IdEmpresa = servEmp.IdEmpresa,
                    IdServicoEmpresa = servEmp.IdServicoEmpresa,
                    VlServicoEmpresa = servEmp.VlServicoEmpresa,
                    NomeServico = string.Format("{0} - {1}", servEmp.VlServicoEmpresa, servEmp.NomeServico)
                });
            }
        }

        public Pet Pets
        {
            get { return pet; }
            set
            {
                if (value != null)
                {
                    pet = value;
                    OnPropertyChanged();
                    Application.Current.Properties["IdPet"] = pet.IdPet;
                }
            }
        }

        public FormaPagamento Pagamentos
        {
            get { return pag; }
            set
            {
                if (value != null)
                {
                    pag = value;
                    OnPropertyChanged();
                    Application.Current.Properties["IdPagamento"] = pag.IdPagemento;
                }
            }
        }

        public ServicosComEmpresa Servicos
        {
            get { return servCEmp; }
            set
            {
                if (value != null)
                {
                    servCEmp = value;
                    OnPropertyChanged();
                    Application.Current.Properties["VlServico"] = servCEmp.VlServicoEmpresa;
                }
            }
        }
                
        public string NmEmpresa
        {
            get { return nmEmpresa; }
            set
            {
                value = nmEmpresa;
                OnPropertyChanged();
            }
        }

        public string NmServico
        {
            get { return servico; }
            set
            {
                value = servico;
                OnPropertyChanged();
            }
        }
    }
}
