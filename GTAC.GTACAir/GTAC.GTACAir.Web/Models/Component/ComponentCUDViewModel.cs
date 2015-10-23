using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GTAC.GTACAir.Web.Models.Component
{
    public class ComponentCUDViewModel
    {
        [Required(ErrorMessage = "O ID da peça é obrigatório")]
        public int Id { get; set; }

        [DisplayName("Nome da Peça")]
        [Required(ErrorMessage = "O nome da peça é obrigatório")]
        [MaxLength(50, ErrorMessage = "O nome da peça não pode ter mais 50 caracteres")]
        public string Title { get; set; }

        [DisplayName("Fabricante")]
        [Required(ErrorMessage = "O fabricante é obrigatório")]
        [MaxLength(50, ErrorMessage = "O fabricante não pode ter mais 50 caracteres")]
        public string Manufacturer { get; set; }

        [DisplayName("Aeronave")]
        [Required(ErrorMessage = "A aeronave é obrigatória")]
        public int AircraftId { get; set; }
    }
}