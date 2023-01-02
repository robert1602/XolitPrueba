using System.Collections.Generic;
using System.Linq;

namespace LogicaDeNegocio.Util.Validaciones
{
    public static class ValidacionGenerica
    {
        private const int SinRegistros = 0;

        public static bool PoseeRegistros<T>(IEnumerable<T> listaItemsValidacion)
        {
            int? cantidadRegistros = listaItemsValidacion?.Count();
            return (listaItemsValidacion != null && cantidadRegistros > SinRegistros);
        }

        public static bool NoEsNulo<T>(T itemValidacion) => (itemValidacion != null);
    }
}