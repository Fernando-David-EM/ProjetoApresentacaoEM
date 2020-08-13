using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.Util
{
    class Formata
    {
        public static string RemovePontuacaoCpf(string cpf)
        {
            return Regex.Replace(cpf, "[^0-9]", string.Empty);
        }

        public static string AdicionaPontuacaoCpf(string cpf)
        {
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
