# Readme - Projeto ASP.NET 6.0 - CRUD de Funcionários

Este projeto tem como objetivo a implementação de um CRUD (Create, Read, Update e Delete) de funcionários utilizando o padrão de arquitetura MVC (Model-View-Controller) e o Entity Framework como ORM (Object-Relational Mapping). Além disso, foi utilizado um banco de dados MySQL através de uma Factory.

## Pré-requisitos
- .NET 6.0 
- MySQL Server 

## Como usar
1. Clone este repositório em sua máquina local.
2. Abra o Visual Studio e abra o projeto.
3. Execute o comando `dotnet restore` no Console do Gerenciador de Pacotes para restaurar todas as dependências do projeto, incluindo as dependências do Entity Framework Core e do MySQL.
4. Configure a conexão com o banco de dados no arquivo `appsettings.json`.
5. Execute o comando `dotnet ef database update` no Console do Gerenciador de Pacotes para criar as tabelas no banco de dados.
6. Compile e execute o projeto.
7. Acesse a aplicação em seu navegador, digitando a URL `http://localhost:porta/Funcionarios`.

## Arquitetura
Este projeto utiliza o padrão de arquitetura MVC. 
- **Model**: O modelo é responsável pela representação dos dados e pela lógica de negócios da aplicação. No projeto, o modelo é representado pela classe `Funcionario`.
- **View**: A View é responsável pela interface gráfica da aplicação. No projeto, as Views estão localizadas na pasta `Views`.
- **Controller**: O controlador é responsável por receber as requisições do usuário e enviar as respostas adequadas. No projeto, os controllers estão localizados na pasta `Controllers`.

## Entity Framework
O Entity Framework é um ORM (Object-Relational Mapping) que permite que os desenvolvedores trabalhem com bancos de dados relacionais usando objetos .NET. No projeto, o Entity Framework é utilizado para mapear as tabelas do banco de dados com as classes do modelo e realizar operações CRUD.

## MySQL Factory
A MySQL Factory é uma classe responsável por criar a conexão com o banco de dados MySQL e retornar o contexto do Entity Framework configurado para utilizar essa conexão.

## Comentários explicativos
O código do projeto está totalmente comentado, de forma a tornar mais fácil o entendimento de cada parte do código e a sua respectiva funcionalidade. Os comentários estão em inglês, mas de fácil compreensão para desenvolvedores familiarizados com a linguagem.
