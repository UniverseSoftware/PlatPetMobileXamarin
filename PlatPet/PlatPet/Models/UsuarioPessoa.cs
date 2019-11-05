using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PlatPet.Models
{
    public class UsuarioPessoa
    {
        public int? IdUsuario { get; set; }

        [Required]
        public string UserUsuario { get; set; }

        [DataType("Password")]
        public string PassUsuario { get; set; }
        public int StatusUsuario { get; set; }
        public int TipoUsuario { get; set; }
        public int IdEP { get; set; }

        [Required]
        public string NomeEP { get; set; }

        [Required]
        public string SnomeEP { get; set; }

        [Required]
        public string CGCEP { get; set; }

        [Required, Phone]
        public string TelEP { get; set; }

        [Required, EmailAddress]
        public string EmailEP { get; set; }

        [Required]
        public string EndEP { get; set; }
    
    }
}
