using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdenCompra.Models;
using OrdenCompra.Services;

namespace OrdenCompra.Controllers
{
    [Route("ejercicio/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private ArticuloService articuloService = new ArticuloService();

        [HttpGet]
        public ActionResult<IEnumerable<Articulo>> listar()
        {
            return Ok(articuloService.listarTodos());
        }

        [HttpGet("{codigo}")]
        public ActionResult<Articulo> obtenerArticulo(String codigo)
        {
            return Ok(articuloService.obtenerEntidad(codigo));
        }

        [HttpPost]
        public ActionResult<Articulo> guardar([FromBody] Articulo articulo)
        {
            return Ok(articuloService.insertar(articulo));
        }

        [HttpPut]
        public ActionResult<Articulo> actualizar([FromBody] Articulo articulo)
        {
            return Ok(articuloService.modificar(articulo));
        }

        [HttpDelete("{codigo}")]
        public void eliminar(String codigo)
        {
            articuloService.eliminarEntidad(codigo);
        }
    }
}
