using System.Collections.Generic;

namespace FacileBudget.Models.ViewModels
{
    public class ListViewModel<T>
    {
        public List<T> Results { get; set; }
        public int TotalCount { get; set; }
        public string TotaleSpese { get; set; }
    }
}