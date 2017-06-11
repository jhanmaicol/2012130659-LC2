using AutoMapper;
using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2012130659.WEBAPI.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Alimentacion, ComprobantePagoDTO>();
            CreateMap<ComprobantePagoDTO,Alimentacion> ();

            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

            CreateMap<ComprobantePago, ComprobantePagoDTO>();
            CreateMap<ComprobantePagoDTO, ComprobantePago>();

            CreateMap<Empleado, EmpleadoDTO>();
            CreateMap<EmpleadoDTO, Empleado>();

            CreateMap<Hospedaje, HospedajeDTO>();
            CreateMap<HospedajeDTO, Hospedaje>();

            CreateMap<Paquete, PaqueteDTO>();
            CreateMap<PaqueteDTO, Paquete>();

            CreateMap<Persona, PersonaDTO>();
            CreateMap<PersonaDTO, Persona>();

            CreateMap<ServicioTuristico, ServicioTuristicoDTO>();
            CreateMap<ServicioTuristicoDTO, ServicioTuristico>();

            CreateMap<Transporte, TransporteDTO>();
            CreateMap<TransporteDTO, Transporte>();

            CreateMap<VentaPaquete, VentaPaqueteDTO>();
            CreateMap<VentaPaqueteDTO, VentaPaquete>();
        }
    }
}