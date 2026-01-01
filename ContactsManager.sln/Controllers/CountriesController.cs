using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace ContactsManager.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("[Controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountriesService _countriesService;
        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult UploadCountry()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> UploadCountry(CountryAddRequest countryAddRequest)
        {
            CountryResponse UploadedCountry =await _countriesService.AddCountry(countryAddRequest);
            return RedirectToAction(nameof(PersonsController.Index),"Persons");
        }
    }
}
