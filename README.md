# Projeto .NET 8 e ASP.NET Core 6

Este é um projeto desenvolvido utilizando .NET 8. O objetivo deste projeto é criar uma API simples de livraria, que permite adicionar livros, identificar por ID, atualizar e excluir livros. Ou seja, um CRUD. Fiz essa API básica sobre livros para treinar meus conhecimentos em .NET 8 e ASP.NET Core 6.

## Requisitos

- .NET 8 SDK
- Visual Studio

## Configuração do Ambiente

1. Clone o repositório:
   ```bash
   git clone https://github.com/RuanVNBezerra/ProjetoLivraria.git
   cd ProjetoLivraria
   ```
2. Navegue até o diretório do projeto:
   ```bash
   cd ProjetoLivraria
   ```
3. Restaure as dependências do projeto:
   ```bash
   dotnet restore
   ```

## Executando o Projeto

Para executar o projeto, utilize o seguinte comando:
```bash
dotnet run
```

## Endpoints da API

- **Criar um livro:**
  - `POST /api/books`
- **Visualizar todos os livros:**
  - `GET /api/books`
- **Visualizar um livro por ID:**
  - `GET /api/books/{id}`
- **Atualizar um livro:**
  - `PUT /api/books/{id}`
- **Excluir um livro:**
  - `DELETE /api/books/{id}`

## Testes

Para rodar os testes, utilize o seguinte comando:
```bash
dotnet test
```

## Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/nome-da-feature`)
3. Commit suas alterações (`git commit -am 'Adiciona nova feature'`)
4. Faça o push para a branch (`git push origin feature/nome-da-feature`)
5. Abra um Pull Request

## Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](https://github.com/RuanVNBezerra/ProjetoLivraria/blob/master/LICENSE.txt) para mais detalhes.