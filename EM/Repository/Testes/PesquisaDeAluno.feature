#language: pt-BR
Funcionalidade: Pesquisa de Aluno
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

@pesquisa
Cenario: Pesquisa por nome do aluno com sucesso
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao o aluno deve ser inserido com sucesso
	Mas devo receber o mesmo aluno ao pesquisar pelo nome "Fernando"

	Exemplos:
		| matricula | nome     | cpf         | nascimento | sexo |
		| 2         | Fernando | 58681179055 | 10/05/1990 | 0    |

@pesquisa
Cenario: Pesquisa por parte de nomes de alunos com sucesso
	E introduzo varios alunos
		| matricula | nome     | cpf         | nascimento | sexo |
		| 2         | Fernanda | 58681179055 | 10/05/1990 | 1    |
		| 3         | Joana    | 67266967015 | 07/08/2000 | 1    |
		| 4         | Joao     | 14936735051 | 18/01/1997 | 0    |
		| 5         | Ronaldo  | 00274808013 | 05/05/2005 | 0    |
	Entao devo receber todos os alunos ao pesquisar pela letra "a"