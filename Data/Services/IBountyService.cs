using Hackathon_2025_Filipino_Homes.Models;

namespace Hackathon_2025_Filipino_Homes.Data.Services
{
    public interface IBountyService
    {
        Task<IEnumerable<Account>> GetAll();
    }
}
