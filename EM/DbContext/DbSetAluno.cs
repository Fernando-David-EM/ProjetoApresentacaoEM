using FirebirdSql.Data.FirebirdClient;
using ProjetoApresentacaoEM.EM.Domain;
using ProjetoApresentacaoEM.EM.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.DbContext
{
    class DbSetAluno : IDbSet<Aluno>
    {
        private List<Aluno> alunos = new List<Aluno>();
        private readonly string _colunas = "(ALU_MATRICULA,ALU_NOME,ALU_CPF,ALU_NASCIMENTO,ALU_SEXO)";

        private void FillList()
        {
            using var connection = DataBase.AbreConexao();
            using var command = new FbCommand($"SELECT * FROM ALUNOS", connection);

            using var reader = command.ExecuteReader();

            alunos.Clear();

            while (reader.Read())
            {
                alunos.Add(new Aluno(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetDateTime(3),
                    (EnumeradorSexo)reader.GetInt32(4)));
            }
        }

        public IEnumerator<Aluno> GetEnumerator()
        {
            return alunos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Aluno objeto)
        {
            using var connection = DataBase.AbreConexao();
            using var command = new FbCommand($"INSERT INTO ALUNOS {_colunas} VALUES {objeto}", connection);

            command.ExecuteNonQuery();
        }

        public void Update(Aluno objeto)
        {
            using var connection = DataBase.AbreConexao();
            using var command = new FbCommand($"UPDATE ALUNOS SET {CriaUpdateSetStatement(objeto)} WHERE ALU_MATRICULA = {objeto.Matricula}", connection);

            command.ExecuteNonQuery();
        }

        private string CriaUpdateSetStatement(Aluno objeto)
        {
            var colunas = _colunas
                .Trim('$', '(', ')')
                .Split(',');

            var valores = objeto
                .ToString()
                .Trim('(', ')')
                .Split(',');

            string set = "";

            for (int i = 0; i < colunas.Length; i++)
            {
                set += $"{colunas[i]}={valores[i]},";
            }

            set = set.Remove(set.Length - 1);

            return set;
        }

        public void Delete(Aluno objeto)
        {
            using var connection = DataBase.AbreConexao();
            using var command = new FbCommand($"DELETE FROM ALUNOS WHERE ALU_MATRICULA = {objeto.Matricula}", connection);

            var reader = command.ExecuteNonQuery();

            if (reader == 0)
            {
                throw new Exception("Objeto não existe, portanto não pode ser deletado");
            }
        }

        public IEnumerable<Aluno> GetAll()
        {
            FillList();

            return alunos;
        }
    }
}
