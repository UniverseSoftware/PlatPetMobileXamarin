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
        public ICommand NovoCommand { get; set; }
        private IPetService cService = new PetService();
        public ObservableCollection<Pet> Pets
        {
            get; set;
        }
        
        public ListaPetViewModel()
        {
            Pets = new ObservableCollection<Pet>();
            pet = new Pet();
            RegistrarCommands();
        }


        private void RegistrarCommands()
        {
            NovoCommand = new Command(() =>
            {
                MessagingCenter.Send<Pet>(new Pet(), "Mostrar");
            });
        }


        public async Task ObterPetAsync()
        {            
            int id = Convert.ToInt32(Application.Current.Properties["PessoaId"].ToString());
            pet.IdPessoa = id;                            
            Pets = await cService.GetPetAsync(pet);
            OnPropertyChanged(nameof(Pets));
        }

        public Pet SelPet
        {
            get { return pet; }
            set
            {
                if (value != null)
                {
                    pet = value;
                    MessagingCenter.Send<Pet>(pet, "Mostrar");
                }
            }
        }
    }
}
