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
        public RepositorioAluno() : base(new DbSetAluno())
        {

        }
        public Aluno GetByMatricula(int matricula)
        {
            using var connection = DataBase.AbreConexao();
            using var command = new FbCommand($"SELECT * FROM ALUNOS WHERE ALU_MATRICULA = {matricula};", connection);
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Aluno(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetDateTime(3),
                    (EnumeradorSexo)reader.GetInt32(4));
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Aluno> GetByConteudoNoNome(string parteDoNome)
        {
            return Get(x => x.Nome.ToUpper().Contains(parteDoNome.ToUpper()));
        }
    }
}
