# 🏥 CRUD de Pacientes

Sistema desenvolvido em **ASP.NET MVC** para gerenciamento de pacientes, utilizando **C#**, **ADO.NET** e **SQL Server**.

## Funcionalidades

* ➕ Cadastro de pacientes
* 📋 Listagem e consulta
* ✏️ Alteração de pacientes
* 🗑️ Exclusão de pacientes
* 📅 Data de nascimento preenchida automaticamente
* 🔢 Geração automática do próximo ID
* ⚠️ Tratamento de erros
* 👤 Nome do responsável opcional

## 🛠️ Tecnologias

* C#
* ASP.NET MVC
* ADO.NET
* SQL Server
* Razor
* HTML/CSS

## 🗄️ Tabela

```sql
CREATE TABLE Pacientes (
    Id INT NOT NULL PRIMARY KEY,
    Data_nascimento DATETIME NOT NULL,
    Nome VARCHAR(MAX) NOT NULL,
    NomeResponsavel VARCHAR(MAX) NULL
);
```

## 👨‍💻 Autor

**Lucas de Melo Chaves** — Engenharia de Computação
