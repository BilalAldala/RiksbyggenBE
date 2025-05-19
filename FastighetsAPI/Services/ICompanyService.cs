public interface ICompanyService
{
    Task<IEnumerable<Company>> GetAllCompanies();
}
