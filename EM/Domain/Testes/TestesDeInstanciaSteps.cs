using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ProjetoApresentacaoEM.EM.Domain.Testes
{
    [Binding]
    class TestesDeInstanciaSteps
    {
        private Aluno _aluno;

        private Aluno CrieAluno(int matricula, string nome, string cpf, string nascimento, int sexo)
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

        [Given(@"que inicio uma instancia com os valores (.*) (.*) (.*) (.*) (.*)")]
        public void DadoQueInicioUmaInstanciaComOsValores(int matricula, string nome, string cpf, string nascimento, int sexo)
        {
            _aluno = CrieAluno(matricula, nome, cpf, nascimento, sexo);
        }

        [Then(@"essa instancia deve ser criada")]
        public void EntaoEssaInstanciaDeveSerCriada()
        {
            Assert.IsNotNull(_aluno);
        }

        [Then(@"devo receber um erro ao criar uma instancia sem nome")]
        public void EntaoDevoReceberUmErroAoCriarEssaInstanciaComOsValores()
        {
            Assert.Throws<Exception>(() => CrieAluno(0, "", "06424091106", "18/01/1997", 0));
        }

        [Then(@"devo receber um erro ao criar uma instancia com nome gigante")]
        public void EntaoDevoReceberUmErroAoCriarUmaInstanciaComNomeGigante()
        {
            string nome = "";

            for (int i = 0; i <= 101; i++)
            {
                nome += "a";
            }

            Assert.Throws<Exception>(() => CrieAluno(0, nome, "06424091106", "18/01/1997", 0));
        }

        [Then(@"devo receber um erro ao criar uma instancia com o cpf inválido")]
        public void EntaoDevoReceberUmErroAoCriarUmaInstanciaComOCpfInvalido()
        {
            Assert.Throws<Exception>(() => CrieAluno(0, "Fernando", "00000000000", "18/01/1997", 0));
        }

        [Then(@"devo receber um erro ao criar uma instancia com a data ""(.*)""")]
        public void EntaoDevoReceberUmErroAoCriarUmaInstanciaComAData(string data)
        {
            Assert.Throws<Exception>(() => CrieAluno(0, "Fernando", "06424091106", data, 0));
        }

    }
}
