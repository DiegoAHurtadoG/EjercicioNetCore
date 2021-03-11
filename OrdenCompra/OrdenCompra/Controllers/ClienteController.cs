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
    public class ClienteController : ControllerBase
    {
        private ClienteService clienteService = new ClienteService();

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> listar()
        {
            return Ok(clienteService.listarTodos());
        }

        [HttpGet("{idCliente}")]
        public ActionResult<Cliente> obtenerCliente(int idCliente)
        {
            return Ok(clienteService.obtenerEntidad(idCliente));
        }

        [HttpPost]
        public ActionResult<Cliente> guardar([FromBody] Cliente cliente)
        {
            return Ok(clienteService.insertar(cliente));
        }

        [HttpPut]
        public ActionResult<Cliente> actualizar([FromBody] Cliente cliente)
        {
            return Ok(clienteService.modificar(cliente));
        }

        [HttpDelete("{idCliente}")]
        public void eliminar(int idCliente)
        {
            clienteService.eliminarEntidad(idCliente);
        }
    }
}
