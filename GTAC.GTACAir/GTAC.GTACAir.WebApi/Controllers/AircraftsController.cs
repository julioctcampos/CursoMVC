using AutoMapper;
using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Repository.Entity.Impl.v1;
using GTAC.GTACAir.Services.Impl.v1;
using GTAC.GTACAir.Services.Interfaces;
using GTAC.GTACAir.WebApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GTAC.GTACAir.WebApi.Controllers
{
    public class AircraftsController : ApiController
    {
        IAircraftService _aircraftService;

        public AircraftsController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        // GET: api/Aircrafts
        public List<AircraftDTO> Get()
        {
            return Mapper.Map<List<Aircraft>, List<AircraftDTO>>(_aircraftService.Select());
        }

        // GET: api/Aircrafts/5
        public AircraftDTO Get(int id)
        {
            return Mapper.Map<Aircraft, AircraftDTO>(_aircraftService.SelectById(id));
        }

        // POST: api/Aircrafts
        public HttpResponseMessage Post([FromBody]AircraftDTO aircraftDTO)
        {
            if (ModelState.IsValid)
            {
                Aircraft aircraft = Mapper.Map<AircraftDTO, Aircraft>(aircraftDTO);
                _aircraftService.Insert(aircraft);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return ErrorResponse();
            }
        }

        // PUT: api/Aircrafts/5
        public HttpResponseMessage Put(int id, [FromBody]AircraftDTO aircraftDTO)
        {
            if (ModelState.IsValid)
            {
                Aircraft aircraft = Mapper.Map<AircraftDTO, Aircraft>(aircraftDTO);
                _aircraftService.Update(aircraft);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return ErrorResponse();
            }   
        }

        // DELETE: api/Aircrafts/5
        public HttpResponseMessage Delete(int id)
        {
            _aircraftService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        private HttpResponseMessage ErrorResponse()
        {
            string errorMessage = "";
            ModelState.Values.ToList().ForEach(e =>
            {
                e.Errors.ToList().ForEach(em =>
                {
                    errorMessage += em.ErrorMessage + Environment.NewLine;
                });
            });
            return Request.CreateResponse(HttpStatusCode.BadRequest, errorMessage);
        }
    }
}
