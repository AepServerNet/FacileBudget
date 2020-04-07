using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FacileBudget.Models.ValueTypes;

namespace FacileBudget.Models.ViewModels
{
    public class SpesaDetailViewModel : SpeseViewModel
    {
        //public int IdSpesa { get; set; }
        //public string Descrizione { get; set; }
        //public int Importo { get; set; }
        //public string Valuta { get; set; }
        //public int Mese { get; set; }
        //public int Anno { get; set; }

        public static new SpesaDetailViewModel FromDataRow(DataRow Row)
        {
            var spesaDetailViewModel = new SpesaDetailViewModel
            {
                Descrizione = Convert.ToString(Row["Descrizione"]),
                Importo = Convert.ToInt32(Row["Importo"]),
                Valuta = Convert.ToString(Row["Valuta"]),
                Mese = Convert.ToInt32(Row["Mese"]),
                Anno = Convert.ToInt32(Row["Anno"]),
                IdSpesa = Convert.ToInt32(Row["IdSpesa"])
            };
            return spesaDetailViewModel;
        }

    }
}