#language: pt-BR
Funcionalidade: Pesquisa de Aluno
	Como um usuario do sistema
	Quero pesquisar um ou mais alunos
	No banco de dados

Contexto: Já conectado
	Dado que estou conectado no banco de dados

@pesquisa
Cenario: Pesquisa total com sucesso
	E introduzo as informações de um aluno
		| matricula | nome     | cpf         | nascimento | sexo |
		| 2         | Fernando | 58681179055 | 10/05/1990 | 0    |
	Entao o aluno deve ser inserido com sucesso
	Mas devo ver esses dois ao pesquisar todos
		| matricula | nome     | cpf         | nascimento | sexo |
		| 1         | Paula    | 61399726048 | 05/10/1990 | 1    |
		| 2         | Fernando | 58681179055 | 10/05/1990 | 0    |

@pesquisa
Cenario: Pesquisa por matricula com sucesso
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao o aluno deve ser inserido com sucesso
	Mas devo receber o mesmo aluno ao pesquisar pela matricula 2

	Exemplos:
		| matricula | nome | cpf         | nascimento | sexo |
		| 2         | Joao | 14936735051 | 18/01/1997 | 0    |

@pesquisa
Cenario: Pesquisa por matricula errada
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao nada deve acontecer ao procurar por uma matricula 20

	Exemplos:
		| matricula | nome  | cpf         | nascimento | sexo |
		| 3         | Jorge | 61399726048 | 07/08/2000 | 0    |

@pesquisa
Cenario: Pesquisa por matricula com sucesso com LINQ
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao o aluno deve ser inserido com sucesso
	Mas devo receber atraves do LINQ o mesmo aluno ao pesquisar pela matricula 2

	Exemplos:
		| matricula | nome | cpf         | nascimento | sexo |
		| 2         | Joao | 14936735051 | 18/01/1997 | 0    |