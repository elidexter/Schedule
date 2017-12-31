using Concert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concert.Controllers
{
    public class SchedulerController : Controller
    {        

        // GET: Scheduler/Create
        public ActionResult Index()
        {
            FillDrop();
            Programacion model = new Programacion();
            String cod = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            model.PgrId = long.Parse(cod);
            model.From = DateTime.Now;
            model.Hasta = DateTime.Now.AddHours(3);
            return View(model);
        }

        // POST: Scheduler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Programacion model)
        {
            FillDrop();
            try
            {
                if(!ModelState.IsValid)
                {
                    ModelState.AddModelError("Error", "Invalid Model");
                    return View(model);
                }
                DataAcces.xsDataTableAdapters.ScheduleTableAdapter adapter = new DataAcces.xsDataTableAdapters.ScheduleTableAdapter();
                adapter.Insert(model.PgrId, model.SalaId, model.Contacto, model.Encargado, model.From, model.Hasta,model.EventoNombre);
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Scheduler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Scheduler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Scheduler/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Scheduler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Scheduler/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public void FillDrop()
        {
            DataAcces.xsData.vwSalaDataTable table = new DataAcces.xsData.vwSalaDataTable();
            DataAcces.xsDataTableAdapters.vwSalaTableAdapter adp = new DataAcces.xsDataTableAdapters.vwSalaTableAdapter();
            adp.Fill(table);
            List<SalaModel> sal = new List<SalaModel>();
            foreach (DataAcces.xsData.vwSalaRow row in table)
            {
                SalaModel sl = new SalaModel();
                sl.Descripcion = row.Descripcion;
                sl.SalaId = row.IdSala;
                sal.Add(sl);
            }
            ViewBag.Sal = sal;
        }
    }
}
