namespace Dominio.Dto.Titular
{
    public class CrearClienteDto
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumentoIdent { get; set; }
        public string Identificacion { get; set; }
        public int NroCuenta { get; set; }
        public int Saldoinicial{ get; set; }
    }
}
