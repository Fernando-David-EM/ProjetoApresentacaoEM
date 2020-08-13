using FirebirdSql.Data.FirebirdClient;
using ProjetoApresentacaoEM.EM.Domain;
using ProjetoApresentacaoEM.EM.Repository;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.DbContext
{
    abstract class DbSet<T> : IDbSet<T> where T : IEntidade, new()
    {
        protected List<T> _entities = new List<T>();
        protected Type _entityType = typeof(T);
        protected List<string> _entityPropertyNames;
        protected string _entityColumns;
        protected string _entityName = typeof(T).GetType().Name;

        public DbSet()
        {
            _entityPropertyNames = typeof(T).GetProperties().Select(p => p.Name).ToList();
            _entityColumns = string.Join(",", _entityPropertyNames);

            FillList();
        }

        private void FillList()
        {
            using var connection = DataBase.AbreConexao();
            using var command = new FbCommand($"SELECT * FROM {_entityName}", connection);

            using var reader = command.ExecuteReader();

            _entities.Clear();

            var props = typeof(T).GetProperties();

            while (reader.Read())
            {
                var obj = new T();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string fieldName = reader.GetName(i);
                    var prop = props.FirstOrDefault(x => x.Name.ToLower() == fieldName.ToLower());
                    if (prop != null)
                    {
                        if (reader[i] != DBNull.Value)
                        {
                            prop.SetValue(obj, reader[i], null);
                        }
                    }
                }
                _entities.Add(obj);
            }
        }

        public void Add(T objeto)
        {
            using var connection = DataBase.AbreConexao();
            using var command = new FbCommand($"INSERT INTO {_entityName} ({_entityColumns}) VALUES {objeto}", connection);

            command.ExecuteNonQuery();
        }

        public void Delete(T objeto)
        {
            PropertyInfo property = _entityType.GetProperty(_entityPropertyNames[0]);
            var primaryKey = property.GetValue(objeto, null);

            using var connection = DataBase.AbreConexao();
            using var command = new FbCommand($"DELETE FROM {_entityName} WHERE {_entityPropertyNames[0]} = {primaryKey}", connection);

            var reader = command.ExecuteNonQuery();

            if (reader == 0)
            {
                throw new Exception("Objeto não existe, portanto não pode ser deletado");
            }
        }

        public IEnumerable<T> GetAll()
        {
            FillList();

            return _entities;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        public void Update(T objeto)
        {
            PropertyInfo property = _entityType.GetProperty(_entityPropertyNames[0]);
            var primaryKey = property.GetValue(objeto, null);

            using var connection = DataBase.AbreConexao();
            using var command = new FbCommand($"UPDATE {_entityName} SET {CreateUpdateSetStatement(objeto)} WHERE {_entityPropertyNames[0]} = {primaryKey}", connection);

            command.ExecuteNonQuery();
        }

        private string CreateUpdateSetStatement(T objeto)
        {
            var columns = _entityColumns
                .Split(',');

            var values = objeto
                .ToString()
                .Trim('(', ')')
                .Split(',');

            var updateSet = "";

            for (int i = 0; i < columns.Length; i++)
            {
                updateSet += $"{columns[i]}={values[i]},";
            }

            updateSet = updateSet.Remove(updateSet.Length - 1);

            return updateSet;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
