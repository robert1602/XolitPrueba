using Dominio.Dto.Sistema;
using System;
using System.Reflection;

namespace Dominio.Aplicacion.Implementacion
{
    public static class EnumValor
    {
        public static string GetStringValue(this Enum value)
        {
            Type TipoValor = value.GetType();
            FieldInfo CampoInformacion = TipoValor.GetField(value.ToString());
            StringValueAttribute[] attribs = CampoInformacion.GetCustomAttributes(
            typeof(StringValueAttribute), false) as StringValueAttribute[];
            
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }
}
