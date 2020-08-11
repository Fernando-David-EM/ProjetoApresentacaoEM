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
        protected string _nomeDaColunaDeCondicao;
        protected string _condicao;

        public void Add(T objeto)
        {
            using var connection = DataBase.Conecte();
            using var command = new FbCommand($"INSERT INTO {_nomeDaTabela} {_colunasDaTabela} VALUES {objeto}", connection);

            command.ExecuteNonQuery();
        }
        public void Update(T objeto)
        {
            DetermineCondicao(objeto);

            using var connection = DataBase.Conecte();
            using var command = new FbCommand($"UPDATE {_nomeDaTabela} SET {RepositorioHelper.RecebeSetDoObjeto(_colunasDaTabela, objeto)} WHERE {_nomeDaColunaDeCondicao} = {_condicao}", connection);

            command.ExecuteNonQuery();
        }

        public void Remove(T objeto)
        {
            DetermineCondicao(objeto);

            using var connection = DataBase.Conecte();
            using var command = new FbCommand($"DELETE FROM {_nomeDaTabela} WHERE {_nomeDaColunaDeCondicao} = {_condicao}", connection);

            var result = command.ExecuteNonQuery();
            if (result == 0)
            {
                throw new Exception("Objeto não existe, portanto não pode ser deletado");
            }
        }

        protected abstract void DetermineCondicao(T objeto);
    }
}
