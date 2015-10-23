using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Persistence.Entity.Context;
using GTAC.GTACAir.Web.Models;
using AutoMapper;
using GTAC.Repository.Interfaces;
using GTAC.GTACAir.Repository.Entity.Impl.v1;

namespace GTAC.GTACAir.Web.Controllers
{
    public class CrewController : Controller
    {
        IGTACGenericRepository<Crew, int> _repository;

        public CrewController(IGTACGenericRepository<Crew, int> repository)
        {
            _repository = repository;
        }

        // GET: Crew
        public ActionResult Index()
        {
            List<Crew> crews = _repository.SelectAll();
            List<CrewViewModel> viewModels = Mapper.Map<List<Crew>, List<CrewViewModel>>(crews);
            return View(viewModels);
        }

        public ActionResult FilterCrews(string crewName)
        {
            List<Crew> crews = _repository.SelectAll();
            List<CrewViewModel> viewModels = Mapper.Map<List<Crew>, List<CrewViewModel>>(crews.Where(w => w.Name.ToLower().Contains(crewName.ToLower())).ToList());
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        // GET: Crew/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = _repository.SelectByKey(id.Value);
            if (crew == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Crew, CrewViewModel>(crew));
        }

        // GET: Crew/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crew/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AnacCode,CompanyNumber,Active,Nickname")] CrewViewModel crewViewModel)
        {
            if (ModelState.IsValid)
            {
                Crew crew = Mapper.Map<CrewViewModel, Crew>(crewViewModel);
                _repository.Insert(crew);
                return RedirectToAction("Index");
            }

            return View(crewViewModel);
        }

        // GET: Crew/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = _repository.SelectByKey(id.Value);
            if (crew == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Crew, CrewViewModel>(crew));
        }

        // POST: Crew/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AnacCode,CompanyNumber,Active,Nickname")] CrewViewModel crewViewModel)
        {
            if (ModelState.IsValid)
            {
                Crew crew = Mapper.Map<CrewViewModel, Crew>(crewViewModel);
                _repository.Update(crew);
                return RedirectToAction("Index");
            }
            return View(crewViewModel);
        }

        // GET: Crew/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = _repository.SelectByKey(id.Value);
            if (crew == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Crew, CrewViewModel>(crew));
        }

        // POST: Crew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteByKey(id);
            return RedirectToAction("Index");
        }
    }
}
