using FirebirdSql.Data.FirebirdClient;
using ProjetoApresentacaoEM.EM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.Repository
{
    class RepositorioAluno : RepositorioAbstrato<Aluno>
    {
        public RepositorioAluno()
        {
            _colunasDaTabela = "(alu_matricula,alu_nome,alu_cpf,alu_nascimento,alu_sexo)";
            _nomeDaTabela = "alunos";
            _nomeDaColunaDeCondicao = "alu_matricula";
    }

        public Aluno GetByMatricula(int matricula)
        {
            using var connection = DataBase.Conecte();
            using var command = new FbCommand($"SELECT * FROM {_nomeDaTabela} WHERE ALU_MATRICULA = {matricula};", connection);
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
            return Get(x => x.Nome.Contains(parteDoNome));
        }

        protected override Aluno CrieObjeto(object[] campos)
        {
            var sexoInt = Convert.ToInt32(campos[4]);

            return new Aluno
            (
                (int)campos[0],
                (string)campos[1],
                (string)campos[2],
                (DateTime)campos[3],
                (EnumeradorSexo)sexoInt
            );
        }

        protected override void DetermineCondicao(Aluno objeto)
        {
            _condicao = objeto.Matricula.ToString();
        }
    }
}
