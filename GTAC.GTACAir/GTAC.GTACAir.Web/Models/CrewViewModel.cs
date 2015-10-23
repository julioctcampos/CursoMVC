using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GTAC.GTACAir.Web.Models
{
    public class CrewViewModel
    {
        [DisplayName("ID")]
        [Required(ErrorMessage = "O ID é obrigatório")]
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(30, ErrorMessage = "O nome tem que ter 30 caracteres")]
        public string Name { get; set; }

        [DisplayName("Código ANAC")]
        [Required(ErrorMessage = "O Código ANAC é obrigatório")]
        [MaxLength(6, ErrorMessage = "O código ANAC tem que ter 6 caracteres")]
        public string AnacCode { get; set; }

        [DisplayName("Registro")]
        [Required(ErrorMessage = "O Registro é obrigatório")]
        [MaxLength(8, ErrorMessage = "O registro tem que ter 8 caracteres")]
        public string CompanyNumber { get; set; }

        [DisplayName("Ativo")]
        [Required(ErrorMessage = "O Ativo é obrigatório")]
        public bool Active { get; set; }

        [DisplayName("Nome Guerra")]
        [MaxLength(10, ErrorMessage = "O nome de guerra tem que ter 10 caracteres")]
        public string Nickname { get; set; }
    }
}