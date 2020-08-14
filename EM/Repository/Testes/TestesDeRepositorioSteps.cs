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
    class TestesDeRepositorioSteps
    {
        private RepositorioAluno _repositorio = new RepositorioAluno();
        private Aluno _aluno;

        private Aluno CriaAluno(int matricula, string nome, string cpf, string nascimento, int sexo)
        {
            return new Aluno
            (
                matricula,
                nome,
                cpf,
                DateTime.Parse(nascimento),
                (EnumeradorSexo)sexo
            );
        }

        private Aluno CriaAluno(TableRow row)
        {
            return new Aluno
            (
                Convert.ToInt32(row.ElementAtOrDefault(0).Value),
                row.ElementAtOrDefault(1).Value,
                row.ElementAtOrDefault(2).Value,
                DateTime.Parse(row.ElementAtOrDefault(3).Value),
                (EnumeradorSexo)Convert.ToInt32(row.ElementAtOrDefault(4).Value)
            );
        }

        [Given(@"que estou conectado no banco de dados")]
        public void DadoQueEstouConectadoNoBancoDeDados()
        {
            TesteCriaDBHelper.AbreBancoParaTestes(); // da delete nos campos e seta para satisfazer as condiçoes dos testes

            Assert.IsNotNull(DataBase.AbreConexao());
        }

        [Given(@"introduzo as informações de um aluno (.*) (.*) (.*) (.*) (.*)")]
        public void DadoIntroduzoAsInformacoesDeUmAluno(int matricula, string nome, string cpf, string nascimento, int sexo)
        {
            _aluno = CriaAluno(matricula, nome, cpf, nascimento, sexo);
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
            _aluno = CriaAluno(matricula, nome, cpf, nascimento, sexo);
        }

        [Given(@"introduzo um aluno com um (.*) existente (.*) (.*) (.*) (.*)")]
        public void DadoIntroduzoUmAlunoComUmExistente(string cpf, int matricula, string nome, string nascimento, int sexo)
        {
            _aluno = CriaAluno(matricula, nome, cpf, nascimento, sexo);
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
            _aluno = CriaAluno(matricula, nome, cpf, nascimento, sexo);
        }

        [Given(@"introduzo um aluno que tinha um cpf (.*) (.*) (.*) (.*) (.*)")]
        public void DadoIntroduzoUmAlunoQueTinhaUmCpf(string cpf, int matricula, string nome, string nascimento, int sexo)
        {
            _aluno = CriaAluno(matricula, nome, cpf, nascimento, sexo);

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
            _aluno = CriaAluno(matricula, nome, cpf, nascimento, sexo);
        }

        [Then(@"devo receber uma mensagem de erro ao remover")]
        public void EntaoDevoReceberUmaMensagemDeErroAoRemover()
        {
            var ex = Assert.Throws<Exception>(() => _repositorio.Remove(_aluno));
            Assert.AreEqual("Objeto não existe, portanto não pode ser deletado", ex.Message);
        }

        [Given(@"introduzo as informações de um aluno")]
        public void DadoIntroduzoAsInformacoesDeUmAluno(Table table)
        {
            var row = table.Rows[0];

            _aluno = CriaAluno(row);
        }

        [Then(@"devo ver esses dois ao pesquisar todos")]
        public void EntaoDevoVerEssesDoisAoPesquisarTodos(Table table)
        {
            var row1 = table.Rows[0];
            var row2 = table.Rows[1];

            var aluno1 = CriaAluno(row1);
            var aluno2 = CriaAluno(row2);

            var alunosPesquisa = _repositorio.GetAll();

            Assert.AreEqual(aluno1, alunosPesquisa.FirstOrDefault());
            Assert.AreEqual(aluno2, alunosPesquisa.LastOrDefault());
        }

        [Then(@"devo receber o mesmo aluno ao pesquisar pela matricula (.*)")]
        public void EntaoDevoReceberOMesmoAlunoAoPesquisarPela(int matricula)
        {
            Assert.AreEqual(_aluno, _repositorio.GetByMatricula(matricula));
        }

        [Then(@"nada deve acontecer ao procurar por uma matricula (.*)")]
        public void EntaoNadaDeveAcontecerAoProcurarPorUmaMatricula(int matricula)
        {
            Assert.DoesNotThrow(() => _repositorio.GetByMatricula(matricula));
        }

        [Then(@"devo receber atraves do LINQ o mesmo aluno ao pesquisar pela matricula (.*)")]
        public void EntaoDevoReceberAtravesDoLINQOMesmoAlunoAoPesquisarPelaMatricula(int matricula)
        {
            Assert.AreEqual(
                _aluno, 
                _repositorio
                .Get(x => x.Matricula == matricula)
                .FirstOrDefault());
        }

        [Then(@"devo receber o mesmo aluno ao pesquisar pelo nome ""(.*)""")]
        public void EntaoDevoReceberOMesmoAlunoAoPesquisarPeloNome(string nomeDoAluno)
        {
            Assert.AreEqual(nomeDoAluno, _repositorio.GetByConteudoNoNome(nomeDoAluno).FirstOrDefault().Nome);
        }

        [Given(@"introduzo varios alunos")]
        public void DadoIntroduzoVariosAlunos(Table table)
        {
            var rows = table.Rows;

            foreach (var row in rows)
            {
                _repositorio.Add(CriaAluno(row));
            }
        }

        [Then(@"devo receber todos os alunos ao pesquisar pela letra ""(.*)""")]
        public void EntaoDevoReceberOsMesmosAlunosAoPesquisarPelaLetra(string letra)
        {
            Assert.AreEqual(_repositorio.GetAll(), _repositorio.GetByConteudoNoNome(letra));
        }

        [Then(@"nao devo receber erros ao introduzir dois alunos com o cpf nulo")]
        public void EntaoNaoDevoReceberErrosAoIntroduzirDoisAlunosComOCpfNulo(Table table)
        {
            var rows = table.Rows;

            foreach (var row in rows)
            {
                _repositorio.Add(CriaAluno(row));
            }
        }

    }
}
