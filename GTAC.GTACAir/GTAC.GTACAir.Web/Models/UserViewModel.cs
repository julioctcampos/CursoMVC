using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GTAC.GTACAir.Web.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="O nome é obrigatório")]
        [MaxLength(20, ErrorMessage = "O nome só pode conter 20 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [MaxLength(50, ErrorMessage = "O email só pode conter 50 caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato de email errado")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MaxLength(10, ErrorMessage = "A senha só pode conter 10 caracteres")]
        [MinLength(6, ErrorMessage = "A senha deve possuir no mínimo 6 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}