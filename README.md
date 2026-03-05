# ClinuxSupportToolkit

Ferramenta CLI em C# (.NET) para análise de arquivos de log.

## Funcionalidades

- Leitura de arquivos de log
- Filtro por nível (INFO, WARN, ERROR)
- Busca por texto
- Exportação de resultados em CSV

## Estrutura do Projeto
src/
├─ ClinuxSupportToolkit.Cli
└─ ClinuxSupportToolkit.Core

tests/
└─ ClinuxSupportToolkit.Tests


## Como executar

Rodar com um arquivo de log:


dotnet run --project src/ClinuxSupportToolkit.Cli -- --file sample.log


Filtrar apenas erros:


dotnet run --project src/ClinuxSupportToolkit.Cli -- --file sample.log --level ERROR


Buscar texto no log:


dotnet run --project src/ClinuxSupportToolkit.Cli -- --file sample.log --contains "token"


Exportar para CSV:


dotnet run --project src/ClinuxSupportToolkit.Cli -- --file sample.log --level ERROR --csv resultado.csv


## Tecnologias

- C#
- .NET
- CLI Application
- Git / GitHub
