using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    public class ServiceAmbiente : IServiceAmbiente
    {
        public List<AmbienteBE> obtenerAmbienteDisponiblePorAforo(DateTime fechaInicio, 
                                                                  DateTime fechaFinal, 
                                                                  Int32 aforoMenor,
                                                                  Int32 aforoMayor,
                                                                  String idUbigeo)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<AmbienteBE> lstAmbienteBE = new List<AmbienteBE>();
                    var listaAmbientes = (from item in entity.Ambiente
                                          where item.aforo >= aforoMenor &&
                                                item.aforo <= aforoMayor &&
                                                item.Hotel.idUbigeo == idUbigeo &&
                                                item.estado == true
                                          select item).ToList();

                    var listaReservas = (from item in entity.ReservaDetalle
                                         where item.Reserva.fechaIngreso >= fechaInicio &&
                                               item.Reserva.fechaSalida <= fechaFinal &&
                                               item.Reserva.estado == true
                                         select item).ToList();

                    foreach (var item in listaReservas)
                    {
                        listaAmbientes.Remove(item.Ambiente);
                    }

                    foreach (var item in listaAmbientes)
                    {
                        AmbienteBE objAmbienteBE = new AmbienteBE()
                        {
                            Distrito = item.Hotel.Ubigeo.ubicacion,
                            Direccion = item.Hotel.direccion,
                            Piso = item.piso,
                            Identificador = item.identificador,
                            Aforo = item.aforo,
                            Precio = item.precio
                        };
                        lstAmbienteBE.Add(objAmbienteBE);
                    }

                    return lstAmbienteBE;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<AmbienteBE> obtenerAmbienteDisponiblePorFecha(DateTime fechaInicio, 
                                                                  DateTime fechaFinal,
                                                                  String idUbigeo)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<AmbienteBE> lstAmbienteBE = new List<AmbienteBE>();
                    var listaAmbientes = (from item in entity.Ambiente
                                          where item.estado == true &&
                                                item.Hotel.idUbigeo == idUbigeo
                                          select item).ToList();

                    var listaReservas = (from item in entity.ReservaDetalle
                                         where item.Reserva.fechaIngreso >= fechaInicio && 
                                               item.Reserva.fechaSalida <= fechaFinal && 
                                               item.Reserva.estado == true
                                         select item).ToList();

                    foreach (var item in listaReservas)
                    {
                        listaAmbientes.Remove(item.Ambiente);
                    }

                    foreach (var item in listaAmbientes)
                    {
                        AmbienteBE objAmbienteBE = new AmbienteBE()
                        {
                            Distrito = item.Hotel.Ubigeo.ubicacion,
                            Direccion = item.Hotel.direccion,
                            Piso = item.piso,
                            Identificador = item.identificador,
                            Precio = item.precio
                        };
                        lstAmbienteBE.Add(objAmbienteBE);
                    }

                    return lstAmbienteBE;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<AmbienteBE> obtenerAmbienteDisponiblePorRangoDePrecios(DateTime fechaInicio, 
                                                                           DateTime fechaFinal, 
                                                                           Decimal precioMenor, 
                                                                           Decimal precioMayor,
                                                                           String idUbigeo)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<AmbienteBE> lstAmbienteBE = new List<AmbienteBE>();
                    var listaAmbientes = (from item in entity.Ambiente
                                          where item.precio >= precioMenor &&
                                                item.precio <= precioMayor &&
                                                item.Hotel.idUbigeo == idUbigeo &&
                                                item.estado == true
                                          select item).ToList();

                    var listaReservas = (from item in entity.ReservaDetalle
                                         where item.Reserva.fechaIngreso >= fechaInicio &&
                                               item.Reserva.fechaSalida <= fechaFinal &&
                                               item.Reserva.estado == true
                                         select item).ToList();

                    foreach (var item in listaReservas)
                    {
                        listaAmbientes.Remove(item.Ambiente);
                    }

                    foreach (var item in listaAmbientes)
                    {
                        AmbienteBE objAmbienteBE = new AmbienteBE()
                        {
                            Distrito = item.Hotel.Ubigeo.ubicacion,
                            Direccion = item.Hotel.direccion,
                            Piso = item.piso,
                            Identificador = item.identificador,
                            Precio = item.precio
                        };
                        lstAmbienteBE.Add(objAmbienteBE);
                    }

                    return lstAmbienteBE;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
