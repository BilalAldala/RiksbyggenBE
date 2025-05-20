public interface IApartmentService
{
    Task<IEnumerable<Apartment>> GetApartmentsByCompanyId(int companyId);
    Task<IEnumerable<Apartment>> GetApartmentsByContractStatus(int companyId, int numberOfMonths);
    Task <Apartment> UpdateApartmentContractDate(int companyId, int apartmentId, DateTime newComntractDate);
}