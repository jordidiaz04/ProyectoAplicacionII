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
        public List<ReservaBE> listarReservasPorHuesped(string dni)
        {
            using(HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<ReservaBE> lstReservaBE = new List<ReservaBE>();
                    var lista = (from huesped in entity.ReservaHuesped
                                 join ambiente in entity.ReservaDetalle on huesped.idReserva equals ambiente.idReserva
                                 where huesped.Huesped.numDoc == dni
                                 select new
                                 {
                                     dni = huesped.Huesped.numDoc,
                                     huesped = huesped.Huesped.nombre,
                                     fechaInicio = huesped.Reserva.fechaIngreso,
                                     fechaSalida = huesped.Reserva.fechaSalida,
                                     direccion = ambiente.Ambiente.Hotel.direccion,
                                     piso = ambiente.Ambiente.piso,
                                     identificador = ambiente.Ambiente.identificador
                                 }).ToList();

                    foreach(var item in lista)
                    {
                        ReservaBE objReservaBE = new ReservaBE()
                        {
                            Dni = item.dni,
                            Huesped = item.huesped,
                            FechaInicio = item.fechaInicio,
                            FechaSalida = item.fechaSalida,
                            Direccion = item.direccion,
                            Piso = item.piso,
                            Identificador = item.identificador
                        };
                        lstReservaBE.Add(objReservaBE);
                    }

                    return lstReservaBE;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool registrarReserva(HuespedBE objHuespedBE, ReservaBE objReservaBE, ReservaDetalleBE objReservaDetalleBE, ReservaHuespedBE objReservaHuespedBE)
        {
            using(HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {

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
