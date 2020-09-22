using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using VPProject.Constants;
using VPProject.Models;
using VPProject.Models.Entities;
using VPProject.Models.UIModels;
using VPProject.Services.Interface;

namespace VPProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountryService _countryService;
        private readonly IPenaltyService _penaltyService;
        private readonly IValidationService _validationService;
        public HomeController(ILogger<HomeController> logger, ICountryService countryService, IValidationService validationService, IPenaltyService penaltyService)
        {
            _logger = logger;
            _countryService = countryService;
            _validationService = validationService;
            _penaltyService = penaltyService;
        }

        public IActionResult Index()
        {
            ViewBag.ddCountryItems = GetCountries();
            return View(new BookInputModel());
        }

        [HttpPost]
        public IActionResult Calculate(BookInputModel inputModel)
        {
            ViewBag.ddCountryItems = GetCountries();
            if (ModelState.IsValid)
            {                
                bool areInputDatesRight = _validationService.CheckDates(inputModel);
                if (!areInputDatesRight)
                {
                    ViewBag.Messages = new List<string>() { VPConstants.InputsCheck };
                    return View("Index");
                }
                var penaltyResult = _penaltyService.CalculatePenaltyAmount(inputModel);
                if (penaltyResult.Success)
                {
                    ViewBag.PenaltyResult = penaltyResult.Message;
                }
                return View("Index");
            }
            else
            {
                ViewBag.Messages = _validationService.GetErrors(ViewData.ModelState.Values);
                return View("Index");
            }
        }

        public List<SelectListItem> GetCountries()
        {
            var result = _countryService.GetAll();
            var ddCountryItems = new List<SelectListItem>();

            if (result.Success)
            {
                foreach (var countryItem in result.Root as List<Country>)
                {
                    ddCountryItems.Add(new SelectListItem
                    {
                        Text = countryItem.Name,
                        Value = countryItem.Id.ToString()
                    });
                }
            }
            else
            {
                ViewBag.Messages = new List<string>() { result.Message };
            }
            return ddCountryItems;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
