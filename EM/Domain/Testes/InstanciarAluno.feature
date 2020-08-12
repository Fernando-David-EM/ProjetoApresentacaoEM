#language: pt-BR
Funcionalidade: Instanciar um Aluno
	Quero instanciar um aluno
	No código

@instancia
Cenario: Instancia criada com sucesso
	Dado que inicio uma instancia com os valores <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao essa instancia deve ser criada

	Exemplos:
		| matricula | nome     | cpf         | nascimento | sexo |
		| 1         | Fernando | 06424091106 | 18/01/1997 | 0    |
		| 2         | Fernanda | 58681179055 | 10/05/1990 | 1    |
		| 3         | Joana    | 67266967015 | 07/08/2000 | 1    |
		| 4         | Joao     | 14936735051 | 18/01/1997 | 0    |
		| 5         | Ronaldo  | 00274808013 | 05/05/2005 | 0    |

@instancia
Cenario: Erro ao instanciar com nome vazio
	Entao devo receber um erro ao criar uma instancia sem nome

@instancia
Cenario: Erro ao instanciar com nome grande demais
	Entao devo receber um erro ao criar uma instancia com nome gigante

@instancia
Cenario: Erro ao instanciar com cpf inválido
	Entao devo receber um erro ao criar uma instancia com o cpf inválido

@instancia
Cenario: Erro ao instanciar com data no futuro
	Entao devo receber um erro ao criar uma instancia com a data "20/12/2030"