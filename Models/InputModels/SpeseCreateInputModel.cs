using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using FacileBudget.Controllers;

namespace FacileBudget.Models.InputModels
{
    public class SpeseCreateInputModel
    {
        [Required(ErrorMessage = "La Descrizione è obbligatoria")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "L'importo è obbligatorio")]
        public int Importo { get; set; }
    }
}