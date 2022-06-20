using Kalkulatol.Models;
namespace Kalkulatol.Repositories
{
    public interface ISkladnikRepository
    {
        SkladnikModel Get(int skladnikid);
        IQueryable<SkladnikModel> GetAll();
        void Add(SkladnikModel skladnik);
        void Update(int skladnikID, SkladnikModel skladnik);
        void Delete(int skladnikID);
    }
}
