using ContactsManager.Filters.ActionFilters;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using System.Threading.Tasks;

namespace ContactsManager.Controllers
{
    [Route("[Controller]")]
    public class PersonsController : Controller
    {
        //Private fields
        private readonly IPersonsSorterService _personsSorterService;
        private readonly IPersonsGetterService _personsGetterService;
        private readonly IPersonsAdderService _personsAdderService;
        private readonly IPersonsUpdaterService _personsUpdaterService;
        private readonly IPersonsDeleterService _personsDeleterService;
        private readonly ICountriesService? _countriesService;
        private readonly ILogger<PersonsController> _logger;

        public PersonsController(IPersonsSorterService personsSorterService, IPersonsGetterService personsGetterService,
            IPersonsAdderService personsAdderService, IPersonsUpdaterService personsUpdaterService,
            IPersonsDeleterService personsDeleterService, ICountriesService? countriesService,ILogger<PersonsController> logger)
        {
            _personsSorterService = personsSorterService;
            _personsGetterService = personsGetterService;
            _personsAdderService = personsAdderService;
            _personsUpdaterService = personsUpdaterService;
            _personsDeleterService = personsDeleterService;
            _countriesService = countriesService;
            _logger = logger;

        }
        //Url: persons/index      if you want to override this route you can write / before it: [Route("/index")]=>Url:/index not persons/index 
        [Route("index")]
        [Route("/")]
        [TypeFilter(typeof(PersonsListActionFilter))]
        public async Task<IActionResult> Index(string SearchBy, string? SearchString,
            string sortedBy = nameof(PersonResponse.PersonName), SortOrderOptions sortOrder = SortOrderOptions.Asc)
        {
            _logger.LogInformation("The Index action of Persons controller");
            _logger.LogDebug($"SearchBy:{SearchBy}, SearchString:{SearchString}, SortedBy:{sortedBy}, SortOrder:{sortOrder}");
            //Search
            ViewBag.SearchFields = new Dictionary<string, string>() // Property values, search options
            {
                { nameof(PersonResponse.PersonName),"Person Name" },
                { nameof(PersonResponse.Gender),"Gender" },
                { nameof(PersonResponse.CountryName),"Country Name" },
                { nameof(PersonResponse.BirthDate),"Date of birth" },
                { nameof(PersonResponse.Email),"Email" },
                { nameof(PersonResponse.Address),"Address" }
            };
            ViewBag.CurrentSearchBy = SearchBy;
            ViewBag.CurrentSearchString = SearchString;


            List<PersonResponse>? Persons = await _personsGetterService.GetFilteredPersons(SearchString, SearchBy);

            //Sort
            List<PersonResponse>? SortedPersons = _personsSorterService.GetSortedPersons(Persons, sortedBy, sortOrder);
            ViewBag.CurrentSortedBy = sortedBy;
            ViewBag.CurrentSortOrder = sortOrder.ToString();

            return View(SortedPersons);// Views/Persons/index.cshtml
        }
        [Authorize(Roles = "Admin")]
        [Route("Create")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<CountryResponse>? Countries = await _countriesService.GetAllCountries();
            ViewBag.Countries = Countries;
            return View();// Views/Persons/Create.cshtml
        }
        [Authorize(Roles = "Admin")]
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(PersonAddRequest personAddRequest)
        {
            if (!ModelState.IsValid)
            {
                List<CountryResponse>? Countries = await _countriesService.GetAllCountries();
                ViewBag.Countries = Countries;
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View();
            }
            //Call the service method
            PersonResponse? personResponse = await _personsAdderService.AddPerson(personAddRequest);


            //Navigate to Index() action method (it makes another get request to Perosns/Index)
            return RedirectToAction("Index", "Persons");
        }
        [Authorize(Roles = "Admin")]
        [Route("[action]/{PersonId}")] //Eg: Persons/Edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? PersonId)
        {
            if (PersonId is null)
            {
                return RedirectToAction("index");
            }
            PersonResponse personResponse = await _personsGetterService.GetPersonByPersonId(PersonId);
            PersonUpdateRequest? personUpdateRequest = personResponse?.ToPersonUpdateRequest();
            List<CountryResponse>? Countries = await _countriesService.GetAllCountries();
            ViewBag.Countries = Countries;

            return View(personUpdateRequest);
        }
        [Authorize(Roles = "Admin")]
        [Route("[action]/{PersonId}")] //Eg: Persons/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(PersonUpdateRequest personUpdateRequest)
        {
            PersonResponse personResponse = await _personsGetterService.GetPersonByPersonId(personUpdateRequest.PersonId);
            if (personResponse is null)
            {
                return RedirectToAction("index");
            }
            if (ModelState.IsValid)
            {
                PersonResponse UpdatedPerson = await _personsUpdaterService.UpdatePerson(personUpdateRequest);
                return RedirectToAction("index");
            }

            List<CountryResponse>? Countries = await _countriesService.GetAllCountries();
            ViewBag.Countries = Countries;
            ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            return View();
        }

        [Authorize(Roles = "Admin")]
        [Route("[action]/{PersonId}")] //Eg: Persons/Delete/1
        [HttpGet]
        public async Task<IActionResult> Delete(Guid? PersonId)
        {
            PersonResponse? personResponse = await _personsGetterService.GetPersonByPersonId(PersonId);
            if (personResponse is null)
            {
                return RedirectToAction("index");
            }

            return View(personResponse);
        }

        [Authorize(Roles = "Admin")]
        [Route("[action]/{PersonId}")] //Eg: Persons/Delete/1
        [HttpPost]
        public async Task<IActionResult> Delete(PersonUpdateRequest personUpdateRequest)
        {
            PersonResponse? personResponse = await _personsGetterService.GetPersonByPersonId(personUpdateRequest.PersonId);
            if (personResponse is null)
                return RedirectToAction("index");

            bool isDeleted = await _personsDeleterService.DeletePerson(personUpdateRequest.PersonId); //It should be true
            return RedirectToAction("index");
        }

        [Route("DownloadPdf")]
        public async Task<IActionResult> PersonsPdf()
        {
            var persons = await _personsGetterService.GetAllPersons();
            return new ViewAsPdf("PersonsPdf",persons,ViewData)
            {                
                PageMargins = new Margins() { Top = 10, Bottom = 10, Right = 10, Left = 10 },
                PageOrientation = Orientation.Landscape
            };
        }

    }
}
