using ProjetoApresentacaoEM.EM.Domain;
using ProjetoApresentacaoEM.EM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.DbContext
{
    class Context
    {
        public DbSet<T> Set<T>() where T : IEntidade, new()
        {
            return new DbSet<T>();
        }
    }
}