using Microsoft.AspNetCore.Mvc.Filters;
using ServiceContracts.DTO;

namespace ContactsManager.Filters.ActionFilters
{
    public class PersonsListActionFilter : IActionFilter
    {
        private readonly ILogger<PersonsListActionFilter> _logger;
        public PersonsListActionFilter(ILogger<PersonsListActionFilter> logger)
        {
            _logger = logger;
        }
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            // This method is called after the action method is executed.
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            // This method is called before the action method is executed.
            _logger.LogInformation("Executing PersonsListActionFilter before the action method.");

            if (context.ActionArguments.ContainsKey("SearchBy"))
            {

                var searchby = context.ActionArguments["SearchBy"]?.ToString();

                if (!string.IsNullOrEmpty(searchby))
                {
                    var searchByOptions = new List<string>
                   {
                      nameof(PersonResponse.PersonName),
                      nameof(PersonResponse.Gender),
                      nameof(PersonResponse.CountryName),
                      nameof(PersonResponse.BirthDate),
                      nameof(PersonResponse.Email),
                      nameof(PersonResponse.Address)
                   };

                    if (searchByOptions.Any(temp=>temp==searchby)==false)
                    {
                        _logger.LogInformation("Search by actual value {SearchBy}", searchby);
                        context.ActionArguments["SearchBy"]=nameof(PersonResponse.PersonName);
                        _logger.LogInformation("Search by Updated value {SearchBy}", nameof(PersonResponse.PersonName));
                    }
                }

            }
        }
    }
}
