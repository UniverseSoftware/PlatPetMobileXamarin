﻿using PlatPet.Models;
using PlatPet.Services.Pets;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlatPet.ViewModel.Pets
{
    public class CadastroPetViewModel : BaseViewModel
    {
        private IPetService uService = new PetService();

        private Pet Pet;
        public ICommand GravarCommand { get; set; }
        public ICommand NovoCommand { get; set; }

        public CadastroPetViewModel()
        {
            RegistrarCommands();
            Pet = new Pet();


            Pets = new ObservableCollection<Pet>();
            Especies = new ObservableCollection<Pet>();
            SubEspecies = new ObservableCollection<Pet>();
        }

        private void RegistrarCommands()
        {
            GravarCommand = new Command(async () =>
            {
                await GravarAsync();
                MessagingCenter.Send<string>("Dado salvo com sucesso.", "InformacaoCRUD");
            });
        }

        private async Task GravarAsync()
        {
            var ehNovoUsuario = (Pet.IdPet == 0 ? true : false);
            Pet.IdPessoa = 18;
            await uService.PostPetAsync(Pet);

            //Chamada ao método que limpa os campos da tela
            AtualizarPropriedadesParaVisao(ehNovoUsuario);
        }

        //Método que limpa as propriedades da ViewModel, que por sua vez, limpa a View
        private void AtualizarPropriedadesParaVisao(bool ehNovoObjeto)
        {
            if (ehNovoObjeto)
            {
                this.NomePet = string.Empty;
                this.RG = string.Empty;
                //this.SubEspecie = 0;
                this.Observacao = string.Empty;
                this.Pet = new Pet();
            }
        }
        public string NomePet
        {
            get { return this.Pet.NomePet; }
            set
            {
                this.Pet.NomePet = value;
                OnPropertyChanged();
            }
        }

        public Pet SubEspecie
        {
            get { return pet; }
            set
            {
                if (value != null)
                {
                    pet = value;
                    OnPropertyChanged();
                    this.Pet.IdSubespecie = pet.IdSubespecie;
                }
            }
        }

        public string RG
        {
            get { return this.Pet.RGPet; }
            set
            {
                this.Pet.RGPet = value;
                OnPropertyChanged();
            }
        }

        public string Observacao
        {
            get { return this.Pet.ObsPet; }
            set
            {
                this.Pet.ObsPet = value;
                OnPropertyChanged();
            }
        }

        public async Task Gravar()
        {
            await GravarAsync();
            Mensagem();
        }

        private void Mensagem()
        {
            MessagingCenter.Send<string>("Dado salvo com sucesso.", "InformacaoCRUD");
        }




        #region Lista

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
                    IdEspecie = especies.IdEspecie + 1
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

        #endregion
    }
}