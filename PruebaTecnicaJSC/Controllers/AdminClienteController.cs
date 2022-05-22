using Business.Business.AdminArboles;
using Business.Business.AdminClientes;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PruebaTecnicaJSC.Controllers
{
    public class AdminClienteController : Controller
    {
        private readonly IAdminClientesBusiness _business;
        private readonly IAdminArbolesBusiness _arbolesBusiness;

        public AdminClienteController(IAdminClientesBusiness business, IAdminArbolesBusiness arbolesBusiness)
        {
            _business = business;
            _arbolesBusiness = arbolesBusiness;
        }

        public async Task<IActionResult> CrearEditarCliente(int idCliente)
        {
            Cliente modelo = new Cliente();

            if (idCliente > default(int))
            {
                modelo = await _business.ConsultarClienteId(idCliente);
            }

            ViewBag.TiposIdentificacion = GenerarListaTiposIdentificacion(await _arbolesBusiness.ConsultarListaTiposIdentificacion(),modelo.TipoIdentificacion);

            ViewBag.CodigosPaises = GenerarListaPaises(await _arbolesBusiness.ConsultarListaPaises(),modelo.PaisCodigo);

            if (modelo !=null)
            {
                ViewBag.CodigosDepartamento = GenerarListaDepartamentos(await _arbolesBusiness.ConsultarListaDepartamentos(modelo.PaisCodigo), modelo.DepartamentoCodigo);

                ViewBag.CodigosMunicipio = GenerarListaDivisiones(await _arbolesBusiness.ConsultarListaDivisiones(modelo.DepartamentoCodigo), modelo.MunicipioCodigo);
            }

            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> CrearEditarCliente(Cliente modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            await _business.ActualizarCrearCliente(modelo);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> ConsultarDepartamentos(int idPais) 
        {
            var departamentos = await _arbolesBusiness.ConsultarListaDepartamentos(idPais);

            return Json(departamentos);
        }

        public async Task<IActionResult> ConsultarDivisiones(int idDepartamento)
        {
            var divisiones = await _arbolesBusiness.ConsultarListaDivisiones(idDepartamento);

            return Json(divisiones);
        }

        private List<SelectListItem> GenerarListaTiposIdentificacion(IEnumerable<TipoIdentificacion> listaTipos, int idSeleccionado)
        {
            var lista = new List<SelectListItem>();

            lista.AddRange(listaTipos.Select(x => new SelectListItem
            {
                Text = x.TipoIdnNombre,
                Value = x.TipoIdnId.ToString()
            }));

            if (idSeleccionado != default(int))
            {
                lista.FirstOrDefault(x => x.Value == idSeleccionado.ToString()).Selected = true;
            }

            return lista;
        }

        private List<SelectListItem> GenerarListaPaises(IEnumerable<ArbolPais> listaPaises, int idSeleccionado)
        {
            var lista = new List<SelectListItem>();

            lista.AddRange(listaPaises.Select(x => new SelectListItem
            {
                Text = x.PaisNombre,
                Value = x.Id.ToString()
            }));

            if (idSeleccionado > default(int))
            {
                lista.FirstOrDefault(x => x.Value == idSeleccionado.ToString()).Selected = true;
            }

            return lista;
        }

        private List<SelectListItem> GenerarListaDepartamentos(IEnumerable<ArbolDepartamento> listaDepartamento, int idSeleccionado)
        {
            var lista = new List<SelectListItem>();

            lista.AddRange(listaDepartamento.Select(x => new SelectListItem
            {
                Text = x.DptColNombredelDepartamento,
                Value = x.DptColCodigoDane.ToString()
            }));

            if (idSeleccionado > default(int))
            {
                lista.FirstOrDefault(x => x.Value == idSeleccionado.ToString()).Selected = true;
            }

            return lista;
        }

        private List<SelectListItem> GenerarListaDivisiones(IEnumerable<ArbolDivision> listaDivision, int idSeleccionado)
        {
            var lista = new List<SelectListItem>();

            lista.AddRange(listaDivision.Select(x => new SelectListItem
            {
                Text = x.DvsPltColNombreMunicipio,
                Value = x.DvsPltColCodigoDane.ToString()
            }));

            if (idSeleccionado > default(int))
            {
                lista.FirstOrDefault(x => x.Value == idSeleccionado.ToString()).Selected = true;
            }

            return lista;
        }

    }
}
