using Microsoft.AspNetCore.Mvc;
using LogicaDeNegocio.ServicioNegocio.Interface;
using System.Threading.Tasks;
using Dominio.Dto.Titular;

namespace Api.Controllers.V1
{
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
        [Route("datos-cliente")]
        public async Task<IActionResult> ObtenerDatosCliente(int idTitular)
        {
            return Ok(await this._servicioNegocioTitular.ObtenerDatosClientePorId(idTitular));
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