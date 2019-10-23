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
                                       huesped.Huesped.numDoc == numDoc
                                 select new { monto = huesped.Reserva.monto }).ToList();

                    foreach (var item in lista)
                    {
                        total += item.monto;
                    };

                    return total;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Boolean registrarHuesped(HuespedBE objHuespedBE)
        {
            using(HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    Huesped huesped = new Huesped()
                    {
                        idTipoDoc = objHuespedBE.IdTipoDoc,
                        numDoc = objHuespedBE.NumDoc,
                        nombre = objHuespedBE.Nombre,
                        email = objHuespedBE.Email,
                        telefono = objHuespedBE.Email,
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
