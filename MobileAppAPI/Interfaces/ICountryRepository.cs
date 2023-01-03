using MobileAppAPI.Models;

namespace MobileAppAPI.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
    }
}
