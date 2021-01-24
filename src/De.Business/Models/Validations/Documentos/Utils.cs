using System;
using System.Collections.Generic;
using System.Text;

namespace De.Business.Models.Validations.Documentos
{
    public class Utils
    {
        public static string ApenasNumeros(string valor)
        {
            var onlyNumber = "";
            foreach(var s in valor)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}
