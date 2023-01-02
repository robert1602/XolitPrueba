namespace Dominio.Dto.Ejemplo
{
    public class EjemploResumenSumatoriaDto
    {
        public decimal Capital { get; set; }
        public decimal Intereses { get; set; }
        public decimal Total { get { return this.Capital + this.Intereses; } }
    }
}