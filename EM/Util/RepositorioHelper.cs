namespace ProjetoApresentacaoEM.EM.Repository
{
    class RepositorioHelper
    {
        public static string RecebeSetDoObjeto(string colunasDaTabela, object objeto)
        {
            var colunas = colunasDaTabela
                .Trim('$', '(', ')')
                .Split(',');

            var valores = objeto
                .ToString()
                .Trim('(', ')')
                .Split(',');

            string set = "";

            for (int i = 0; i < colunas.Length; i++)
            {
                set += $"{colunas[i]}={valores[i]},";
            }

            set = set.Remove(set.Length - 1);

            return set;
        }
    }
}