using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.Repository.Testes
{
    class TesteCriaDBHelper
    {
        public static void AbreBancoParaTestes()
        {
            DataBase.Path = @"C:\Users\Escolar Manager\source\repos\ProjetoApresentacaoEM\TESTEREFLECTIONDBCONTEXT.FDB";

            using var connection = DataBase.AbreConexao();
            using var commandDelete = new FbCommand("DELETE FROM ALUNO", connection);

            commandDelete.ExecuteNonQuery();

            using var commandInsert = new FbCommand("INSERT INTO ALUNO (MATRICULA,NOME,CPF,NASCIMENTO,SEXO) VALUES (1,'Paula','613.997.260-48','1990-10-05',1)", connection);

            commandInsert.ExecuteNonQuery();
        }
    }
}
