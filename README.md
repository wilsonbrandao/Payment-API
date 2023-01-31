# Payment-API

Payment API
Projeto pessoal de estudos para fixar com conhecimentos adquiridos nos �ltimos meses estudando C#, .NET e ASP.NET.

## Tecnologias utilizadas
- .NET 6
- ASP.NET
- AutoMapper
- FluentResult
- EntityFramework
- SQL Server

## Como executar o projeto em ambiente de desenvolvimento

### Pr�-requisitos

- Ter o runtime [.NET 6](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0) instalado.
- Ter o [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) instalado

### Executando o projeto
- Clonar o reposit�rio
- No terminal, navegar at� a pasta do projeto e executar:
	```bash
	dotnet tool install --global dotnet-ef --version 7.0.0
	 ```
	 ```bash
	dotnet ef database update
	 ```
	```bash
	dotnet run watch
	 ```

Por padr�o, o projeto ir� iniciar o servidor de desenvolvimento no endere�o `https://localhost:7206`

### Rotas da API
� poss�vel visualizar todas as rotas da API atrav�s do [**Swagger**](https://swagger.io/).

Para isso, basta acessar o caminho `/swagger-ui.html`.

Exemplo: `https://localhost:7206/swagger/index.html`