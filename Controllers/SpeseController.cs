using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FacileBudget.Models.InputModels;
using FacileBudget.Models.Services.Application;
using FacileBudget.Models.ViewModels;

namespace FacileBudget.Controllers
{
    public class SpeseController : Controller
    {
        private readonly ISpeseService spesaService;
        public SpeseController(ISpeseService spesaService)
        {
            this.spesaService = spesaService;
        }

        public async Task<IActionResult> Index(SpeseListInputModel input)
        {
            ViewData["Title"] = "Elenco delle spese";
            ListViewModel<SpeseViewModel> spese = await spesaService.GetSpeseAsync(input);

            SpeseListViewModel viewModel = new SpeseListViewModel
            {
                Spese = spese,
                Input = input
            };

            return View(viewModel);
        }
        public IActionResult Create()
        {
            ViewData["Title"] = "Nuova spesa";
            var inputModel = new SpeseCreateInputModel();
            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpeseCreateInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                    bool spesa = await spesaService.CreateSpesaAsync(inputModel);
                    if (spesa == true)
                    {
                        TempData["ConfirmationMessage"] = "Ok! La tua spesa è stato aggiunta!";
                        return RedirectToAction("Index", "Spese");
                    }
            }

            ViewData["Title"] = "Nuova spesa";
            return View(inputModel);
        }
    }
}