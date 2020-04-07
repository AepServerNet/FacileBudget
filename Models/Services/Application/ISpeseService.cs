using System.Threading.Tasks;
using FacileBudget.Models.InputModels;
using FacileBudget.Models.ViewModels;

namespace FacileBudget.Models.Services.Application
{
    public interface ISpeseService
    {
        Task<ListViewModel<SpeseViewModel>> GetSpeseAsync(SpeseListInputModel model);
        Task<bool> CreateSpesaAsync(SpeseCreateInputModel inputModel);
    }
}