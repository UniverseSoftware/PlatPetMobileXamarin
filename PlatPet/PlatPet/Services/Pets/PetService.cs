using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PlatPet.Models;

namespace PlatPet.Services.Pets
{
    public class PetService : IPetService
    {
        private readonly IRequest _request;
        private const string ApiUrlBase = "http://universesoftware2019.somee.com/api/Pets";

        public PetService()
        {
            _request = new Request();
        }

        public async Task<Pet> DeletePetAsync(int petId)
        {
            string urlComplementar = string.Format("/{0}", petId);
            await _request.DeleteAsync(ApiUrlBase + urlComplementar);
            return new Pet() { IdPet = petId };
        }

        public async Task<ObservableCollection<Pet>> GetPetAsync()
        {
            ObservableCollection<Pet> pet = await
                _request.GetAsync<ObservableCollection<Pet>>(ApiUrlBase);

            return pet;
        }

        public async Task<Pet> PostPetAsync(Pet p)
        {
            if (p.IdPet == 0)
            {
                return await _request.PostAsync(ApiUrlBase, p);

            }
            else
                return await _request.PutAsync(ApiUrlBase, p);
        }

        public async Task<Pet> PutPetAsync(Pet p)
        {
            string urlComplementar = string.Format("/{0}", p);
            var result = await _request.PutAsync(ApiUrlBase, p);
            return result;
        }
    }
}
