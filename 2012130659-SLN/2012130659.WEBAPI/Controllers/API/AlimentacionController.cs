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
    public class AlimentacionController : ApiController
    {
        private readonly IUnityofWork _UnityOfWork;

        public AlimentacionController(IUnityofWork unityOfWorck)
        {
            _UnityOfWork = unityOfWorck;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var Alimentaciones = _UnityOfWork.Alimentacion.GetAll();

            if (Alimentaciones == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var AlimentacionDTO= new List<AlimentacionDTO>();

            foreach (var alimentacion in Alimentaciones)
                AlimentacionDTO.Add(Mapper.Map<Alimentacion, AlimentacionDTO>(alimentacion));

            return Ok(AlimentacionDTO);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var Alimentacion = _UnityOfWork.Alimentacion.Get(id);

            if (Alimentacion == null)
                return NotFound();

            return Ok(Mapper.Map<Alimentacion, AlimentacionDTO>(Alimentacion));
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlimentacionDTO AlimentacionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var AlimentacionInPersistence = _UnityOfWork.Alimentacion.Get(id);
            if (AlimentacionInPersistence == null)
                return NotFound();

            Mapper.Map<AlimentacionDTO, Alimentacion>(AlimentacionDTO, AlimentacionInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(AlimentacionDTO);
        }

        [HttpPost]
        public IHttpActionResult Create(AlimentacionDTO alimentacionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var alimentacion = Mapper.Map<AlimentacionDTO, Alimentacion>(alimentacionDTO);

            _UnityOfWork.Alimentacion.Add(alimentacion);
            _UnityOfWork.SaveChanges();

            alimentacionDTO.CategoriaAlimentacion = alimentacion.CategoriaAlimentacion;

            return Created(new Uri(Request.RequestUri + "/" + alimentacion.CategoriaAlimentacion), alimentacionDTO);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var alimentacionInDataBase = _UnityOfWork.Alimentacion.Get(id);
            if (alimentacionInDataBase == null)
                return NotFound();

            _UnityOfWork.Alimentacion.Delete(alimentacionInDataBase);
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