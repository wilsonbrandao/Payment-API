# Payment-API

Payment API
Projeto pessoal de estudos para fixar com conhecimentos adquiridos nos últimos meses estudando C#, .NET e ASP.NET.

## Tecnologias utilizadas
- .NET 6
- ASP.NET
- AutoMapper
- FluentResult
- EntityFramework
- SQL Server

## Como executar o projeto em ambiente de desenvolvimento

### Pré-requisitos

- Ter o runtime [.NET 6](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0) instalado.
- Ter o [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) instalado

### Executando o projeto
- Clonar o repositório
- No terminal, navegar até a pasta do projeto e executar:
	```bash
	dotnet tool install --global dotnet-ef --version 7.0.0
	 ```
	 ```bash
	dotnet ef database update
	 ```
	```bash
	dotnet run watch
	 ```

Por padrão, o projeto irá iniciar o servidor de desenvolvimento no endereço `https://localhost:7206`

### Rotas da API
É possível visualizar todas as rotas da API através do [**Swagger**](https://swagger.io/).

Para isso, basta acessar o caminho `/swagger-ui.html`.

Exemplo: `https://localhost:7206/swagger/index.html`