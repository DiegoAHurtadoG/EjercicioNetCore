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
    public class OrdenController : ControllerBase
    {
        private OrdenService ordenService = new OrdenService();

        [HttpGet]
        public ActionResult<IEnumerable<Orden>> listar()
        {
            return Ok(ordenService.listarTodos());
        }

        [HttpGet("{idOrden}")]
        public ActionResult<Orden> obtenerOrden(int idOrden)
        {
            return Ok(ordenService.obtenerEntidad(idOrden));
        }

        [HttpPost]
        public ActionResult<Orden> guardar([FromBody] Orden orden)
        {
            return Ok(ordenService.insertar(orden));
        }

        [HttpPut]
        public ActionResult<Orden> actualizar([FromBody] Orden orden)
        {
            return Ok(ordenService.modificar(orden));
        }

        [HttpDelete("{idOrden}")]
        public void eliminar(int idOrden)
        {
            ordenService.eliminarEntidad(idOrden);
        }
    }
}
