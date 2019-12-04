using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    public class ServiceTipoPago : IServiceTipoPago
    {
        public List<TipoPagoBE> obtenerTiposPago()
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<TipoPagoBE> lstTipoPagoBE = new List<TipoPagoBE>();
                    var listaTiposPago = (from item in entity.TipoPago
                                          select item).ToList();

                    foreach (var item in listaTiposPago)
                    {
                        TipoPagoBE objTipoPagoBE = new TipoPagoBE()
                        {
                            Id = item.id,
                            Descripcion = item.descripcion
                        };
                        lstTipoPagoBE.Add(objTipoPagoBE);
                    }

                    return lstTipoPagoBE;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
