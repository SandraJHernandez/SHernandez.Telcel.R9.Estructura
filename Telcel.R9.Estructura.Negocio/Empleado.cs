using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telcel.R9.Estructura.Negocio
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public List<Object> Empleados { get; set; }
        public Telcel.R9.Estructura.Negocio.Puesto Puesto { get; set; } //Propiedad de navegacion
        public Telcel.R9.Estructura.Negocio.Departamento Departamento { get; set; } //propiedad de navegacion

        public static Telcel.R9.Estructura.Negocio.Result GetAll()
        {
            Telcel.R9.Estructura.Negocio.Result result = new Telcel.R9.Estructura.Negocio.Result();

            try
            {
                using(Telcel.R9.Estructura.AccesoDatos.ShernandezEstructuraContext context = new Telcel.R9.Estructura.AccesoDatos.ShernandezEstructuraContext())
                {
                    var query = context.Empleados.FromSqlRaw($"EmpleadoGetAll").ToList();

                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var obj in query)
                        {
                            Telcel.R9.Estructura.Negocio.Empleado empleado = new Telcel.R9.Estructura.Negocio.Empleado();

                            empleado.EmpleadoID = obj.EmpleadoId;
                            empleado.Nombre = obj.Nombre;
                            empleado.Puesto = new Telcel.R9.Estructura.Negocio.Puesto();
                            empleado.Puesto.PuestoID = obj.PuestoId.Value;
                            empleado.Puesto.Descripcion = obj.PuestoDescripcion;
                            empleado.Departamento = new Telcel.R9.Estructura.Negocio.Departamento();
                            empleado.Departamento.DepartamentoID = obj.DepartamentoId.Value;
                            empleado.Departamento.Descripcion = obj.DepartamentoDescripcion;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "ERROR" + ex.Message;
            }
            return result;
        }

        public static Telcel.R9.Estructura.Negocio.Result Add(Telcel.R9.Estructura.Negocio.Empleado empleado)
        {
            Telcel.R9.Estructura.Negocio.Result result = new Telcel.R9.Estructura.Negocio.Result();

            try
            {
                using(Telcel.R9.Estructura.AccesoDatos.ShernandezEstructuraContext context = new Telcel.R9.Estructura.AccesoDatos.ShernandezEstructuraContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"EmpleadoAdd '{empleado.Nombre}', {empleado.Puesto.PuestoID}, {empleado.Departamento.DepartamentoID}");

                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.Ex = ex;
                result.Message = "ERROR " + ex.Message;
            }
            return result;
        }

        public static Telcel.R9.Estructura.Negocio.Result Delete(int empleadoID)
        {
            Telcel.R9.Estructura.Negocio.Result result = new Telcel.R9.Estructura.Negocio.Result();

            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.ShernandezEstructuraContext context = new Telcel.R9.Estructura.AccesoDatos.ShernandezEstructuraContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"EmpleadoDelete {empleadoID}");

                    if(query >= 1)
                    {
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
