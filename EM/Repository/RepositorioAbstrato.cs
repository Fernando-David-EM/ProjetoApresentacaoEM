using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
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

            var reader = command.ExecuteNonQuery();
            if (reader == 0)
            {
                throw new Exception("Objeto não existe, portanto não pode ser deletado");
            }
        }

        public IEnumerable<T> GetAll()
        {
            using var connection = DataBase.Conecte();
            using var command = new FbCommand($"SELECT * FROM {_nomeDaTabela}", connection);

            var reader = command.ExecuteReader();

            var objects = new List<T>();

            while (reader.Read())
            {
                var colunas = GerePropriedadesParaConstrutor(reader);

                objects.Add(CrieObjeto(colunas));
            }

            return objects;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().AsQueryable().Where(predicate);
        }

        private object[] GerePropriedadesParaConstrutor(FbDataReader reader)
        {
            var colunas = new object[reader.FieldCount];
            reader.GetValues(colunas);

            return colunas;
        }

        protected abstract void DetermineCondicao(T objeto);
        protected abstract T CrieObjeto(object[] campos);
    }
}
