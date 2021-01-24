using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace De.Business.Models.Validations.Documentos
{
    public class CnpjValidacao
    {
        public const int TamanhoCnpj = 14;

        public static bool Validar(string cpf)
        {
            var cnpjNumeros = Utils.ApenasNumeros(cpf);

            if (!TamanhoValido(cnpjNumeros)) return false;
            return !TemDigitosRepetidos(cnpjNumeros) && TemDigitosValidos(cnpjNumeros);
        }

        private static bool TamanhoValido(string valor)
        {
            return valor.Length == TamanhoCnpj;
        }

        private static bool TemDigitosRepetidos(string valor)
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
            return invalidNumbers.Contains(valor);
            ;
        }

        private static bool TemDigitosValidos(string valor)
        {
            var number = valor.Substring(0, TamanhoCnpj - 2);
            var digitoVerificador = new DigitoVerificador(number).ComMultiplicadoresDeAte(2, 9).Substituido("0", 10, 11);
            var firstDigit = digitoVerificador.CalcularDigito();
            digitoVerificador.AddDigito(firstDigit);
            var secondDigit = digitoVerificador.CalcularDigito();

            return string.Concat(firstDigit, secondDigit) == valor.Substring(TamanhoCnpj - 2, 2);
        }
    }
}
