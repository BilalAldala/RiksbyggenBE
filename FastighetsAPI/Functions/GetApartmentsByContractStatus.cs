using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace FastighetsAPI.Functions
{
    public class GetApartmentsByContractStatus
    {
    private readonly IApartmentService _apartmentService;

        public GetApartmentsByContractStatus(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [FunctionName("GetApartmentsByContractStatus")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "companies/{companyId}/apartments/contractStatus")] HttpRequest req, int companyId)
        {
            int numberOfMonths = 3;
            if (int.TryParse(req.Query["numberOfMonths"], out var parsedMonths))
            {
                numberOfMonths = parsedMonths;
            }
            
            var apartments  = await _apartmentService.GetApartmentsByContractStatus(companyId, numberOfMonths);
            return new OkObjectResult(apartments );
        }
    }
}