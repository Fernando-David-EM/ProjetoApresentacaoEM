#language: pt-br

Funcionalidade: Cadastrar Aluno
	Para cadastrar um aluno
	Enquanto estou no sistema
	Eu gostaria de cadastrar um aluno

@mytag
Cenario: Cadastro um aluno com sucesso
	Dado que estou na tela de cadastro
	E preencho o campo matricula com a matricula 1
	E preencho o campo nome com o nome "Fernando David"
	E seleciono o sexo masculino
	E preencho o campo nascimento com a data "18/01/1997"
	E preencho o campo cpf com o cpf "06424091106"
	E clico em adicionar
	Entao deve existir um novo aluno cadastrado com essas informações no banco