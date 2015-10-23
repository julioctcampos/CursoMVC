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
    public class AircraftController : Controller
    {
        IGTACGenericRepository<Aircraft, int> _repository;

        public AircraftController(IGTACGenericRepository<Aircraft, int> repository)
        {
            _repository = repository;
        }

        // GET: Aircraft
        public ActionResult Index()
        {
            List<Aircraft> aircrafts = _repository.SelectAll();
            List<AircraftViewModel> viewModels = Mapper.Map<List<Aircraft>, List<AircraftViewModel>>(aircrafts);
            return View(viewModels);
        }

        public ActionResult FilterAircrafts(string aircraftModel)
        {
            List<Aircraft> aircrafts = _repository.SelectAll();
            List<AircraftViewModel> viewModel
                = Mapper.Map<List<Aircraft>, List<AircraftViewModel>>(aircrafts.Where(w => w.Model.ToLower().Contains(aircraftModel.ToLower())).ToList());

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        // GET: Aircraft/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = _repository.SelectByKey(id.Value);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Aircraft, AircraftViewModel>(aircraft));
        }

        // GET: Aircraft/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aircraft/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Model,Preffix,SeatCount,ManufacturerSite")] AircraftViewModel aircraftViewModel)
        {
            if (ModelState.IsValid)
            {
                Aircraft aircraft = Mapper.Map<AircraftViewModel, Aircraft>(aircraftViewModel);
                _repository.Insert(aircraft);
                return RedirectToAction("Index");
            }

            return View(aircraftViewModel);
        }

        // GET: Aircraft/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = _repository.SelectByKey(id.Value);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Aircraft, AircraftViewModel>(aircraft));
        }

        // POST: Aircraft/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model,Preffix,SeatCount,ManufacturerSite")] AircraftViewModel aircraftViewModel)
        {
            if (ModelState.IsValid)
            {
                Aircraft aircraft = Mapper.Map<AircraftViewModel, Aircraft>(aircraftViewModel);
                _repository.Update(aircraft);
                return RedirectToAction("Index");
            }
            return View(aircraftViewModel);
        }

        // GET: Aircraft/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aircraft aircraft = _repository.SelectByKey(id.Value);
            if (aircraft == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Aircraft, AircraftViewModel>(aircraft));
        }

        // POST: Aircraft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteByKey(id);
            return RedirectToAction("Index");
        }
    }
}
