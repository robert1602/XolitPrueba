using Microsoft.AspNetCore.Mvc;
using LogicaDeNegocio.ServicioNegocio.Interface;
using System.Threading.Tasks;
using Dominio.Dto.Titular;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers.V1
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IServicioNegocioTitular _servicioNegocioTitular;

        public ClienteController(IServicioNegocioTitular servicioNegocioTitular)
        {
            this._servicioNegocioTitular = servicioNegocioTitular;
        }

        [HttpGet]
        [Route("obtener-datos-cliente")]
        public async Task<IActionResult> ObtenerDatosCliente(int idCliente)
        {
            return Ok(await this._servicioNegocioTitular.ObtenerDatosClientePorId(idCliente));
        }

        [HttpPost]
        [Route("crear-cliente")]
        public async Task<IActionResult> CrearCliente([FromBody] CrearClienteDto clienteCreacion)
        {
            return Ok(await this._servicioNegocioTitular.CrearCliente(clienteCreacion));
        }

        [HttpPut]
        [Route("actualizar-cliente")]
        public async Task<IActionResult> ActualizarEjemplo([FromBody] ActualizarClienteDto datosActualizacion)
        {
            return Ok(await this._servicioNegocioTitular.ActualizarClienteDto(datosActualizacion));
        }
    }
}