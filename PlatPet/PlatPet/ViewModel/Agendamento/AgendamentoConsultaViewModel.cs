﻿using PlatPet.Models;
using PlatPet.Services.Pagamentos;
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
        private IPetService pService = new PetService();
        private IFormaPagarService fService = new FormaPagarService();
        private IServicosService sService = new ServicosService();
        private IServicoEmpresasService seService = new ServicoEmpresasService();
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
            int id = Convert.ToInt32(Application.Current.Properties["PessoaId"].ToString());
            emp.NFantasiaEmpresa = empresa.NFantasiaEmpresa;
        }

        public AgendamentoConsultaViewModel()
        {
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
            int id = Convert.ToInt32(Application.Current.Properties["PessoaId"].ToString());
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

            foreach(var pets in PetsP)
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

            foreach(var pags in PagP)
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
            ServicosG = await seService.GetServicoEmpresaAsync();
            OnPropertyChanged(nameof(ServComEmp));


            foreach (var servEmp in ServicosG)
            {
                ServComEmp.Add(new ServicosComEmpresa
                {
                    IdEmpresa = servEmp.IdEmpresa,
                    IdServicoEmpresa = servEmp.IdServicoEmpresa,
                    VlServicoEmpresa = servEmp.VlServicoEmpresa,
                    NomeServico = string.Format("{0} - {1}", servEmp.IdServico, servEmp.NomeServico)
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
                    this.pet.IdSubespecie = pet.IdSubespecie;
                }
            }
        }
    }
}
