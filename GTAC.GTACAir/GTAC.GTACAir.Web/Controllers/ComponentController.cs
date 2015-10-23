using AutoMapper;
using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Repository.Entity.Impl.v1;
using GTAC.GTACAir.Services.Interfaces;
using GTAC.GTACAir.Web.Models.Component;
using GTAC.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GTAC.GTACAir.Web.Controllers
{
    public class ComponentController : Controller
    {
        private IComponentService _componentService;
        private IAircraftService _aircraftService;

        public ComponentController(IComponentService componentService,
            IAircraftService aircraftService)
        {
            _componentService = componentService;
            _aircraftService = aircraftService;
        }

        // GET: Component
        public ActionResult Index()
        {
            List<Component> components = _componentService.Select();
            List<ComponentViewModel> viewModels
                = Mapper.Map<List<Component>, List<ComponentViewModel>>(components);
            return View(viewModels);
        }

        //public ActionResult FilterComponents(string componentName)
        //{
        //    List<Component> components = _repositoryComponent.SelectAll();
        //    List<ComponentViewModel> viewModels
        //        = Mapper.Map<List<Component>, List<ComponentViewModel>>(components.Where(w => w.Title.ToLower().Contains(componentName.ToLower())).ToList());
        //    return Json(viewModels, JsonRequestBehavior.AllowGet);
        //}

        // GET: Component/Details/5
        //public ActionResult Details(int id)
        //{
        //    Component component = _repositoryComponent.SelectByKey(id);
        //    ComponentViewModel viewModel = 
        //        Mapper.Map<Component, ComponentViewModel>(component);
        //    return View(viewModel);
        //}

        // GET: Component/Create
        public ActionResult Create()
        {
            CreateAircraftListInViewBag();
            return View();
        }

        private void CreateAircraftListInViewBag()
        {
            List<Aircraft> aircrafts = _aircraftService.Select();
            List<SelectListItem> selectList = new List<SelectListItem>();
            aircrafts.ForEach(aircraft =>
            {
                selectList.Add(new SelectListItem
                {
                    Text = aircraft.Model,
                    Value = aircraft.Id.ToString(),
                    Selected = false

                });
            });
            ViewBag.Aircrafts = selectList;
        }

        // POST: Component/Create
        [HttpPost]
        public ActionResult Create(ComponentCUDViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Component component =
                        Mapper.Map<ComponentCUDViewModel, Component>(viewModel);
                    _componentService.Insert(component);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    CreateAircraftListInViewBag();
                    ModelState.AddModelError("component_generic_error", ex.Message);
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }

        // GET: Component/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    Component component = _repositoryComponent.SelectByKey(id);
        //    ComponentCUDViewModel viewModel =
        //        Mapper.Map<Component, ComponentCUDViewModel>(component);

        //    List<Aircraft> aircrafts = _repositoryAircraft.SelectAll();
        //    List<SelectListItem> selectList = new List<SelectListItem>();
        //    aircrafts.ForEach(aircraft =>
        //    {
        //        selectList.Add(new SelectListItem
        //        {
        //            Text = aircraft.Model,
        //            Value = aircraft.Id.ToString(),
        //            Selected = false

        //        });
        //    });
        //    ViewBag.Aircrafts = selectList;

        //    return View(viewModel);
        //}

        // POST: Component/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, ComponentCUDViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            Component component =
        //                    Mapper.Map<ComponentCUDViewModel, Component>(viewModel);
        //            _repositoryComponent.Update(component);
        //            return RedirectToAction("Index");
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("component_generic_error", ex.Message);
        //            return View(viewModel);
        //        }
        //    }
        //    return View(viewModel);
        //}

        // GET: Component/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    Component component = _repositoryComponent.SelectByKey(id);
        //    ComponentCUDViewModel viewModel =
        //        Mapper.Map<Component, ComponentCUDViewModel>(component);
        //    return View(viewModel);
        //}

        // POST: Component/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, ComponentCUDViewModel viewModel)
        //{
        //    try
        //    {
        //        _repositoryComponent.DeleteByKey(id);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("component_generic_error", ex.Message);
        //        return View(viewModel);
        //    }
        //}
    }
}
