using System.Text.Json.Serialization;

namespace Dominio.Dto.Ejemplo
{

    public class CrearEjemploDto
    {
        [JsonIgnore]
        public int MyProperty { get; set; }
        public int MyProperty2 { get; set; }
        public int MyProperty3 { get; set; }
    }
}