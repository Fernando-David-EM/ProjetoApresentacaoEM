using FirebirdSql.Data.FirebirdClient;
using ProjetoApresentacaoEM.EM.DbContext;
using ProjetoApresentacaoEM.EM.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.Repository
{
    abstract class RepositorioAbstrato<T> where T : IEntidade, new()
    {
        protected readonly Context _context = new Context();
        protected readonly DbSet<T> _table;

        protected RepositorioAbstrato()
        {
            _table = _context.Set<T>();
        }

        public void Add(T objeto)
        {
            _table.Add(objeto);
        }
        public void Update(T objeto)
        {
            _table.Update(objeto);
        }

        public void Remove(T objeto)
        {
            _table.Delete(objeto);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.GetAll();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().AsQueryable().Where(predicate);
        }
    }
}
