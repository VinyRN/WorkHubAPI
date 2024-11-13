### Índice
	Pré-requisitos
	Configuração
	Executando o Projeto
	Endpoints da API
	Exemplos de Uso
	Testes
	Docker
	Contribuições
	
### Pré-requisitos
	.NET 8 SDK
	SQL Server ou outra base de dados compatível com Entity Framework Core
	Docker (opcional, para execução em contêiner)
	
### Configuração
	1. Clone o repositório:
		git clone https://github.com/VinyRN/WorkHubAPI
		cd workhub-api
		
	2. Configure a string de conexão no appsettings.json:
		No arquivo appsettings.json, atualize a string de conexão conforme necessário:
		{
		  "ConnectionStrings": {
			"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=WorkHubDb;Trusted_Connection=True;MultipleActiveResultSets=true"
		  }
		}
	3. Execute as migrações para configurar o banco de dados:
		dotnet ef database update

### Executando o Projeto
	Para iniciar o projeto, execute o comando:
		dotnet run

	A API estará disponível em http://localhost:5000 e a interface Swagger poderá ser acessada em http://localhost:5000/swagger.
	
### Endpoints da API

##  	Projetos
	GET /api/projetos - Lista todos os projetos do usuário
	POST /api/projetos - Cria um novo projeto
	DELETE /api/projetos/{id} - Remove um projeto (somente se não houver tarefas pendentes)
	
## Tarefas
	GET /api/projetos/{projetoId}/tarefas - Lista todas as tarefas de um projeto específico
	POST /api/projetos/{projetoId}/tarefas - Cria uma nova tarefa em um projeto
	PUT /api/tarefas/{id} - Atualiza o status ou detalhes de uma tarefa
	DELETE /api/tarefas/{id} - Remove uma tarefa de um projeto

##Relatórios
	GET /api/relatorios/desempenho - Gera um relatório de desempenho do usuário	
	
### Exemplos de Uso
	1. Criação de um Projeto
	
		Requisição:
			{
			  "nome": "Projeto Exemplo",
			  "usuarioId": 1
			}
	
	2. Criação de uma Tarefa
		
		Requisição:
			POST /api/projetos/1/tarefas
	
		Corpo da Requisição:
			{
			  "titulo": "Tarefa Exemplo",
			  "descricao": "Descrição da tarefa",
			  "dataVencimento": "2024-12-31T23:59:59",
			  "status": "Pendente",
			  "prioridade": "Alta"
			}
### Testes
O projeto possui testes de unidade para validar as regras de negócio principais.

Para rodar os testes, execute o comando:
	dotnet test
	
Os testes garantem a cobertura de pelo menos 80% das funcionalidades, incluindo:

	Limite de tarefas por projeto
	Restrição de remoção de projetos com tarefas pendentes
	Registro de histórico ao atualizar tarefas

### Docker
	Para executar o projeto com Docker:

	1. Construir a imagem Docker:
		docker build -t workhubapi .

	2. Executar o contêiner Docker:
		docker run -d -p 8080:80 --name workhubapi_container workhubapi

A API estará disponível em http://localhost:8080.

Alternativamente, você pode usar o docker-compose.yml para configurar o projeto com um banco de dados PostgreSQL:

docker-compose up
