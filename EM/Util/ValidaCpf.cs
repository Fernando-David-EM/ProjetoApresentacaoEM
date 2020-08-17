using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.Util
{
    public static class ValidaCpf
    {
        public static bool EhCpf(string cpf)
        {
            string SoNumero = Regex.Replace(cpf, "[^0-9]", string.Empty);

            int[] d = new int[11];
            int[] v = new int[2];
            int j, i, soma;

            //verificando se todos os numeros são iguais
            if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return false;

            // se a quantidade de dígitos numérios for igual a 11
            // iremos verificar como CPF
            if (SoNumero.Length == 11)
            {
                for (i = 0; i <= 10; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                for (i = 0; i <= 1; i++)
                {
                    soma = 0;
                    for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

                    v[i] = (soma * 10) % 11;
                    if (v[i] == 10) v[i] = 0;
                }
                return (v[0] == d[9] & v[1] == d[10]);
            }
            // CPF inválido se
            // a quantidade de dígitos numérios for diferente de 11
            else return false;
        }

        public static string RemovePontuacaoCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return null;

            return Regex.Replace(cpf, "[^0-9]", string.Empty);
        }

        public static string AdicionaPontuacaoCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return null;

            var chars = cpf.ToCharArray();
            char[] cpfChars = new char[14];

            int k = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                if (i == 3 || i == 6)
                {
                    cpfChars[k] = '.';

                    k++;
                }
                if (i == 9)
                {
                    cpfChars[k] = '-';

                    k++;
                }

                cpfChars[k] = chars[i];

                k++;
            }

            return string.Concat(cpfChars);
        }
    }
}