#language: pt-BR
Funcionalidade: Insercao de Aluno
	Quero cadastrar um aluno
	No banco de dados

Contexto: Já conectado
	Dado que estou conectado no banco de dados

@insercao
Cenario: Inserir com sucesso
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao o aluno deve ser inserido com sucesso
	E o aluno deve estar no banco

	Exemplos:
		| matricula | nome     | cpf            | nascimento | sexo |
		| 2         | Fernando | 586.811.790-55 | 10/05/1990 | 0    |

@insercao
Cenario: Inserir com matricula existente
	E quero inserir um aluno com uma matricula 1 existente
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao devo receber uma mensagem de erro
	E o aluno nao deve ser introduzido

	Exemplos:
		| matricula | nome | cpf            | nascimento | sexo |
		| 1         | Joao | 149.367.350-51 | 18/01/1997 | 0    |

@insercao
Cenario: Inserir com cpf existente
	E quero inserir um aluno com um cpf "613.997.260-48" existente
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao devo receber uma mensagem de erro
	E o aluno nao deve ser introduzido

	Exemplos:
		| matricula | nome  | cpf            | nascimento | sexo |
		| 3         | Jorge | 613.997.260-48 | 07/08/2000 | 0    |

@insercao
Cenario: Inserir com sexo maior que 1
	E quero inserir um aluno com um sexo 2
	E introduzo as informações de um aluno <matricula> <nome> <cpf> <nascimento> <sexo>
	Entao devo receber uma mensagem de erro
	E o aluno nao deve ser introduzido

	Exemplos:
		| matricula | nome   | cpf            | nascimento | sexo |
		| 4         | Romulo | 002.748.080-13 | 05/05/2005 | 2    |

@insercao
Cenario: Inserir mais de um aluno sem cpf
	E introduzo as informações de um aluno <matricula> <nome> <nascimento> <sexo>
	Entao o aluno deve ser inserido com sucesso
	E o aluno deve estar no banco

	Exemplos:
		| matricula | nome    | nascimento | sexo |
		| 21        | Nulinho | 05/05/2005 | 0    |
		| 22        | Nulao   | 05/05/2005 | 0    |