using Dominio.Enumeradores;
using System.Text.RegularExpressions;

namespace Dominio.Aplicacion.Implementacion
{
    public static class ValidacionTextos
    {
        public static string ValidarCorreo(string correoElectronico)
        {
            string expresionRegular = EnumValor.GetStringValue(ExpresionesRegulares.ValidacionesTipoCampo.CorreoElectronico);
            Regex FuncionExpresionRegular = new Regex(expresionRegular);
            bool esCorreoEletronico = FuncionExpresionRegular.IsMatch(correoElectronico);
            string mensajeCorreoElectronico = esCorreoEletronico ? string.Empty : EnumValor.GetStringValue(MensajesValidaciones.MensajesCampos.FormatoCorreoElectronicoInvalido);
            return mensajeCorreoElectronico;
        }
    }
}
