using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace FastighetsAPI.Functions
{
    public class GetAllCompanies
    {
    private readonly ICompanyService _companyService;

        public GetAllCompanies(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [FunctionName("GetAllCompanies")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "companies")] HttpRequest req)
        {
            var companies = await _companyService.GetAllCompanies();
            return new OkObjectResult(companies);
        }
    }
}