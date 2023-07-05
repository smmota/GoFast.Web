<h1 align="center"> Tech Challenge</h1>
<h3 align="center">Desenvolvimento do projeto GoFast</h3>

## 📚 Sobre o projeto

O projeto tem como objetivo criar uma solução para gestão de produtos de uma loja de games online. A Solução contém o projeto de uma API que manipula uma base de dados SQL Server.
O projeto está sendo desenvolvido em grupo, com o objetivo de compartilhar conhecimentos e experiências e atender os requisitos avaliativos do Tech Challenge FIAP do curso postech ARQUITETURA DE SISTEMAS .NET COM AZURE.

## 📝 Conteúdo

- [Sobre o projeto](#-sobre-o-projeto)

## Configuração do ambiente

### 📋 Pré-requisitos

- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)

### 🎲 Banco de dados
A configuração do banco de dados é feita através do arquivo appsettings.json, que fica na raiz do projeto GameStore.API. 
O arquivo já está configurado para o banco de dados **Sql Server** local, mas caso queira utilizar outro banco de dados, basta alterar a string de conexão. Você pode configurar também
a váriavel `lojaGamesDB` que pode conter o endereço do banco remoto, no caso deste projeto ele será publicado no Azure. Importante configurar também a flag `enable_connection_local_db` 
para habilitar a troca do banco apontando para nuvem ou para o servidor local.

```json
"FeatureFlags": {
    "enable_connection_local_db":  "true"
  },
  "ConnectionStrings": {
    "lojaGamesDB_local": "string_de_conexao_com_SQLServer",
    "lojaGamesDB": ""
  }
```

Ainda exite a configuração das imagens usando o container do BlobStorage do Azure.
```json
  //Definir qual a connection string na chave de acesso do storage account
  "ConnectionStorageAccount": "",

  //Definir o nome do container criado no storage account para receber os blobs storages
  "ContainerBlobStorage": "",
```

## 🚀 Como executar o projeto

```bash
# Clone este repositório
$ git clone https://github.com/smmota/GoFast.Web.git

## 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/) - Linguagem
- [.NET Core 6]([https://docs.microsoft.com/pt-br/dotnet/](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)) - Framework
- [Swagger](https://swagger.io/) - Documentação da API

## ✒️ Colaborador(as/es)

✒️ Colaborador(as/es)
Samuel Matos - Desenvolvedor - Samuel Matos#0058
Lucas Marques - Desenvolvedor - lucasmarques1953
