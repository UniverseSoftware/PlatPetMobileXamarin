using PlatPet.Models;
using PlatPet.Services;
using PlatPet.Services.Pets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatPet.ViewModel.Pets
{
    public class ListaPetViewModel : BaseViewModel
    {
        private Pet pet;

        private IPetService cService = new PetService();
        public ObservableCollection<Pet> Pets
        {
            get; set;
        }

        public ObservableCollection<Pet> SubEspecies
        {
            get; set;
        }

        public ObservableCollection<Pet> Especies
        {
            get; set;
        }
        
        public ListaPetViewModel()
        {
            Pets = new ObservableCollection<Pet>();
            Especies = new ObservableCollection<Pet>();
            SubEspecies = new ObservableCollection<Pet>();
        }

        public async Task Popular()
        {
             ObterEspecieAsync();
             ObterSubEspecieAsync();
        }

        public async Task ObterPetAsync()
        {
            Pets = await cService.GetPetAsync();
            OnPropertyChanged(nameof(Pets));
        }

        public async Task ObterEspecieAsync()
        {
            Especies = await cService.GetEspecieAsync();
            OnPropertyChanged(nameof(Especies));

            foreach (var especies in Especies)
            {
                Especies.Add(new Pet
                {
                    NomeEspecie = especies.NomeEspecie,
                    IdEspecie = especies.IdEspecie +1
                });
            }
        }

        public async Task ObterSubEspecieAsync()
        {
            SubEspecies = await cService.GetSubEspecieAsync();
            OnPropertyChanged(nameof(SubEspecies));

            foreach (var subespecies in SubEspecies)
            {
                SubEspecies.Add(new Pet
                {
                   NomeSubEspecie = subespecies.NomeSubEspecie,
                   IdSubespecie = subespecies.IdSubespecie
                });
            }
        }
    }
}
