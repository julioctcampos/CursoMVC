using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GTAC.GTACAir.Web.Models
{
    public class AircraftViewModel
    {
        [DisplayName("ID")]
        [Required(ErrorMessage = "O ID é obrigatório")]
        public int Id { get; set; }

        [DisplayName("Modelo")]
        [Required(ErrorMessage = "O modelo é obrigatório")]
        [MaxLength(10, ErrorMessage = "O modelo não pode ter mais 10 caracteres")]
        public string Model { get; set; }

        [DisplayName("Prefixo")]
        [Required(ErrorMessage = "O prefixo é obrigatório")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "O prefixo tem que ter 6 caracteres")]
        public string Preffix { get; set; }

        [DisplayName("Quantidade de Assentos")]
        public int SeatCount { get; set; }

        [DisplayName("Site do fabricante")]
        [DataType(DataType.Url, ErrorMessage = "Formato de site inválido")]
        public string ManufacturerSite { get; set; }
    }
}