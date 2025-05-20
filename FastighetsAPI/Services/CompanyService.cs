using Microsoft.EntityFrameworkCore;
using FastighetsAPI.Data;

public class CompanyService : ICompanyService
{
    private readonly AppDbContext _context;

    public CompanyService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Company>> GetAllCompanies()
    {
        return await _context.Companies.ToListAsync();
    }
}
