using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioAmbiente" en el código y en el archivo de configuración a la vez.
    public class ServicioAmbiente : IServicioAmbiente
    {
        public List<AmbienteBE> obtenerHabitacionesDisponibles()
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<AmbienteBE> lstAmbienteBE = new List<AmbienteBE>();
                    var listaAmbientes = (from item in entity.Ambiente
                                          where item.estado == true
                                          select item).ToList();
                    var listaAmbienteOcupado = (from item in entity.ReservaDetalle
                                                where item.estado == true
                                                select item.Ambiente).Distinct().ToList();

                    foreach (var ocupado in listaAmbienteOcupado)
                    {
                        listaAmbientes.Remove(ocupado);
                    }

                    foreach (var item in listaAmbientes)
                    {
                        AmbienteBE ambienteBE = new AmbienteBE()
                        {
                            direccion = item.Hotel.direccion,
                            identificador = item.identificador,
                            piso = item.piso,
                            precio = item.precio
                        };
                        lstAmbienteBE.Add(ambienteBE);
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
