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
    class CadastrarAlunoSteps
    {

        private CadastroDeAlunos _telaCadastroDeAlunos;

        [Given(@"que estou na tela de cadastro")]
        public void DadoQueEstouNaTelaDeCadastro()
        {
            _telaCadastroDeAlunos = new CadastroDeAlunos();

            Assert.IsNotNull(_telaCadastroDeAlunos);
        }

        [Given(@"preencho o campo matricula com a matricula (.*)")]
        public void DadoPreenchoOCampoMatriculaComAMatricula(int matriculaDoAluno)
        {
            _telaCadastroDeAlunos.InsereNoCampoMatricula(matriculaDoAluno);
        }

        [Given(@"preencho o campo nome com o nome ""(.*)""")]
        public void DadoPreenchoOCampoNomeComONome(string nomeDoAluno)
        {
            _telaCadastroDeAlunos.InsereNoCampoNome(nomeDoAluno);
        }

        [Given(@"seleciono o sexo masculino")]
        public void DadoSelecionoOSexoMasculino()
        {
            _telaCadastroDeAlunos.SelecionaSexo(EnumeradorSexo.Masculino);
        }

        [Given(@"preencho o campo nascimento com a data ""(.*)""")]
        public void DadoPreenchoOCampoNascimentoComAData(DateTime data)
        {
            _telaCadastroDeAlunos.InsereNoCampoDataDeNascimento(data);
        }

        [Given(@"preencho o campo cpf com o cpf ""(.*)""")]
        public void DadoPreenchoOCampoCpfComOCpf(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"clico em adicionar")]
        public void DadoClicoEmAdicionar()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"deve existir um novo aluno cadastrado com essas informações no banco")]
        public void EntaoDeveExistirUmNovoAlunoCadastradoComEssasInformacoesNoBanco()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
