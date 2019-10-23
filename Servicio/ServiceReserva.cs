using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    public class ServiceReserva : IServiceReserva
    {
        public List<ReservaBE> listarReservasPorHuesped(String idTipoDoc, 
                                                        String numDoc,
                                                        DateTime fechaInicio,
                                                        DateTime fechaFinal)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<ReservaBE> lstReservaBE = new List<ReservaBE>();
                    var lista = (from huesped in entity.ReservaHuesped
                                 join ambiente in entity.ReservaDetalle on huesped.idReserva equals ambiente.idReserva
                                 where huesped.Huesped.idTipoDoc == idTipoDoc &&
                                       huesped.Huesped.numDoc == numDoc &&
                                       huesped.Reserva.fechaIngreso >= fechaInicio &&
                                       huesped.Reserva.fechaSalida <= fechaFinal
                                 select new
                                 {
                                     Dni = huesped.Huesped.numDoc,
                                     Huesped = huesped.Huesped.nombre,
                                     FechaInicio = huesped.Reserva.fechaIngreso,
                                     FechaSalida = huesped.Reserva.fechaSalida,
                                     Distrito = ambiente.Ambiente.Hotel.Ubigeo.ubicacion,
                                     Direccion = ambiente.Ambiente.Hotel.direccion,
                                     Piso = ambiente.Ambiente.piso,
                                     Identificador = ambiente.Ambiente.identificador,
                                     TipoPago = ambiente.Reserva.TipoPago.descripcion,
                                     Monto = huesped.Reserva.monto
                                 }).ToList();

                    foreach (var item in lista)
                    {
                        ReservaBE objReservaBE = new ReservaBE()
                        {
                            Dni = item.Dni,
                            Huesped = item.Huesped,
                            FechaInicio = item.FechaInicio,
                            FechaSalida = item.FechaSalida,
                            Distrito = item.Distrito,
                            Direccion = item.Direccion,
                            Piso = item.Piso,
                            Identificador = item.Identificador,
                            TipoPago = item.TipoPago,
                            Monto = item.Monto
                        };
                        lstReservaBE.Add(objReservaBE);
                    }

                    return lstReservaBE;
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }

        public bool registrarReserva(DateTime fechaIngreso,
                                     DateTime fechaSalida,
                                     Int32 idTipoPago,
                                     Decimal monto,
                                     List<Int32> lstIdsAmbiente,
                                     List<Int32> lstIdsHuesped)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    Reserva reserva = new Reserva()
                    {
                        fechaIngreso = fechaIngreso,
                        fechaSalida = fechaSalida,
                        idTipoPago = idTipoPago,
                        monto = monto,
                        estado = true
                    };
                    entity.Reserva.Add(reserva);
                    entity.SaveChanges();

                    for (int i = 0; i < lstIdsAmbiente.Count; i++)
                    {
                        ReservaDetalle reservaDetalle = new ReservaDetalle()
                        {
                            idReserva = reserva.id,
                            idAmbiente = lstIdsAmbiente[i],
                            estado = true
                        };
                        entity.ReservaDetalle.Add(reservaDetalle);
                        entity.SaveChanges();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
