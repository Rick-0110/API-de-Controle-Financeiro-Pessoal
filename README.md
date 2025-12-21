# 💰 API de Controle Financeiro Pessoal

Projeto desenvolvido com o objetivo de estudar e aplicar conceitos avançados de desenvolvimento back-end com .NET e C#.

## 🧠 O que estou aprendendo/aplicando
Este projeto não é apenas um CRUD, mas um exercício de arquitetura de software. Os principais conceitos aplicados foram:

* **Clean Architecture:** Separação de responsabilidades em camadas (Domain, Infrastructure, API).
* **Repository Pattern:** Desacoplamento entre a lógica de negócio e o acesso a dados.
* **Entity Framework Core:** Uso de Migrations, Mapeamento de Entidades e Relacionamentos (One-to-Many).
* **Injeção de Dependência:** Configuração de serviços e repositórios no container do .NET.
* **Tratamento de Ciclos JSON:** Uso do `[JsonIgnore]` para evitar loops infinitos em relacionamentos bidirecionais.
* **Swagger:** Documentação automática da API.

## 🛠️ Tecnologias Utilizadas
* .NET 8 (C#)
* MySQL (Banco de Dados)
* Entity Framework Core
* Swagger UI

## ⚙️ Como rodar o projeto
1. Clone o repositório.
2. Configure a `ConnectionString` no arquivo `appsettings.json` com seu banco MySQL.
3. Rode as migrations para criar o banco:
   ```powershell
   Update-Database -Project FinanceControl.Infrastructure -StartupProject "API de Controle Financeiro Pessoal"
