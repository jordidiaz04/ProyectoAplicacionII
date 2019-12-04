using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio
{
    public class ServiceUbigeo : IServiceUbigeo
    {
        public List<PaisBE> obtenerPaises()
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<PaisBE> lstPaisBE = new List<PaisBE>();
                    var paises = (from item in entity.Pais
                                  select item).ToList();
                    foreach (var item in paises)
                    {
                        PaisBE paisBE = new PaisBE()
                        {
                            IdPais = item.id,
                            Pais = item.ubicacion
                        };
                        lstPaisBE.Add(paisBE);
                    }

                    return lstPaisBE;
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }

        public List<DepartamentoBE> obtenerDepartamentos()
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<DepartamentoBE> lstDepartamentoBE = new List<DepartamentoBE>();
                    var departamentos = (from item in entity.Ubigeo
                                         where item.departamento != "00" && item.provincia == "00" && item.distrito == "00"
                                         select item).ToList();
                    foreach (var item in departamentos)
                    {
                        DepartamentoBE departamentoBE = new DepartamentoBE()
                        {
                            IdDepartamento = item.departamento,
                            Departamento = item.ubicacion
                        };
                        lstDepartamentoBE.Add(departamentoBE);
                    }

                    return lstDepartamentoBE;
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }

        public List<ProvinciaBE> obtenerProvincias(String idDepartamento)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<ProvinciaBE> lstProvinciaBE = new List<ProvinciaBE>();
                    var provincias = (from item in entity.Ubigeo
                                      where item.departamento == idDepartamento && item.provincia != "00" && item.distrito == "00"
                                      select item).ToList();
                    foreach (var item in provincias)
                    {
                        ProvinciaBE provinciaBE = new ProvinciaBE()
                        {
                            IdProvincia = item.provincia,
                            Provincia = item.ubicacion
                        };
                        lstProvinciaBE.Add(provinciaBE);
                    }

                    return lstProvinciaBE;
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }

        public List<DistritoBE> obtenerDistritos(String idDepartamento,
                                                 String idProvincia)
        {
            using (HospedajeEntities entity = new HospedajeEntities())
            {
                try
                {
                    List<DistritoBE> lstDistritoBE = new List<DistritoBE>();
                    var distritos = (from item in entity.Ubigeo
                                     where item.departamento == idDepartamento && item.provincia == idProvincia && item.distrito != "00"
                                     select item).ToList();
                    foreach (var item in distritos)
                    {
                        DistritoBE distritoBE = new DistritoBE()
                        {
                            IdDistrito = item.distrito,
                            Distrito = item.ubicacion
                        };
                        lstDistritoBE.Add(distritoBE);
                    }

                    return lstDistritoBE;
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }
        }
    }
}
