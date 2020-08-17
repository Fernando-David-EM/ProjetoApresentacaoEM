#language: pt-BR
Funcionalidade: Remocao de Aluno
	Quero remover um aluno
	No banco de dados

Contexto: Já conectado
	Dado que estou conectado no banco de dados

@remocao
Cenario: Remocao com sucesso
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao o aluno deve ser inserido com sucesso
	E o aluno deve ser deletado com sucesso

	Exemplos:
		| matricula | nome          | cpf            | nascimento | sexo |
		| 8         | DeletadoSerei | 611.814.500-80 | 22/08/1985 | 1    |

@remocao
Cenario: Erro matricula inexistente
	E procuro um aluno com uma <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao devo receber uma mensagem de erro ao remover

	Exemplos:
		| matricula | nome | cpf            | nascimento | sexo |
		| 9         | Joao | 149.367.350-51 | 18/01/1997 | 0    |