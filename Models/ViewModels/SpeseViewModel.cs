using System;
using System.Data;
using FacileBudget.Models.ValueTypes;

namespace FacileBudget.Models.ViewModels
{
    public class SpeseViewModel
    {
        public int Id { get; set; }

        public static SpeseViewModel FromDataRow(DataRow Row)
        {
            var speseViewModel = new SpeseViewModel {
                Esperienza = Convert.ToString(Row["Esperienza"]),
                Id = Convert.ToInt32(Row["Id"])
            };
            return speseViewModel;
        }
    }
}