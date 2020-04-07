using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using FacileBudget.Models.InputModels;
using FacileBudget.Models.Options;

namespace FacileBudget.Customizations.ModelBinders
{
    public class SpeseListInputModelBinder : IModelBinder
    {
        private readonly IOptionsMonitor<SpeseOptions> speseOptions;
        public SpeseListInputModelBinder(IOptionsMonitor<SpeseOptions> speseOptions)
        {
            this.speseOptions = speseOptions;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //Recuperiamo i valori grazie ai value provider
            int.TryParse(bindingContext.ValueProvider.GetValue("Page").FirstValue, out int page);

            //Creiamo l'istanza del CourseListInputModel
            SpeseOptions options = speseOptions.CurrentValue;
            var inputModel = new SpeseListInputModel(page, options.PerPage);

            //Impostiamo il risultato per notificare che la creazione è avvenuta con successo
            bindingContext.Result = ModelBindingResult.Success(inputModel);

            //Restituiamo un task completato
            return Task.CompletedTask;
        }
    }
}