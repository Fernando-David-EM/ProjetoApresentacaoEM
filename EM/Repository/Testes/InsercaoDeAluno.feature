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
		| matricula | nome     | cpf            | nascimento | sexo |
		| 2         | Fernando | 586.811.790-55 | 10/05/1990 | 0    |

@insercao
Cenario: Erro matricula existente
	E introduzo um aluno com uma <matricula> existente <nome> <cpf> <nascimento> <sexo>
	Entao devo receber uma mensagem de erro ao inserir

	Exemplos:
		| matricula | nome | cpf            | nascimento | sexo |
		| 1         | Joao | 149.367.350-51 | 18/01/1997 | 0    |

@insercao
Cenario: Erro cpf existente
	E introduzo um aluno com um <cpf> existente <matricula> <nome> <nascimento> <sexo>
	Entao devo receber uma mensagem de erro ao inserir

	Exemplos:
		| matricula | nome  | cpf            | nascimento | sexo |
		| 3         | Jorge | 613.997.260-48 | 07/08/2000 | 0    |

@insercao
Cenario: Erro sexo maior que 1
	E introduzo um aluno com o <sexo> diferente de um <matricula> <nome> <cpf> <nascimento>
	Entao devo receber uma mensagem de erro ao inserir

	Exemplos:
		| matricula | nome   | cpf            | nascimento | sexo |
		| 4         | Romulo | 002.748.080-13 | 05/05/2005 | 2    |

@insercao
Cenario: Inserir mais de um aluno sem cpf sem dar erro
	Entao nao devo receber erros ao introduzir dois alunos com o cpf nulo
		| matricula | nome             | cpf | nascimento | sexo |
		| 21        | Nulinho da Silva |     | 05/05/2005 | 0    |
		| 22        | Nulao Morais     |     | 05/05/2005 | 0    |