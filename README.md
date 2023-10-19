# API de CRUD de Produtos com .NET Core 7

Esta é uma API de exemplo para demonstrar um simples CRUD (Create, Read, Update, Delete) de produtos usando o .NET Core 7. A API oferece funcionalidades básicas para gerenciar produtos e inclui testes unitários usando XUnit e a biblioteca GoBus para geração de dados aleatórios.

## Requisitos

Certifique-se de ter o seguinte software instalado em sua máquina:

- .NET Core 7.0 SDK ou superior
- Visual Studio (opcional) ou Visual Studio Code

## Como Iniciar

1. Clone este repositório em sua máquina local.
2. Navegue até o diretório raiz do projeto.
3. Execute o comando `dotnet restore` para restaurar as dependências.
4. Execute o comando `dotnet build` para compilar o projeto.
5. Execute o comando `dotnet run` para iniciar a aplicação.

A API estará disponível localmente em `https://localhost:{PORTA}/`.

## Endpoints

Aqui estão os endpoints disponíveis nesta API:

- `GET /api/produtos` - Obtém todos os produtos.
- `GET /api/produtos/{id}` - Obtém um produto por ID.
- `POST /api/produtos` - Cria um novo produto.
- `PUT /api/produtos/{id}` - Atualiza um produto existente.
- `DELETE /api/produtos/{id}` - Remove um produto existente.

## Testes

Para executar os testes unitários, use os seguintes comandos:

dotnet test

Certifique-se de que o ambiente de teste esteja configurado corretamente e a biblioteca GoBus esteja instalada para a geração de dados aleatórios.

## Licença

Este projeto é licenciado sob a Licença MIT - consulte o arquivo [LICENSE](LICENSE) para mais detalhes.


