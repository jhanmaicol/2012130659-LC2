using AutoMapper;
using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.DTO;
using PaquetesTuristicos.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace _2012130659.WEBAPI.Controllers.API
{
    public class ComprovantePagoController : ApiController
    {
        private readonly IUnityofWork _UnityOfWork;

        public ComprovantePagoController(IUnityofWork unityOfWorck)
        {
            _UnityOfWork = unityOfWorck;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var ComprobantePagos = _UnityOfWork.ComprobantePago.GetAll();

            if (ComprobantePagos == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var ComprovantePagoDTO = new List<ComprobantePagoDTO>();

            foreach (var comprobantePago in ComprobantePagos)
                ComprovantePagoDTO.Add(Mapper.Map<ComprobantePago, ComprobantePagoDTO>(comprobantePago));

            return Ok(ComprovantePagoDTO);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var ComprobantePago = _UnityOfWork.ComprobantePago.Get(id);

            if (ComprobantePago == null)
                return NotFound();

            return Ok(Mapper.Map<ComprobantePago, ComprobantePagoDTO>(ComprobantePago));
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ComprobantePagoDTO ComprobantePagoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var comprobantePagoInPersistence = _UnityOfWork.ComprobantePago.Get(id);
            if (comprobantePagoInPersistence == null)
                return NotFound();

            Mapper.Map<ComprobantePagoDTO, ComprobantePago>(ComprobantePagoDTO, comprobantePagoInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(ComprobantePagoDTO);
        }

        [HttpPost]
        public IHttpActionResult Create(ComprobantePagoDTO comprobantePagoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var comprobantePago = Mapper.Map<ComprobantePagoDTO, ComprobantePago>(comprobantePagoDTO);

            _UnityOfWork.ComprobantePago.Add(comprobantePago);
            _UnityOfWork.SaveChanges();

            comprobantePagoDTO.ComprobantePagoId = comprobantePago.ComprobantePagoId;

            return Created(new Uri(Request.RequestUri + "/" + comprobantePago.ComprobantePagoId), comprobantePagoDTO);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var comprobantePagoInDataBase = _UnityOfWork.ComprobantePago.Get(id);
            if (comprobantePagoInDataBase == null)
                return NotFound();

            _UnityOfWork.ComprobantePago.Delete(comprobantePagoInDataBase);
            _UnityOfWork.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
