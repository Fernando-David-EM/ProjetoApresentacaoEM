﻿using FirebirdSql.Data.FirebirdClient;
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
            DataBase.Path = @"C:\Users\Escolar Manager\source\repos\ProjetoApresentacaoEM\ESCOLARMANAGERTESTE.FDB";

            using var connection = DataBase.AbreConexao();
            using var commandDelete = new FbCommand("DELETE FROM ALUNOS", connection);

            commandDelete.ExecuteNonQuery();

            using var commandInsert = new FbCommand("INSERT INTO ALUNOS (ALU_MATRICULA,ALU_NOME,ALU_CPF,ALU_NASCIMENTO,ALU_SEXO) VALUES (1,'Paula','61399726048','1990-10-05',1)", connection);

            commandInsert.ExecuteNonQuery();
        }
    }
}
