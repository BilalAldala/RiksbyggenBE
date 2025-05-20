using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FastighetsAPI.Functions
{
    public class UpdateApartmentContractDateWebhook
    {
        private readonly IApartmentService _apartmentService;

        public UpdateApartmentContractDateWebhook(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [FunctionName("UpdateApartmentContractDateWebhook")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "apartments/webhook/update-contract-date")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var apartment = JsonConvert.DeserializeObject<UpdateContractDate>(requestBody);
            if (apartment == null)
            {
                return new BadRequestObjectResult("Ogiltig payload");
            }

            await _apartmentService.UpdateApartmentContractDate(apartment.CompanyId, apartment.ApartmentId, apartment.NewContractEndDate);

            return new OkObjectResult(new { success = true });
        }
    }
}