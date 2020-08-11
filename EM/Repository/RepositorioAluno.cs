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
        }

        public Aluno GetByMatricula(int matricula)
        {
            using var connection = DataBase.Conecte();
            using var command = new FbCommand($"SELECT * FROM {_nomeDaTabela} WHERE alu_matricula = {matricula};", connection);
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Aluno
                {
                    Matricula = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    CPF = reader.GetString(2),
                    Nascimento = reader.GetDateTime(3),
                    Sexo = (EnumeradorSexo)reader.GetInt32(4)
                };
            }
            else
            {
                return null;
            }
        }
    }
}
