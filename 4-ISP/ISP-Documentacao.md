# ISP - Interface Segregation Principle (Princípio da Segregação de Interfaces)

## O que é o ISP?

O **Princípio da Segregação de Interfaces** estabelece que:

> **"Uma classe não deve ser forçada a depender de métodos que ela não utiliza."**

Em outras palavras, é melhor ter **múltiplas interfaces específicas** do que **uma interface genérica e肥胖 (gorda)**.

---

## O Problema (Violação do ISP)

### Situação Atual no Código

No diretório `4-ISP/Violation/`, temos uma interface única `IRegistration`:

```csharp
internal interface IRegistration
{
    void ValidateData();
    void Save();
    void SendEmail(); // <- Problema!
}
```

### Por que isso é um problema?

1. **Cliente (ClientRegistration)**: Precisa enviar e-mail ✓
2. **Produto (ProductRegistration)**: NÃO precisa enviar e-mail ✗

Mas como **ambas as classes** implementam a mesma interface `IRegistration`, a classe `ProductRegistration` é **forçada** a implementar o método `SendEmail()`, mesmo ele não fazendo sentido para produtos.

### Consequências da Violação

- **Método inutilizável**: `ProductRegistration.SendEmail()` lança `NotImplementedException`
- **Acoplamento desnecessário**: A classe depende de algo que não usa
- **Dificuldade de manutenção**: Mudanças na interface afetam classes que não deveriam ser afetadas
- **Código confuso**: Métodos que não fazem sentido no contexto

---

## A Solução (Aplicando o ISP)

### Pensamento "Do que eu preciso?"

1. **O que todas as entidades de cadastro precisam?** → Apenas `Save()` (salvar no banco)
2. **O que o Cliente precisa?** → `ValidateData()` + `SendEmail()`
3. **O que o Produto precisa?** → Apenas `ValidateData()`

### Interfaces Segregadas

Criamos **interfaces específicas e pequenas**:

```
IRegistration (comum a todos)
    └── IClientRegistration (específico para Cliente)
    └── IProductRegistration (específico para Produto)
```

### Estrutura Resultante

**IRegistration.cs** (interface base - apenas o que é comum):
```csharp
internal interface IRegistration
{
    void Save();
}
```

**IClientRegistration.cs** (específica para cliente):
```csharp
internal interface IClientRegistration : IRegistration
{
    void ValidateData();
    void SendEmail();
}
```

**IProductRegistration.cs** (específica para produto):
```csharp
internal interface IProductRegistration : IRegistration
{
    void ValidateData();
}
```

### Classes Implementando Interfaces Segregadas

- `ClientRegistration` implementa `IClientRegistration` → Tem todos os métodos que precisa
- `ProductRegistration` implementa `IProductRegistration` → Não é forçada a implementar `SendEmail()`

---

## Analogia Didática

Imagine uma **fábrica de móveis**:

- **Abordagem errada (interface肥胖)**: Um manual que ensina a fazer **cadeira, mesa, guarda-roupa e sofá** ao mesmo tempo. Um artesão que só faz cadeiras seria forçado a aprender técnicas de estofaria que nunca vai usar.

- **Abordagem certa (interfaces segregadas)**: Manuais separados:
  - Manual de Cadeiras
  - Manual de Mesas
  - Manual de Guarda-roupas
  - Manual de Sofás

Cada artesão aprende apenas o que realmente precisa para sua função.

---

## Benefícios do ISP

| Benefício | Descrição |
|-----------|-----------|
| **Baixo acoplamento** | Classes dependem apenas do necessário |
| **Coesão** | Cada interface tem uma única responsabilidade |
| **Flexibilidade** | É fácil criar novas implementações específicas |
| **Manutenção** | Mudanças em uma interface não afetam classes irrelevantes |
| **Testabilidade** | Mockar/interfacear apenas o que é necessário |

---

## Quando Aplicar?

Aplique o ISP quando:

1. Você perceber que uma classe implementa métodos que não fazem sentido no seu contexto
2. Uma interface está crescendo demais (5+ métodos)
3. Classes diferentes precisam de comportamentos diferentes de uma mesma "entidade"
4. Você está lanzando `NotImplementedException` em métodos herdados

---

## Resumo

```
┌─────────────────────────────────────────────────────────────┐
│                    ANTES (Violação do ISP)                  │
├─────────────────────────────────────────────────────────────┤
│   IRegistration                                             │
│   ├── ValidateData()                                       │
│   ├── Save()                                               │
│   └── SendEmail()  ◄── Forçado para todos!                 │
│          │                                                  │
│   ┌──────┴──────┐                                           │
│   ▼             ▼                                          │
│ Client      Product                                        │
│ (usa)      (não usa, mas precisa implementar)              │
└─────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────┐
│                    DEPOIS (ISP Aplicado)                    │
├─────────────────────────────────────────────────────────────┤
│   IRegistration (comum)                                     │
│   └── Save()                                               │
│          │                                                  │
│   ┌──────┴──────────────────┐                               │
│   ▼                          ▼                              │
│ IClientRegistration    IProductRegistration                │
│ ├── ValidateData()      ├── ValidateData()                 │
│ └── SendEmail()                                          │
│        │                                                  │
│   ┌────┴────┐                                               │
│   ▼         ▼                                               │
│ Client  Product                                            │
│ (ok!)   (ok!)                                               │
└─────────────────────────────────────────────────────────────┘
```

---

## Conclusão

O ISP nos ensina a **dividir para conquistar**. Interfaces pequenas e específicas são mais fáceis de entender, implementar e manter. Quando uma classe precisa de um comportamento, ela implementa a interface que o define. Quando não precisa, não é forçada a implementá-lo.
