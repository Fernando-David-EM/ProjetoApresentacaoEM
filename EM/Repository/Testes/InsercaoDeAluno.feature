#language: pt-BR
Funcionalidade: Insercao de Aluno
	Quero cadastrar um aluno
	No banco de dados

Contexto: Já conectado
	Dado que estou conectado no banco de dados

@insercao
Cenario: Insercao com sucesso
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao o aluno deve ser inserido com sucesso

	Exemplos:
		| matricula | nome     | cpf         | nascimento | sexo |
		| 2         | Fernando | 58681179055 | 10/05/1990 | 0    |

@insercao
Cenario: Erro matricula existente
	E introduzo um aluno com uma <matricula> existente <nome> <cpf> <nascimento> <sexo>
	Entao devo receber uma mensagem de erro ao inserir

	Exemplos:
		| matricula | nome | cpf         | nascimento | sexo |
		| 1         | Joao | 14936735051 | 18/01/1997 | 0    |

@insercao
Cenario: Erro cpf existente
	E introduzo um aluno com um <cpf> existente <matricula> <nome> <nascimento> <sexo>
	Entao devo receber uma mensagem de erro ao inserir

	Exemplos:
		| matricula | nome  | cpf         | nascimento | sexo |
		| 3         | Jorge | 61399726048 | 07/08/2000 | 0    |

@insercao
Cenario: Erro sexo maior que 1
	E introduzo um aluno com o <sexo> diferente de um <matricula> <nome> <cpf> <nascimento>
	Entao devo receber uma mensagem de erro ao inserir

	Exemplos:
		| matricula | nome   | cpf         | nascimento | sexo |
		| 4         | Romulo | 00274808013 | 05/05/2005 | 2    |