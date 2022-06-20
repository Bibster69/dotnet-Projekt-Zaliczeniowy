
using Kalkulatol.Data;
using Kalkulatol.Models;

namespace Kalkulatol.Repositories
{
    public class SkladnikRepository : ISkladnikRepository
    {
        private readonly AuthDbContext _context;
        public SkladnikRepository(AuthDbContext context)
        {
            _context = context;
        }

        public void Add(SkladnikModel Skladnik)
        {
            Skladnik.SkladnikKcal = ((4 * Skladnik.SkladnikProtPer100) + (4 * Skladnik.SkladnikCarbPer100) + (9 * Skladnik.SkladnikFatPer100)) * (Skladnik.SkladnikIlosc / 100);
            _context.Skladniki.Add(Skladnik);
            _context.SaveChanges();
        }

        public void Delete(int skladnikID)
        {
            var result = _context.Skladniki.SingleOrDefault(x => x.SkladnikId == skladnikID);
            if(result != null)
            {
                _context.Skladniki.Remove(result);
                _context.SaveChanges();
            }
        }

        public SkladnikModel Get(int skladnikid)
            => _context.Skladniki.SingleOrDefault(x => x.SkladnikId == skladnikid);

        public IQueryable<SkladnikModel> GetAll()
            => _context.Skladniki.Where(x => x.SkladnikKcal != 0);

        public void Update(int skladnikID, SkladnikModel skladnik)
        {
            var result = _context.Skladniki.SingleOrDefault(x => x.SkladnikId == skladnikID);
            if(result != null)
            {
                result.SkladnikName = skladnik.SkladnikName;
                result.SkladnikFatPer100 = skladnik.SkladnikFatPer100;
                result.SkladnikProtPer100 = skladnik.SkladnikProtPer100;
                result.SkladnikCarbPer100 = skladnik.SkladnikCarbPer100;
                result.SkladnikIlosc = skladnik.SkladnikIlosc;
                result.SkladnikKcal = ((4 * result.SkladnikProtPer100) + (4 * result.SkladnikCarbPer100) + (9 * result.SkladnikFatPer100)) * (result.SkladnikIlosc / 100);

                _context.SaveChanges();
            }
        }
    }
}
