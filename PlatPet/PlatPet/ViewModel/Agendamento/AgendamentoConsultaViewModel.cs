using PlatPet.Models;
using PlatPet.Services.Pets;
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

        private IPetService cService = new PetService();
        public ObservableCollection<Pet> Pets
        {
            get; set;
        }

        public AgendamentoConsultaViewModel()
        {
            Pets = new ObservableCollection<Pet>();
        }

        public void Chamar()
        {
            Pets = new ObservableCollection<Pet>();
            ObterPetAsync();
        }

        public async Task ObterPetAsync()
        {
            Pets = await cService.GetPetAsync();
            OnPropertyChanged(nameof(Pets));

            foreach(var teste in Pets)
            {
                Pets.Add(new Pet
                {
                    NomePet = teste.NomePet
                });
            }
        }
    }
}
