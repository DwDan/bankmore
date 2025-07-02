# BankMore 🏦

**BankMore** é um sistema bancário modular construído com foco em **DDD**, **CQRS**, **Kafka**, **.NET 8** e testes automatizados com **Testcontainers**. Foi desenvolvido como parte de um desafio técnico, com arquitetura extensível e preparada para microserviços.

---

## 📦 Módulos

- **UsuarioService**: autenticação e gestão de usuários
- **ContaCorrenteService**: criação e movimentação de contas correntes
- **TransferenciaService**: transferência entre contas
- **TarifaService** *(opcional)*: processamento assíncrono de tarifas via Kafka
- **BuildingBlocks**: núcleo compartilhado com abstrações, mensagens, eventos, segurança e logging

---

## ⚙️ Tecnologias

- .NET 8 + ASP.NET Core
- Dapper + FluentMigrator (ou EF Core)
- Kafka + KafkaFlow
- JWT + Autenticação customizada
- SQLite (para testes) ou PostgreSQL
- Testcontainers para testes de integração
- MediatR + CQRS
- xUnit

---

## 🚀 Como rodar

1. Clone o projeto:
```bash
git clone https://github.com/seu-usuario/bankmore.git
cd bankmore
```

2. Suba os serviços de infraestrutura (opcional):
```bash
docker compose up -d
```

3. Execute os serviços:
```bash
dotnet run --project src/AuthService
```

4. Acesse a documentação:
- `https://localhost:5001/swagger`

---

## 🧪 Testes

Para rodar os testes com Testcontainers:

```bash
dotnet test
```

---

## 📝 Padrão de commits

Este projeto segue [Conventional Commits](https://www.conventionalcommits.org/), usando tags como `feat`, `fix`, `chore`, `test`, `docs`, etc.

---

## 📁 Estrutura

```
/src
  /services
    /UsuarioService
    /ContaCorrenteService
    /TransferenciaService
    /TarifaServiceService

/tests
  /unit
    /Usuario.Unit.Tests
    /ContaCorrente.Unit.Tests
    /Transferencia.Unit.Tests
    /TarifaService.Unit.Tests
  /integration
    /Usuario.Integration.Tests
    /ContaCorrente.Integration.Tests
    /Transferencia.Integration.Tests
    /TarifaService.Integration.Tests
```

---

## 📌 Observações

- O número da conta é gerado após a criação e vinculado ao usuário.
- JWT carrega o `UserId` como claim.
- O CPF é usado para autenticação e validação.

---

## 📄 Licença

Uso educacional / avaliação técnica.
