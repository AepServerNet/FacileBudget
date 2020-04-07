using System.Collections.Generic;
using FacileBudget.Models.InputModels;

namespace FacileBudget.Models.ViewModels
{
    public class SpeseListViewModel
    {
        public ListViewModel<SpeseViewModel> Esperienze { get; set; }
        public SpeseListInputModel Input { get; set; }
    }
}