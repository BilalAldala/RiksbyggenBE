using Microsoft.EntityFrameworkCore;
using FastighetsAPI.Data;

public class ApartmentService : IApartmentService
{
    private readonly AppDbContext _context;

    public ApartmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Apartment>> GetApartmentsByCompanyId(int companyId)
    {
        return await _context.Apartments.Where(apartment => apartment.CompanyId == companyId).ToListAsync();
    }

    public async Task<IEnumerable<Apartment>> GetApartmentsByContractStatus(int companyId, int numberOfMonths)
    {
        DateTime date = DateTime.Today.AddMonths(numberOfMonths);
        return await _context.Apartments.Where(apartment => apartment.CompanyId == companyId && apartment.ContractEndDate <= date).ToListAsync();
    }
}
