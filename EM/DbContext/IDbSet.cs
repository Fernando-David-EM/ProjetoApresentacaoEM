using ProjetoApresentacaoEM.EM.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.DbContext
{
    interface IDbSet<T> : IEnumerable<T> where T : IEntidade
    {
        void Add(T objeto);
        void Update(T objeto);
        void Delete(T objeto);
        IEnumerable<T> GetAll();
    }
}
