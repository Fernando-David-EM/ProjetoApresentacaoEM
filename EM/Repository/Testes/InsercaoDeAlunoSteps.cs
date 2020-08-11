using FirebirdSql.Data.Client.Native.Handle;
using FirebirdSql.Data.FirebirdClient;
using Gherkin.Events.Args.Pickle;
using NUnit.Framework;
using ProjetoApresentacaoEM.EM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ProjetoApresentacaoEM.EM.Repository.Testes
{
    [Binding]
    class InsercaoDeAlunoSteps
    {

        private RepositorioAluno _repository;
        private Aluno _alunoInserido;
        private List<Aluno> _alunosInseridos = new List<Aluno>();

        private Aluno CriarAluno(TableRow row)
        {
            var aluno = new Aluno();

            if (string.IsNullOrEmpty(row.ElementAtOrDefault(0).Value))
                aluno.Matricula = Convert.ToInt32(row.ElementAtOrDefault(0).Value);
            if (string.IsNullOrEmpty(row.ElementAtOrDefault(1).Value))
                aluno.Nome = row.ElementAtOrDefault(1).Value;
            if (string.IsNullOrEmpty(row.ElementAtOrDefault(2).Value))
                aluno.CPF = row.ElementAtOrDefault(2).Value;
            if (string.IsNullOrEmpty(row.ElementAtOrDefault(3).Value))
                aluno.Nascimento = Convert.ToDateTime(row.ElementAtOrDefault(3).Value);
            if (string.IsNullOrEmpty(row.ElementAtOrDefault(4).Value))
                aluno.Sexo = row.ElementAtOrDefault(4).Value == "Masculino" ? EnumeradorSexo.Masculino : EnumeradorSexo.Feminino;

            return aluno;
        }

        [Given(@"que estou conectado no banco de dados")]
        public void DadoQueEstouConectadoNoBancoDeDados()
        {
            Assert.IsNotNull(DataBase.Conecte());
        }

        [Given(@"introduzo as informações de um aluno")]
        public void DadoIntroduzoAsInformacoesDeUmAluno()
        {
            _repository = new RepositorioAluno();

            var row = table.Rows.FirstOrDefault();

            _alunoInserido = CriarAluno(row);
        }

        [Given(@"tento inseri-lo no sistema")]
        public void DadoTentoInseri_LoNoSistema()
        {
            _repository.Add(_alunoInserido);
        }

        [Then(@"o aluno deve ter sido inserido com sucesso")]
        public void EntaoOAlunoDeveTerSidoInseridoComSucesso()
        {
            Assert.AreEqual(_alunoInserido, _repository.GetByMatricula(_alunoInserido.Matricula));
        }

        [Given(@"introduzo informações em branco de alunos")]
        public void DadoIntroduzoInformacoesEmBrancoDeAlunos()
        {
            _repository = new RepositorioAluno();

            foreach (var row in table.Rows)
            {
                _alunosInseridos.Add(CriarAluno(row));
            }
        }

        [Given(@"tento inseri-los no sistema")]
        public void DadoTentoInseri_LosNoSistema()
        {
            //
        }

        [Then(@"devo receber mensagens de erro todas as vezes")]
        public void EntaoDevoReceberMensagensDeErroTodasAsVezes()
        {
            foreach (var aluno in _alunosInseridos)
            {
                Assert.Throws<Exception>(() => _repository.Add(aluno));
            }
        }

    }
}
