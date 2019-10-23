using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceAmbiente" en el código y en el archivo de configuración a la vez.
    public class ServiceAmbiente : IServiceAmbiente
    {
        public List<AmbienteBE> obtenerAmbienteDisponiblePorAforo(DateTime fechaInicio, DateTime fechaFinal, int aforoMenor, int aforoMayor)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<AmbienteBE> lstAmbienteBE = new List<AmbienteBE>();
                    var listaAmbientes = (from item in entity.Ambiente
                                          where item.aforo >= aforoMenor &&
                                                item.aforo <= aforoMayor &&
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
                            direccion = item.Hotel.direccion,
                            identificador = item.identificador,
                            piso = item.piso,
                            aforo = item.aforo,
                            precio = item.precio
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

        public List<AmbienteBE> obtenerAmbienteDisponiblePorFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<AmbienteBE> lstAmbienteBE = new List<AmbienteBE>();
                    var listaAmbientes = (from item in entity.Ambiente
                                          where item.estado == true
                                          select item).ToList();

                    var listaReservas = (from item in entity.ReservaDetalle
                                         where item.Reserva.fechaIngreso >= fechaInicio && item.Reserva.fechaSalida <= fechaFinal && item.Reserva.estado == true
                                         select item).ToList();

                    foreach (var item in listaReservas)
                    {
                        listaAmbientes.Remove(item.Ambiente);
                    }

                    foreach (var item in listaAmbientes)
                    {
                        AmbienteBE objAmbienteBE = new AmbienteBE()
                        {
                            direccion = item.Hotel.direccion,
                            identificador = item.identificador,
                            piso = item.piso,
                            precio = item.precio
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

        public List<AmbienteBE> obtenerAmbienteDisponiblePorRangoDePrecios(DateTime fechaInicio, DateTime fechaFinal, Decimal precioMenor, Decimal precioMayor)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<AmbienteBE> lstAmbienteBE = new List<AmbienteBE>();
                    var listaAmbientes = (from item in entity.Ambiente
                                          where item.precio >= precioMenor &&
                                                item.precio <= precioMayor &&
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
                            direccion = item.Hotel.direccion,
                            identificador = item.identificador,
                            piso = item.piso,
                            precio = item.precio
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
