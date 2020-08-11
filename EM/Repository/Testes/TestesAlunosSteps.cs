using FirebirdSql.Data.Client.Native.Handle;
using FirebirdSql.Data.FirebirdClient;
using Gherkin.Events.Args.Pickle;
using NUnit.Framework;
using ProjetoApresentacaoEM.EM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ProjetoApresentacaoEM.EM.Repository.Testes
{
    [Binding]
    class TestesAlunosSteps
    {

        private RepositorioAluno _repositorio = new RepositorioAluno();
        private Aluno _aluno;

        [Given(@"que estou conectado no banco de dados")]
        public void DadoQueEstouConectadoNoBancoDeDados()
        {
            TesteHelper.AbreBancoParaTestes(); // da delete nos campos e seta para satisfazer as condiçoes dos testes

            Assert.IsNotNull(DataBase.Conecte());
        }

        [Given(@"introduzo as informações de um aluno (.*) (.*) (.*) (.*) (.*)")]
        public void DadoIntroduzoAsInformacoesDeUmAluno(int matricula, string nome, string cpf, string nascimento, int sexo)
        {
            _aluno =
                new Aluno
                {
                    Matricula = matricula,
                    Nome = nome,
                    CPF = cpf,
                    Nascimento = DateTime.Parse(nascimento),
                    Sexo = (EnumeradorSexo)sexo
                };
        }

        [Then(@"o aluno deve ser inserido com sucesso")]
        public void EntaoOAlunoDeveTerSidoInseridoComSucesso()
        {
            _repositorio.Add(_aluno);

            Assert.AreEqual(_aluno, _repositorio.GetByMatricula(_aluno.Matricula));
        }

        [Given(@"introduzo um aluno com uma (.*) existente (.*) (.*) (.*) (.*)")]
        public void DadoIntroduzoOMesmoAluno(int matricula, string nome, string cpf, string nascimento, int sexo)
        {
            _aluno =
                new Aluno
                {
                    Matricula = matricula,
                    Nome = nome,
                    CPF = cpf,
                    Nascimento = DateTime.Parse(nascimento),
                    Sexo = (EnumeradorSexo)sexo
                };
        }

        [Given(@"introduzo um aluno com um (.*) existente (.*) (.*) (.*) (.*)")]
        public void DadoIntroduzoUmAlunoComUmExistente(string cpf, int matricula, string nome, string nascimento, int sexo)
        {
            _aluno =
                new Aluno
                {
                    Matricula = matricula,
                    Nome = nome,
                    CPF = cpf,
                    Nascimento = DateTime.Parse(nascimento),
                    Sexo = (EnumeradorSexo)sexo
                };
        }


        [Then(@"devo receber uma mensagem de erro ao inserir")]
        public void EntaoDevoReceberMensagensDeErroTodasAsVezes()
        {
            Assert.Throws<FbException>(() => _repositorio.Add(_aluno));
        }

        [Then(@"o aluno deve ser alterado com sucesso")]
        public void EntaoOAlunoDeveSerAlteradoComSucesso()
        {
            _repositorio.Update(_aluno);

            Assert.AreEqual(_aluno, _repositorio.GetByMatricula(_aluno.Matricula));
        }

        [Given(@"introduzo um aluno com o (.*) diferente de um (.*) (.*) (.*) (.*)")]
        public void DadoIntroduzoUmAlunoComOMaiorQue(int sexo, int matricula, string nome, string cpf, string nascimento)
        {
            _aluno =
                   new Aluno
                   {
                       Matricula = matricula,
                       Nome = nome,
                       CPF = cpf,
                       Nascimento = DateTime.Parse(nascimento),
                       Sexo = (EnumeradorSexo)sexo
                   };
        }

        [Given(@"introduzo um aluno que tinha um cpf (.*) (.*) (.*) (.*) (.*)")]
        public void DadoIntroduzoUmAlunoQueTinhaUmCpf(string cpf, int matricula, string nome, string nascimento, int sexo)
        {
            _aluno =
                      new Aluno
                      {
                          Matricula = matricula,
                          Nome = nome,
                          CPF = cpf,
                          Nascimento = DateTime.Parse(nascimento),
                          Sexo = (EnumeradorSexo)sexo
                      };

            _repositorio.Add(_aluno);
        }

        [Given(@"troco para um ""(.*)"" existente")]
        public void DadoTrocoParaUmExistente(string cpfExistente)
        {
            _aluno.CPF = cpfExistente;
        }

        [Then(@"devo receber uma mensagem de erro ao alterar")]
        public void EntaoDevoReceberUmaMensagemDeErroAoAlterar()
        {
            Assert.Throws<FbException>(() => _repositorio.Update(_aluno));
        }

        [Then(@"o aluno deve ser deletado com sucesso")]
        public void EntaoOAlunoDeveSerDeletadoComSucesso()
        {
            _repositorio.Remove(_aluno);

            Assert.IsNull(_repositorio.GetByMatricula(_aluno.Matricula));
        }

        [Given(@"procuro um aluno com uma (.*) (.*) (.*) (.*) (.*)")]
        public void DadoProcuroUmAlunoComUma(int matricula, string nome, string cpf, string nascimento, int sexo)
        {
            _aluno =
                   new Aluno
                   {
                       Matricula = matricula,
                       Nome = nome,
                       CPF = cpf,
                       Nascimento = DateTime.Parse(nascimento),
                       Sexo = (EnumeradorSexo)sexo
                   };
        }

        [Then(@"devo receber uma mensagem de erro ao remover")]
        public void EntaoDevoReceberUmaMensagemDeErroAoRemover()
        {
            var ex = Assert.Throws<Exception>(() => _repositorio.Remove(_aluno));
            Assert.AreEqual("Objeto não existe, portanto não pode ser deletado", ex.Message);
        }

    }
}
