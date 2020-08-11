using ProjetoApresentacaoEM.EM.Domain;
using ProjetoApresentacaoEM.EM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoApresentacaoEM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var aluno = new Aluno
            {
                Matricula = 1,
                Nome = "Fernando",
                CPF = "06424091106",
                Nascimento = DateTime.Parse("18/01/1997"),
                Sexo = EnumeradorSexo.Masculino
            };

            var colunas = "(alu_matricula,alu_nome,alu_cpf,alu_nascimento,alu_sexo)";

            Console.WriteLine(RepositorioHelper.RecebeSetDoObjeto(colunas, aluno));
        }
    }
}
