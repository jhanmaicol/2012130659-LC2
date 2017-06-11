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
    public class ClienteController : ApiController
    {
        private readonly IUnityofWork _UnityOfWork;

        public ClienteController(IUnityofWork unityOfWorck)
        {
            _UnityOfWork = unityOfWorck;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var Clientes = _UnityOfWork.Cliente.GetAll();

            if (Clientes == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var ClienteDTO = new List<ClienteDTO>();

            foreach (var cliente in Clientes)
                ClienteDTO.Add(Mapper.Map<Cliente, ClienteDTO>(cliente));

            return Ok(ClienteDTO);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var Cliente = _UnityOfWork.Cliente.Get(id);

            if (Cliente == null)
                return NotFound();

            return Ok(Mapper.Map<Cliente, ClienteDTO>(Cliente));
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ClienteDTO ClienteDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ClienteInPersistence = _UnityOfWork.Cliente.Get(id);
            if (ClienteInPersistence == null)
                return NotFound();

            Mapper.Map<ClienteDTO, Cliente>(ClienteDTO, ClienteInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(ClienteDTO);
        }

        [HttpPost]
        public IHttpActionResult Create(ClienteDTO clienteDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cliente = Mapper.Map<ClienteDTO, Cliente>(clienteDTO);

            _UnityOfWork.Cliente.Add(cliente);
            _UnityOfWork.SaveChanges();

            clienteDTO.PersonaId = cliente.PersonaId;
            
            
            return Created(new Uri(Request.RequestUri + "/" + cliente.PersonaId), clienteDTO);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var clienteInDataBase = _UnityOfWork.Cliente.Get(id);
            if (clienteInDataBase== null)
                return NotFound();

            _UnityOfWork.Cliente.Delete(clienteInDataBase);
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