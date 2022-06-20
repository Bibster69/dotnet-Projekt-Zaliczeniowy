using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kalkulatol.Models;
using Kalkulatol.Repositories;

namespace Kalkulatol.Controllers
{
    public class SkladnikController : Controller
    {

        private readonly ISkladnikRepository _SkladnikRepository;

        public SkladnikController(ISkladnikRepository skladnikRepository)
        {
            _SkladnikRepository = skladnikRepository;
        }
        

        private static List<SkladnikModel> listaTest = new List<SkladnikModel>()
        {
            new SkladnikModel() { SkladnikId = 1, SkladnikName = "Papryka", SkladnikProtPer100 = 1, SkladnikCarbPer100 = 5, SkladnikFatPer100 = 0, 
            SkladnikIlosc = 100, SkladnikKcal = 32},
            new SkladnikModel() { SkladnikId = 2, SkladnikName = "Bakłażan", SkladnikProtPer100 = 1, SkladnikCarbPer100 = 6, SkladnikFatPer100 = 0,
            SkladnikIlosc = 100, SkladnikKcal = 29}
        };
        // GET: SkladnikController
        public ActionResult Index()
        {
            return View(_SkladnikRepository.GetAll());
            //return View(listaTest);
        }

        // GET: SkladnikController/Details/5
        public ActionResult Details(int id)
        {
            //return View(listaTest.FirstOrDefault(x => x.SkladnikId == id));
            return View(_SkladnikRepository.Get(id));
        }

        // GET: SkladnikController/Create
        public ActionResult Create()
        {
            return View(new SkladnikModel());
        }

        // POST: SkladnikController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SkladnikModel Skladnik)
        {
            /*
            Skladnik.SkladnikId = listaTest.Count + 1;
            Skladnik.SkladnikKcal = ((4 * Skladnik.SkladnikProtPer100) + (4 * Skladnik.SkladnikCarbPer100) + (9 * Skladnik.SkladnikFatPer100)) * (Skladnik.SkladnikIlosc / 100);
            listaTest.Add(Skladnik);
            return RedirectToAction(nameof(Index));
            */
            _SkladnikRepository.Add(Skladnik);
            return RedirectToAction(nameof(Index));
        }

        // GET: SkladnikController/Edit/5
        public ActionResult Edit(int id)
        {
            //return View(listaTest.FirstOrDefault(x => x.SkladnikId == id));
            return View(_SkladnikRepository.Get(id));
        }

        // POST: SkladnikController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SkladnikModel Edycja)
        {
            /*
            SkladnikModel Edytowany = listaTest.FirstOrDefault(x => x.SkladnikId == id);
            Edytowany.SkladnikName = Edycja.SkladnikName;
            Edytowany.SkladnikFatPer100 = Edycja.SkladnikFatPer100;
            Edytowany.SkladnikCarbPer100 = Edycja.SkladnikCarbPer100;
            Edytowany.SkladnikProtPer100 = Edycja.SkladnikProtPer100;
            Edytowany.SkladnikIlosc = Edycja.SkladnikIlosc;

            Edytowany.SkladnikKcal = ((4 * Edycja.SkladnikProtPer100) + (4 * Edycja.SkladnikCarbPer100) + (9 * Edycja.SkladnikFatPer100)) * (Edycja.SkladnikIlosc / 100);

            return RedirectToAction(nameof(Index));
            */
            _SkladnikRepository.Update(id, Edycja);
            return RedirectToAction(nameof(Index));
        }

        // GET: SkladnikController/Delete/5
        public ActionResult Delete(int id)
        {
            //return View(listaTest.FirstOrDefault(x => x.SkladnikId == id));
            return View(_SkladnikRepository.Get(id));
        }

        // POST: SkladnikController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SkladnikModel wybrany)
        {
            /*
            SkladnikModel usuwany = listaTest.FirstOrDefault(x => x.SkladnikId == id);
            listaTest.Remove(usuwany);
            return RedirectToAction(nameof(Index));
            */
            _SkladnikRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
