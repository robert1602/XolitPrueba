using Dominio.Aplicacion.Implementacion;
using Xunit;

namespace DominioTest
{
    public class EncriptacionesTest
    {

        [Fact]
        public void ValidarCodificacionBase64Correcta()
        {
            //Arrange
            string PruebaBase64 = "Pruebas";
            string ResultadoBase64 = "UHJ1ZWJhcw==";
            //Act
            string ResultadoMetodo = Encriptaciones.CodificarBase64(PruebaBase64);
            bool ResultadoValidacion = (ResultadoMetodo == ResultadoBase64);
            //ASSert
            Assert.True(ResultadoValidacion);
        }
        
    }
}
