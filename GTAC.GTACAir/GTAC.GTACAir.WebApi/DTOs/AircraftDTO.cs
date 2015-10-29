using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GTAC.GTACAir.WebApi.DTOs
{
    public class AircraftDTO
    {
        [Required(ErrorMessage = "O ID é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório")]
        [MaxLength(10, ErrorMessage = "O modelo não pode ter mais 10 caracteres")]
        public string Model { get; set; }

        [Required(ErrorMessage = "O prefixo é obrigatório")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "O prefixo tem que ter 6 caracteres")]
        public string Preffix { get; set; }

        public int SeatCount { get; set; }

        [DataType(DataType.Url, ErrorMessage = "Formato de site inválido")]
        public string ManufacturerSite { get; set; }
    }
}