using ProjetoApresentacaoEM.EM.Repository;
using ProjetoApresentacaoEM.EM.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoApresentacaoEM.EM.Domain
{
    class Aluno : IEntidade
    {
        public int Matricula { get; private set; }
        private string _nome;
        public string Nome 
        { 
            get { return _nome; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 100)
                    throw new Exception("O campo nome deve ter no mínimo 1 caracter e no máximo 100!");
                
                _nome = value;
            }
        }
        private string _cpf;
        public string CPF 
        { 
            get 
            { return _cpf; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _cpf = null;
                }
                else
                {
                    if (!ValidaCpf.EhCpf(value))
                        throw new Exception("O cpf informado não é válido!");

                    _cpf = value;
                }
                
            } 
        }
        private DateTime _nascimento;
        public DateTime Nascimento 
        { 
            get { return _nascimento; }
            set
            {
                if (value.Ticks > DateTime.Now.Ticks)
                    throw new Exception("A data de nascimento tem que ser no passado!");

                _nascimento = value;
            }
        }
        public EnumeradorSexo Sexo { get; set; }

        public Aluno(int matricula, string nome, string cpf, DateTime nascimento, EnumeradorSexo sexo)
        {
            Matricula = matricula;
            Nome = nome;
            CPF = cpf;
            Nascimento = nascimento;
            Sexo = sexo;
        }

        public override bool Equals(object obj)
        {
            return obj is Aluno aluno &&
                   Matricula == aluno.Matricula &&
                   Nome == aluno.Nome &&
                   CPF == aluno.CPF &&
                   Nascimento == aluno.Nascimento &&
                   Sexo == aluno.Sexo;
        }

        public override int GetHashCode()
        {
            int hashCode = -1073629611;
            hashCode = hashCode * -1521134295 + Matricula.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CPF);
            hashCode = hashCode * -1521134295 + Nascimento.GetHashCode();
            hashCode = hashCode * -1521134295 + Sexo.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(CPF))
            {

                return $"({Matricula},\'{Nome}\',NULL,\'{Nascimento:yyyy-MM-dd}\',{(int)Sexo})";
            }

            return $"({Matricula},\'{Nome}\',\'{CPF}\',\'{Nascimento:yyyy-MM-dd}\',{(int)Sexo})";
        }
    }
}
