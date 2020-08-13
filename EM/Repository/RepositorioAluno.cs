using FirebirdSql.Data.FirebirdClient;
using ProjetoApresentacaoEM.EM.DbContext;
using ProjetoApresentacaoEM.EM.Domain;
using ProjetoApresentacaoEM.EM.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.Repository
{
    class RepositorioAluno : RepositorioAbstrato<Aluno>
    {
        public RepositorioAluno() : base()
        {

        }
        public Aluno GetByMatricula(int matricula)
        {
            return _table.GetAll().SingleOrDefault(a => a.Matricula == matricula);
        }

        public IEnumerable<Aluno> GetByConteudoNoNome(string parteDoNome)
        {
            return Get(x => x.Nome.ToUpper().Contains(parteDoNome.ToUpper()));
        }
    }
}
