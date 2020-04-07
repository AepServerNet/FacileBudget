using System.ComponentModel.DataAnnotations;

namespace FacileBudget.Models.InputModels
{
    public class SpeseCreateInputModel
    {
        [Required(ErrorMessage = "La Descrizione è obbligatoria")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "L'importo è obbligatorio")]
        public string Importo { get; set; }
    }
}