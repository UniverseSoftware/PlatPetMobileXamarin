using PlatPet.Models;
using PlatPet.Services.Pagamentos;
using PlatPet.Services.Pets;
using PlatPet.Services.Servicos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PlatPet.ViewModel.Agendamento
{
    public class AgendamentoConsultaViewModel : BaseViewModel
    {
        private Pet pet;
        private FormaPagamento pag;

        private IPetService pService = new PetService();
        private IFormaPagarService fService = new FormaPagarService();
        private IServicosService sService = new ServicosService();

        public ObservableCollection<Pet> Pets
        {
            get; set;
        }

        public ObservableCollection<FormaPagamento> Pag
        {
            get; set;
        }

        public ObservableCollection<Servico> Servicos
        {
            get; set;
        }

        public AgendamentoConsultaViewModel()
        {
            Pets = new ObservableCollection<Pet>();
            Pag = new ObservableCollection<FormaPagamento>();
            Servicos = new ObservableCollection<Servico>();
        }

        public async Task Chamar()
        {
            Pets = new ObservableCollection<Pet>();
            Pag = new ObservableCollection<FormaPagamento>();
            Servicos = new ObservableCollection<Servico>();
            ObterPetAsync();
            ObterFormaPagamentoAsync();
            ObterServicoAsync();
        }

        public async Task ObterPetAsync()
        {
            Pets = await pService.GetPetAsync();
            OnPropertyChanged(nameof(Pets));

            foreach(var pets in Pets)
            {
                Pets.Add(new Pet
                {
                    NomePet = pets.NomePet,
                    IdPet = pets.IdPet
                });
            }
        }

        public async Task ObterFormaPagamentoAsync()
        {
            Pag = await fService.GetFormaPagarAsync();
            OnPropertyChanged(nameof(Pag));

            foreach(var pags in Pag)
            {
                Pag.Add(new FormaPagamento
                {
                    DescPagamento = pags.DescPagamento,
                    IdPagemento = pags.IdPagemento
                });
            }
        }

        public async Task ObterServicoAsync()
        {
            Servicos = await sService.GetServicoAsync();
            OnPropertyChanged(nameof(Servicos));

            foreach (var services in Servicos)
            {
                Servicos.Add(new Servico
                {
                    IdServico = services.IdServico,
                    NomeServico = services.NomeServico 
                });
            }
        }
    }
}
