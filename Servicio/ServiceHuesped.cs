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
