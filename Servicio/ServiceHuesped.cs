using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    public class ServiceHuesped : IServiceHuesped
    {
        public HuespedBE obtenerHuesped(String idTipoDoc,
                                        String numDoc)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    HuespedBE objHuespedBE = new HuespedBE();
                    var huesped = (from item in entity.Huesped
                                   where item.idTipoDoc == idTipoDoc &&
                                         item.numDoc == numDoc
                                   select item).FirstOrDefault();

                    objHuespedBE.Id = huesped.id;
                    objHuespedBE.Nombre = huesped.nombre;
                    objHuespedBE.Pais = huesped.Pais.ubicacion;

                    return objHuespedBE;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<HuespedReporteBE> contarHuespedesPorPais(DateTime fechaInicio,
                                                             DateTime fechaFinal)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<HuespedReporteBE> lstHuespedReporteBE = new List<HuespedReporteBE>();
                    var listaHuespedes = (from item in entity.ReservaHuesped
                                          where item.Reserva.fechaIngreso >= fechaInicio &&
                                                item.Reserva.fechaSalida <= fechaFinal
                                          group item by item.Huesped.Pais.ubicacion into huesped
                                          select huesped).ToList();

                    foreach (var item in listaHuespedes)
                    {
                        HuespedReporteBE objHuespedReporteBE = new HuespedReporteBE()
                        {
                            Pais = item.Key.ToString(),
                            Cantidad = item.Count()
                        };
                        lstHuespedReporteBE.Add(objHuespedReporteBE);
                    }

                    return lstHuespedReporteBE;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<HuespedBE> obtenerHuespedesPorPais(DateTime fechaInicio,
                                                       DateTime fechaFinal,
                                                       String idPais)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<HuespedBE> lstHuespedBE = new List<HuespedBE>();
                    var listaHuespedes = (from item in entity.ReservaHuesped
                                          where item.Reserva.fechaIngreso >= fechaInicio &&
                                                item.Reserva.fechaSalida <= fechaFinal &&
                                                item.Huesped.idPais == idPais
                                          select new
                                          {
                                              TipoDoc = item.Huesped.TipoDocumento.descripcion,
                                              NumDoc = item.Huesped.numDoc,
                                              Nombre = item.Huesped.nombre,
                                              Email = item.Huesped.email
                                          }).ToList();

                    foreach (var item in listaHuespedes)
                    {
                        HuespedBE objHuespedBE = new HuespedBE()
                        {
                            TipoDoc = item.TipoDoc,
                            NumDoc = item.NumDoc,
                            Nombre = item.Nombre,
                            Email = item.Email
                        };
                        lstHuespedBE.Add(objHuespedBE);
                    }

                    return lstHuespedBE;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Decimal obtenerDineroGastadoPorHuesped(DateTime fechaInicio,
                                                      DateTime fechaFinal,
                                                      String idTipoDoc,
                                                      String numDoc)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    Decimal total = 0;

                    List<ReservaBE> lstReservaBE = new List<ReservaBE>();
                    var lista = (from huesped in entity.ReservaHuesped
                                 join ambiente in entity.ReservaDetalle on huesped.idReserva equals ambiente.idReserva
                                 where huesped.Huesped.idTipoDoc == idTipoDoc &&
                                       huesped.Huesped.numDoc == numDoc &&
                                       huesped.Reserva.fechaIngreso >= fechaInicio &&
                                       huesped.Reserva.fechaSalida <= fechaFinal
                                 select new { monto = huesped.Reserva.monto }).ToList();

                    foreach (var item in lista)
                    {
                        total += item.monto;
                    };

                    return total;
                }
                catch (Exception ex)
                {
                    return 0;
                    throw ex;
                }
            }
        }

        public Boolean registrarHuesped(HuespedBE objHuespedBE)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    Huesped huesped = new Huesped()
                    {
                        idTipoDoc = objHuespedBE.IdTipoDoc,
                        numDoc = objHuespedBE.NumDoc,
                        nombre = objHuespedBE.Nombre,
                        email = objHuespedBE.Email,
                        telefono = objHuespedBE.Telefono,
                        idPais = objHuespedBE.IdPais,
                        estado = true
                    };

                    entity.Huesped.Add(huesped);
                    entity.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    throw ex;
                }
            }
        }
    }
}
