using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace FastighetsAPI.Functions
{
    public class GetApartmentsByCompanyId
    {
        private readonly IApartmentService _apartmentService;

        public GetApartmentsByCompanyId(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [FunctionName("GetApartmentsByCompanyId")]
        public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "companies/{companyId}/apartments")] HttpRequest req, int companyId)
        {
            var companies = await _apartmentService.GetApartmentsByCompanyId(companyId);
            return new OkObjectResult(companies);
        }
    }
}