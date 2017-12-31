using Concert.DataAcces;
using Concert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concert.Controllers
{
    public class SalaController : Controller
    {
        // GET: Sala
        public ActionResult Index()
        {
            DataAcces.xsData.SalaDataTable tbl = new xsData.SalaDataTable();
            DataAcces.xsDataTableAdapters.SalaTableAdapter adp = new DataAcces.xsDataTableAdapters.SalaTableAdapter();
            adp.Fill(tbl);
            List<SalaModel> lista = new List<SalaModel>();
            foreach (DataAcces.xsData.SalaRow row in tbl)
            {
                SalaModel md = new SalaModel();
                md.SalaId = row.IdSala;
                md.Descripcion = row.Descripcion;
                lista.Add(md);
            }            
            return View(lista);
        }

        // GET: Sala/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sala/Create
        public ActionResult Create()
        {
            SalaModel model = new SalaModel();
            String cod = DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Day.ToString()+DateTime.Now.Hour.ToString()+DateTime.Now.Minute.ToString();            
            model.SalaId = long.Parse(cod);
            return View(model);
        }

        // POST: Sala/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalaModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    DataAcces.xsDataTableAdapters.SalaTableAdapter salaadp = new DataAcces.xsDataTableAdapters.SalaTableAdapter();
                    salaadp.Insert(model.SalaId, model.Descripcion);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error","Model not valid");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Sala/Edit/5
        public ActionResult Edit(String id)
        {
            DataAcces.xsData.SalaDataTable tbl = new xsData.SalaDataTable();
            DataAcces.xsDataTableAdapters.SalaTableAdapter adp = new DataAcces.xsDataTableAdapters.SalaTableAdapter();
            adp.Fill(tbl);
            var rows=tbl.FindByIdSala(long.Parse(id));
            if (rows == null)
            {
                return new HttpNotFoundResult();
            }
            SalaModel model = new SalaModel();
            model.SalaId = rows.IdSala;
            model.Descripcion = rows.Descripcion;
            return View(model);
        }

        // POST: Sala/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(String id, SalaModel model)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(id))
                {
                    return new HttpNotFoundResult();
                }
                DataAcces.xsDataTableAdapters.SalaTableAdapter adp = new DataAcces.xsDataTableAdapters.SalaTableAdapter();
                adp.Update(model.Descripcion, model.SalaId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sala/Delete/5
        public ActionResult Delete(String id)
        {
            DataAcces.xsData.SalaDataTable tbl = new xsData.SalaDataTable();
            DataAcces.xsDataTableAdapters.SalaTableAdapter adp = new DataAcces.xsDataTableAdapters.SalaTableAdapter();
            adp.Fill(tbl);
            var rows = tbl.FindByIdSala(long.Parse(id));
            if (rows == null)
            {
                return new HttpNotFoundResult();
            }
            SalaModel model = new SalaModel();
            model.SalaId = rows.IdSala;
            model.Descripcion = rows.Descripcion;
            return View(model);
        }

        // POST: Sala/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(String id, SalaModel model)
        {
            try
            {
                if(id!=model.SalaId.ToString())
                {
                    ModelState.AddModelError("Error","Validation fail");
                    return View(model);
                }
                DataAcces.xsDataTableAdapters.SalaTableAdapter adp = new DataAcces.xsDataTableAdapters.SalaTableAdapter();
                adp.Delete(model.SalaId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
