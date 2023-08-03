using Microsoft.AspNetCore.Mvc;

namespace Telcel.R9.Estructura.Presentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            Telcel.R9.Estructura.Negocio.Empleado empleado = new Telcel.R9.Estructura.Negocio.Empleado();
            Telcel.R9.Estructura.Negocio.Result result = Telcel.R9.Estructura.Negocio.Empleado.GetAll();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                ViewBag.Message = result.Message;
                return View(empleado);
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            Telcel.R9.Estructura.Negocio.Result resultPuestos = Telcel.R9.Estructura.Negocio.Puesto.GetAll();
            Telcel.R9.Estructura.Negocio.Result resultDepartamentos = Telcel.R9.Estructura.Negocio.Departamento.GetAll();

            Telcel.R9.Estructura.Negocio.Empleado empleado = new Telcel.R9.Estructura.Negocio.Empleado();
            empleado.Puesto = new Telcel.R9.Estructura.Negocio.Puesto();
            empleado.Departamento = new Telcel.R9.Estructura.Negocio.Departamento();

            empleado.Puesto.Puestos = resultPuestos.Objects;
            empleado.Departamento.Departamentos = resultDepartamentos.Objects;
           
            return View(empleado);
        }

        [HttpPost]
        public ActionResult Add(Telcel.R9.Estructura.Negocio.Empleado empleado)
        {
            Telcel.R9.Estructura.Negocio.Result result = Telcel.R9.Estructura.Negocio.Empleado.Add(empleado);

            if (result.Correct)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(empleado);
            }
        }

        [HttpGet]
        public ActionResult Delete(int empleadoID)
        {
            Telcel.R9.Estructura.Negocio.Empleado empleado = new Telcel.R9.Estructura.Negocio.Empleado();
            Telcel.R9.Estructura.Negocio.Result result = Telcel.R9.Estructura.Negocio.Empleado.Delete(empleadoID);

            if (result.Correct)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(empleado);
            }
        }
    }
}
