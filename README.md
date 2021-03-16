# API DE CLIENTES

Tecnologias utilizadas
.NET 5,
WEB API,
Entity Framework,
MediatorR,
Fluent Validation,
CQRS

Onion -https://github.com/fabiogalante/dotnet-onion/blob/master/docs/ARCHITECTURE.md

Pattern Fail Fast -https://timdows.com/projects/use-mediatr-with-fluentvalidation-in-the-asp-net-core-pipeline/


## Migrations - Mudar a string de conexão se necessário



```bash

dotnet ef migrations remove -v

dotnet ef migrations add CreateDatabase -c ContextApp -s ../MinhaEmpresa.CrudCliente.API

dotnet ef database update -c ContextApp -s ../MinhaEmpresa.CrudCliente.API
```

## Como utilizar

```swagger
Após rodar o migrations é possível testar utilizando o Swagger

Exemplo Update

{
  "id": "467dec85-58f8-4e31-831c-08d8e891b1c2",
  "nome": "ISABELLA FERREIRA",
  "idade": 3
}

```
