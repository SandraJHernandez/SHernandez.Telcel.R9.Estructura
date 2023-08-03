using System;
using System.Collections.Generic;

namespace Telcel.R9.Estructura.AccesoDatos;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string? Nombre { get; set; }

    public int? PuestoId { get; set; }

    public int? DepartamentoId { get; set; }

    public virtual Departamento? Departamento { get; set; }

    public virtual Puesto? Puesto { get; set; }

    //Alias

    public string PuestoDescripcion { get; set; }
    public string DepartamentoDescripcion { get; set; }
}
