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
        public IDbSet<IEntidade> Set<T>()
        {
            if (typeof(T) == typeof(Aluno))
            {
                return new DbSetAluno() as IDbSet<IEntidade>;
            }

            throw new Exception("Tipo não conhecido!");
        }
    }
}