using FirebirdSql.Data.FirebirdClient;
using ProjetoApresentacaoEM.EM.Domain;
using ProjetoApresentacaoEM.EM.Repository;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.DbContext
{
    class DbSet<T> : IDbSet<T> where T : IEntidade, new()
    {
        protected List<T> _entidades;
        protected Type _tipoDaEntidade;
        protected List<string> _nomesDePropriedadesDaEntidade;
        protected string _nomeDeColunasDaEntidade;
        protected string _nomeDaEntidade;

        public DbSet()
        {
            _entidades = new List<T>();
            _tipoDaEntidade = typeof(T);
            _nomeDaEntidade = _tipoDaEntidade.Name;
            _nomesDePropriedadesDaEntidade = _tipoDaEntidade.GetProperties().Select(p => p.Name).ToList();
            _nomeDeColunasDaEntidade = string.Join(",", _nomesDePropriedadesDaEntidade);

            PreencheListaDeEntidades();
        }

        private void PreencheListaDeEntidades()
        {
            using var connection = DataBase.AbreConexao();
            using var command = new FbCommand($"SELECT * FROM {_nomeDaEntidade}", connection);

            using var reader = command.ExecuteReader();

            _entidades.Clear();

            while (reader.Read())
            {
                var obj = CriaObjetoEntidade(reader);

                _entidades.Add(obj);
            }
        }

        private T CriaObjetoEntidade(FbDataReader reader)
        {
            var obj = new T();

            var propriedades = _tipoDaEntidade.GetProperties();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string fieldName = reader.GetName(i);
                var propriedade = propriedades.FirstOrDefault(x => x.Name.ToLower() == fieldName.ToLower());

                if (propriedade != null)
                {
                    if (reader[i] != DBNull.Value)
                    {
                        var value = ConverteSeNecessario(reader[i], propriedade.PropertyType);

                        propriedade.SetValue(obj, value, null);
                    }
                }
            }

            return obj;
        }

        private object ConverteSeNecessario(object objeto, Type tipoDaPropriedade)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(objeto.GetType());
            if (converter.CanConvertTo(tipoDaPropriedade))
                return converter.ConvertTo(objeto, tipoDaPropriedade);
            else
                return objeto;
        }

        public void Add(T objeto)
        {
            using var connection = DataBase.AbreConexao();
            using var command = new FbCommand($"INSERT INTO {_nomeDaEntidade} ({_nomeDeColunasDaEntidade}) VALUES {objeto}", connection);

            command.ExecuteNonQuery();
        }

        public void Delete(T objeto)
        {
            PropertyInfo property = _tipoDaEntidade.GetProperty(_nomesDePropriedadesDaEntidade[0]);
            var chavePrimaria = property.GetValue(objeto, null);

            using var connection = DataBase.AbreConexao();
            using var command = new FbCommand($"DELETE FROM {_nomeDaEntidade} WHERE {_nomesDePropriedadesDaEntidade[0]} = {chavePrimaria}", connection);

            var reader = command.ExecuteNonQuery();

            if (reader == 0)
            {
                throw new Exception("Objeto não existe, portanto não pode ser deletado");
            }
        }

        public IEnumerable<T> GetAll()
        {
            PreencheListaDeEntidades();

            return _entidades;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _entidades.GetEnumerator();
        }

        public void Update(T objeto)
        {
            PropertyInfo property = _tipoDaEntidade.GetProperty(_nomesDePropriedadesDaEntidade[0]);
            var chavePrimaria = property.GetValue(objeto, null);

            using var connection = DataBase.AbreConexao();
            using var command = new FbCommand($"UPDATE {_nomeDaEntidade} SET {CriaStringColunaIgualValor(objeto)} WHERE {_nomesDePropriedadesDaEntidade[0]} = {chavePrimaria}", connection);

            command.ExecuteNonQuery();
        }

        private string CriaStringColunaIgualValor(T objeto)
        {
            var colunas = _nomeDeColunasDaEntidade
                .Split(',');

            var valores = objeto
                .ToString()
                .Trim('(', ')')
                .Split(',');

            var colunaIgualValor = "";

            for (int i = 0; i < colunas.Length; i++)
            {
                colunaIgualValor += $"{colunas[i]}={valores[i]},";
            }

            colunaIgualValor = colunaIgualValor.Remove(colunaIgualValor.Length - 1);

            return colunaIgualValor;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
