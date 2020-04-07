using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FacileBudget.Models.ValueTypes;

namespace FacileBudget.Models.ViewModels
{
    public class SpesaDetailViewModel : SpeseViewModel
    {
        public static new SpesaDetailViewModel FromDataRow(DataRow Row)
        {
            var spesaDetailViewModel = new SpesaDetailViewModel
            {
                Descrizione = Convert.ToString(Row["Descrizione"]),
                Importo = Convert.ToString(Row["Importo"]),
                Valuta = Convert.ToString(Row["Valuta"]),
                Mese = Convert.ToString(Row["Mese"]),
                Anno = Convert.ToString(Row["Anno"]),
                IdSpesa = Convert.ToInt32(Row["IdSpesa"])
            };
            return spesaDetailViewModel;
        }

    }
}