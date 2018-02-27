using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GEPV.Domain.Enum
{
    public class Enums
    {
        public static string GetDescription(System.Enum input)
        {
            Type type = input.GetType();
            MemberInfo[] memInfo = type.GetMember(input.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = (object[])memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return input.ToString();
        }

        public enum Situacao
        {
            [Description("Em Aberto")]
            EmAberto = 0,
            [Description("Reagendado")]
            Reagendado = 2,
            [Description("Realizou Compra")]
            RealizouCompra = 3,
            [Description("Não conseguiu contato")]
            NaoConseguiuContato = 4
        }
    }
}
