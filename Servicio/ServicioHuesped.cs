using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    public class ServicioHuesped : IServicioHuesped
    {
        public List<HuespedBE> contarHuespedPorPais()
        {
            using(HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<HuespedBE> lstHuespedBE = new List<HuespedBE>();
                    var listaHuespedes = (from item in entity.ReservaHuesped                                          
                                          select item.Huesped).Distinct().ToList();

                    var lista = (from item in listaHuespedes
                                 group item by item.Pais.ubicacion into newItem
                                 select newItem).ToList();

                    foreach (var item in lista)
                    {
                        HuespedBE huespedBE = new HuespedBE()
                        {
                            pais = item.Key.ToString(),
                            cantidad = item.Count()
                        };
                        lstHuespedBE.Add(huespedBE);
                    }

                    return lstHuespedBE;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
