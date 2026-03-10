# Estudos SOLID

Repositório com exemplos práticos dos **5 princípios SOLID** em C# (.NET 8).

## O que é SOLID?

Conjunto de 5 princípios de design orientação a objetos que tornam o código mais manutenível, flexível e escalável.

| Princípio | Nome | Significado |
|-----------|------|-------------|
| **S** | Single Responsibility | Uma classe deve ter apenas uma razão para mudar |
| **O** | Open/Closed | Classes devem estar abertas para extensão, fechadas para modificação |
| **L** | Liskov Substitution | Objetos de uma classe base devem poder ser substituídos por objetos de subclasses |
| **I** | Interface Segregation | Prefira interfaces específicas a interfaces genéricas |
| **D** | Dependency Inversion | Dependa de abstrações, não de implementações |

## Estrutura do Projeto

```
SOLID/
├── 1-SRP/   # Single Responsibility Principle
├── 2-OCP/   # Open/Closed Principle  
├── 3-LSP/   # Liskov Substitution Principle
├── 4-ISP/   # Interface Segregation Principle
├── 5-DIP/   # Dependency Inversion Principle
```

Cada diretório contém:
- `Violation/` - Exemplo que viola o princípio
- `Solution/` - Exemplo que aplica o princípio corretamente

## Como Executar

```bash
dotnet run --project 1-SRP
dotnet run --project 2-OCP
dotnet run --project 3-LSP
dotnet run --project 4-ISP
dotnet run --project 5-DIP
```
