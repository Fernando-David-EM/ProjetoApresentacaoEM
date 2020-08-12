#language: pt-BR
Funcionalidade: Alteracao de Aluno
	Quero alterar um aluno
	No banco de dados

Contexto: Já conectado
	Dado que estou conectado no banco de dados

@alteracao
Cenario: Alteracao com sucesso
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao o aluno deve ser alterado com sucesso

	Exemplos:
		| matricula | nome          | cpf         | nascimento | sexo |
		| 1         | PaulaAlterada | 61399726048 | 05/10/1990 | 1    |

@alteracao
Cenario: Erro novo cpf existente
	E introduzo um aluno que tinha um cpf <cpf> <matricula> <nome> <nascimento> <sexo>
	E troco para um "61399726048" existente
	Entao devo receber uma mensagem de erro ao alterar

	Exemplos:
		| matricula | nome          | cpf         | nascimento | sexo |
		| 7         | JorgeAlterado | 25361727083 | 07/08/2000 | 0    |