﻿using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.Repository
{
    class DataBase
    {
        public static FbConnection Conecte()
        {
            var conexao = new FbConnection(
                @"ServerType=0;
                    database=localhost:E:\Prog\EM\ProjetoApresentacaoEM\ESCOLARMANAGER.FDB;
                    user=SYSDBA;
                    password=@Fernando23");

            conexao.Open();

            return conexao;
        }
    }
}
