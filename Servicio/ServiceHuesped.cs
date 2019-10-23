using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceHuesped" en el código y en el archivo de configuración a la vez.
    public class ServiceHuesped : IServiceHuesped
    {

        public float contarDineroGastadoPorHuesped(String tipoDoc, String numeroDocumento)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    Decimal total = 0;
                    String idUsuario = (from item in entity.Huesped
                                          where item.idTipoDoc == tipoDoc &&
                                          item.numDoc == numeroDocumento
                                          select item.id).ToString();

                    List<ReservaBE> lstReservaBE = new List<ReservaBE>();
                    var lista = (from huesped in entity.ReservaHuesped
                                 join ambiente in entity.ReservaDetalle on huesped.idReserva equals ambiente.idReserva
                                 where huesped.Huesped.id == Convert.ToInt16(idUsuario)
                                 select new
                                 {
                                     dni = huesped.Huesped.numDoc,
                                     huesped = huesped.Huesped.nombre,
                                     fechaInicio = huesped.Reserva.fechaIngreso,
                                     fechaSalida = huesped.Reserva.fechaSalida,
                                     direccion = ambiente.Ambiente.Hotel.direccion,
                                     piso = ambiente.Ambiente.piso,
                                     identificador = ambiente.Ambiente.identificador,
                                     monto = huesped.Reserva.monto
                                 }).ToList();
                    foreach (var item in lista)
                    {
                        Decimal monto;
                        {
                            monto = item.monto;
                        };
                        total += monto;
                    };

                    return Convert.ToSingle(total);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<HuespedBE> contarHuespedesPorPais()
        {
            using(HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<HuespedBE> lstHuespedBE = new List<HuespedBE>();
                    var listaHuespedes = (from item in entity.ReservaHuesped
                                          group item by item.Huesped.Pais.ubicacion into huesped
                                          select huesped).ToList();

                    foreach (var item in listaHuespedes)
                    {
                        HuespedBE objHuespedBE = new HuespedBE()
                        {
                            Pais = item.Key.ToString(),
                            Cantidad = item.Count()
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
    }
}
