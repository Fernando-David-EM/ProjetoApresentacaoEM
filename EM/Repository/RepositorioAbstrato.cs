using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.Repository
{
    abstract class RepositorioAbstrato<T> where T : IEntidade
    {
        protected string _nomeDaTabela;
        protected string _colunasDaTabela;

        public void Add(T objeto)
        {
            using var connection = DataBase.Conecte();
            using var command = new FbCommand($"INSERT INTO {_nomeDaTabela} {_colunasDaTabela} VALUES {objeto};", connection);

            var result = command.ExecuteNonQuery();
            if (result == 0)
            {
                throw new Exception("Erro!");
            }
        }
    }
}
