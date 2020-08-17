using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.Repository
{
    class DataBase
    {
        public static string Path { get; set; } = @"C:\Users\Escolar Manager\source\repos\ProjetoApresentacaoEM\ESCOLARMANAGER.FDB";
        public static FbConnection AbreConexao()
        {
            var conexao = new FbConnection(
                $@"ServerType=0;
                    database=localhost:{Path};
                    user=SYSDBA;
                    password=@Fernando23");

            conexao.Open();

            return conexao;
        }
    }
}
