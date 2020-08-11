#language: pt-BR
Funcionalidade: Insercao de Aluno
	Como um usuario do sistema
	Quero cadastrar um aluno
	No banco de dados

Contexto: Já conectado
	Dado que estou conectado no banco de dados

Cenario: Insercao com sucesso
	E introduzo as informações de um aluno
	E tento inseri-lo no sistema
	Entao o aluno deve ter sido inserido com sucesso

Cenario: Erro de campo nulo
	E introduzo informações em branco de alunos
	E tento inseri-los no sistema
	Entao devo receber mensagens de erro todas as vezes

Exemplos:
	| matricula | nome                | cpf         | nascimento | sexo      |
	| 0000001   | Fernando David      | 06424091106 | 18/01/1997 | Masculino |
	| 0000000   | Ze das Carne        | 15890280074 | 10/12/1990 | Masculino |
	| 0000002   | ""                  | 51800295030 | 05/05/2005 | Feminino  |
	| 0000003   | Pacoquinha da Silva | ""          | 07/07/2007 | Feminino  |
	| 0000004   | Joao das Couve      | 44964596044 | ""         | Masculino |
	| 0000005   | Jonas Pacoca        | 59064148007 | 02/02/2002 | ""        |