#language: pt-BR
Funcionalidade: Pesquisa de Aluno
	Quero pesquisar um ou mais alunos
	No banco de dados

Contexto: Já conectado
	Dado que estou conectado no banco de dados

@pesquisa
Cenario: Pesquisa total com sucesso
	E introduzo as informações de um aluno
		| matricula | nome     | cpf            | nascimento | sexo |
		| 2         | Fernando | 586.811.790-55 | 10/05/1990 | 0    |
	Entao o aluno deve ser inserido com sucesso
	E devo ver esses dois ao pesquisar todos
		| matricula | nome     | cpf            | nascimento | sexo |
		| 1         | Paula    | 613.997.260-48 | 05/10/1990 | 1    |
		| 2         | Fernando | 586.811.790-55 | 10/05/1990 | 0    |

@pesquisa
Cenario: Pesquisa por matricula com sucesso
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao o aluno deve ser inserido com sucesso
	E devo receber o mesmo aluno ao pesquisar pela matricula 2

	Exemplos:
		| matricula | nome | cpf            | nascimento | sexo |
		| 2         | Joao | 149.367.350-51 | 18/01/1997 | 0    |

@pesquisa
Cenario: Pesquisa por matricula errada
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao nada deve acontecer ao procurar por uma matricula 20

	Exemplos:
		| matricula | nome  | cpf            | nascimento | sexo |
		| 3         | Jorge | 613.997.260-48 | 07/08/2000 | 0    |

@pesquisa
Cenario: Pesquisa por matricula com sucesso com LINQ
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao o aluno deve ser inserido com sucesso
	E devo receber atraves do LINQ o mesmo aluno ao pesquisar pela matricula 2

	Exemplos:
		| matricula | nome | cpf            | nascimento | sexo |
		| 2         | Joao | 149.367.350-51 | 18/01/1997 | 0    |

@pesquisa
Cenario: Pesquisa por nome do aluno com sucesso
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao o aluno deve ser inserido com sucesso
	E devo receber o mesmo aluno ao pesquisar pelo nome "Fernando"

	Exemplos:
		| matricula | nome     | cpf            | nascimento | sexo |
		| 2         | Fernando | 586.811.790-55 | 10/05/1990 | 0    |

@pesquisa
Cenario: Pesquisa por parte de nomes de alunos com sucesso
	E introduzo varios alunos
		| matricula | nome     | cpf            | nascimento | sexo |
		| 2         | Fernanda | 586.811.790-55 | 10/05/1990 | 1    |
		| 3         | Joana    | 672.669.670-15 | 07/08/2000 | 1    |
		| 4         | Joao     | 149.367.350-51 | 18/01/1997 | 0    |
		| 5         | Ronaldo  | 002.748.080-13 | 05/05/2005 | 0    |
	Entao devo receber todos os alunos ao pesquisar pela letra "a"