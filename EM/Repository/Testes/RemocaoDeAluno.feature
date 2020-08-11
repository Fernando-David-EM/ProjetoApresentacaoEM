#language: pt-BR
Funcionalidade: Remocao de Aluno
	Como um usuario do sistema
	Quero remover um aluno
	No banco de dados

Contexto: Já conectado
	Dado que estou conectado no banco de dados

@remocao
Cenario: Remocao com sucesso
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao o aluno deve ser inserido com sucesso
	Mas o aluno deve ser deletado com sucesso

	Exemplos:
		| matricula | nome          | cpf         | nascimento | sexo |
		| 8         | DeletadoSerei | 61181450080 | 22/08/1985 | 1    |

@remocao
Cenario: Erro matricula inexistente
	E procuro um aluno com uma <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao devo receber uma mensagem de erro ao remover

	Exemplos:
		| matricula | nome | cpf         | nascimento | sexo |
		| 9         | Joao | 14936735051 | 18/01/1997 | 0    |