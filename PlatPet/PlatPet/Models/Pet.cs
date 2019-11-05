using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PlatPet.Models
{
    public class Pet
    {
        public int IdPet { get; set; }
        public int IdPessoa { get; set; }
        public string NomePet { get; set; }
        public int IdSubespecie { get; set; }
        public string RGPet { get; set; }
        public string ObsPet { get; set; }
        public DateTime MyProperty { get; set; }
    }
}
