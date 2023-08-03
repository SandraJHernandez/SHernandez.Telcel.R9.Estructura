using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telcel.R9.Estructura.Negocio
{
    public class Puesto
    {
        public int PuestoID { get; set; }
        public string Descripcion { get; set; }
        public List<Object> Puestos { get; set; }

        public static Telcel.R9.Estructura.Negocio.Result GetAll()
        {
            Telcel.R9.Estructura.Negocio.Result result = new Telcel.R9.Estructura.Negocio.Result();

            try
            {
                using(Telcel.R9.Estructura.AccesoDatos.ShernandezEstructuraContext context = new Telcel.R9.Estructura.AccesoDatos.ShernandezEstructuraContext())
                {
                    var query = context.Puestos.FromSqlRaw($"PuestoGetAll").ToList();

                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            Telcel.R9.Estructura.Negocio.Puesto puesto = new Telcel.R9.Estructura.Negocio.Puesto();

                            puesto.PuestoID = obj.PuestoId;
                            puesto.Descripcion = obj.Descripcion;

                            result.Objects.Add(puesto);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "ERROR " + ex.Message;
            }
            return result;
        }
    }
}
