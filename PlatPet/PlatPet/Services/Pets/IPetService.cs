using PlatPet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PlatPet.Services.Pets
{
    public interface IPetService
    {
        Task<ObservableCollection<Pet>> GetPetAsync(Pet p);

        Task<ObservableCollection<Pet>> GetEspecieAsync();

        Task<ObservableCollection<Pet>> GetSubEspecieAsync();

        Task<Pet> PostPetAsync(Pet p);

        Task<Pet> PutPetAsync(Pet p);

        Task<Pet> DeletePetAsync(int petId);
    }
}
