namespace Dominio.Dto.Titular
{
    public class FiltroBusquedaTitularDocumentoDto
    {
        public string NumeroDocumento { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdUsuario { get; set; }
    }
}