# GoFast.Web
Frontend 
Tech Challenge
Desenvolvimento do projeto GoFast.
📚 Sobre o projeto
O projeto tem como objetivo criar uma solução para gestão de produtos de uma loja de games online. A Solução contém o projeto de uma API que manipula uma base de dados SQL Server. O projeto está sendo desenvolvido em grupo, com o objetivo de compartilhar conhecimentos e experiências e atender os requisitos avaliativos do Tech Challenge FIAP do curso postech ARQUITETURA DE SISTEMAS .NET COM AZURE.

📝 Conteúdo
Sobre o projeto
Configuração do ambiente
📋 Pré-requisitos
.NET 6.0
Sql Server
🎲 Banco de dados
A configuração do banco de dados é feita através do arquivo appsettings.json, que fica na raiz do projeto GameStore.API. O arquivo já está configurado para o banco de dados Sql Server local, mas caso queira utilizar outro banco de dados, basta alterar a string de conexão. Você pode configurar também a váriavel lojaGamesDB que pode conter o endereço do banco remoto, no caso deste projeto ele será publicado no Azure. Importante configurar também a flag enable_connection_local_db para habilitar a troca do banco apontando para nuvem ou para o servidor local.

"FeatureFlags": {
    "enable_connection_local_db":  "true"
  },
  "ConnectionStrings": {
    "lojaGamesDB_local": "string_de_conexao_com_SQLServer",
    "lojaGamesDB": ""
  }
Ainda exite a configuração das imagens usando o container do BlobStorage do Azure.

  //Definir qual a connection string na chave de acesso do storage account
  "ConnectionStorageAccount": "",

  //Definir o nome do container criado no storage account para receber os blobs storages
  "ContainerBlobStorage": "",
🚀 Como executar o projeto
# Clone este repositório
$ git clone https://github.com/andreleaos/LojaGames.git

# Acesse a pasta do projeto no terminal o projeto Web /cmd
$ cd ./LojaGames/GameStore/GameStore.Web [Executar o projeto Web]

# Acesse a pasta do projeto no terminal o projeto API /cmd
$ cd ./LojaGames/GameStore/GameStore.Api [Executar o projeto API]

# Execute a aplicação em modo de desenvolvimento
$ dotnet run

# O servidor inciará localmente na porta:5237 - acesse http://localhost:5237
🛠 Tecnologias
As seguintes ferramentas foram usadas na construção do projeto:

C# - Linguagem
.NET Core 6 - Framework
Swagger - Documentação da API

✒️ Colaborador(as/es)
Samuel Matos - Desenvolvedor - Samuel Matos#0058
Lucas Marques - Desenvolvedor - lucasmarques1953
