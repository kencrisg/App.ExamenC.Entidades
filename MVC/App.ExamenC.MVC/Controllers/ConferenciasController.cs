using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.ExamenC.ConsumeAPI;
using App.ExamenC.Entidades;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace App.ExamenC.MVC.Controllers
{
    public class ConferenciasController : Controller
    {
        private string urlApi;
        public ConferenciasController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Conferencia";
        }
        // GET: ConferenciasController
        public ActionResult Index()
        {
            var data = Crud<Conferencia>.Read(urlApi);
            return View(data);
        }

        // GET: ConferenciasController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Conferencia>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: ConferenciasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConferenciasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Conferencia data)
        {
            try
            {
                var newData = Crud<Conferencia>.Create(urlApi, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: ConferenciasController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Conferencia>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: ConferenciasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Conferencia data)
        {
            try
            {
                Crud<Conferencia>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: ConferenciasController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Conferencia>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: ConferenciasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Conferencia data)
        {
            try
            {
                Crud<Conferencia>.Delete(urlApi, id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
