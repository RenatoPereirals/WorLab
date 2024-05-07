### **WordService**

O `WordService` é responsável por lidar com regras de negócio relacionadas à categorização de palavras, como similaridade de pronúncia, contexto e tipos gramaticais. Os métodos dentro dessa classe verificam as palavras de acordo com os critérios especificados e atribuem categorias corretamente.

#### **Construtor**

```csharp
public WordService(IPhoneticService phoneticService, IContextualService contextualService, IGrammaticalService grammaticalService)
```
- **Descrição**: Inicializa uma nova instância de `WordService` com os serviços necessários para verificar fonemas, contexto e tipos gramaticais.

- **Parâmetros**:
  - `phoneticService`: Serviço responsável por verificar similaridades de pronúncia.
  - `contextualService`: Serviço responsável por verificar contextos específicos para a palavra.
  - `grammaticalService`: Serviço responsável por verificar tipos gramaticais da palavra.

### **Métodos**

#### **`ClassifyWordAsync`**:

```csharp
public async Task<ClassifiedWord> ClassifyWordAsync(Word word)
```
- **Descrição**: Classifica a palavra em várias categorias, como similaridade de pronúncia, contexto e tipos gramaticais.

- **Parâmetro**:
  - `word`: A palavra a ser classificada.

- **Retorna**: Um objeto `ClassifiedWord` que contém as categorias atribuídas à palavra.

- **Tratamento de erros**:
  - **Validação**: Verifica se `word` atende aos critérios de validação. Se `word` for inválida, lança uma exceção `ArgumentException`.
  - **Exceções**: Outras exceções resultam em lançamentos específicos para erros de categorização.

### **`ClassifyByPhoneticSimilarityAsync`**:

```csharp
public async Task<List<Word>> ClassifyByPhoneticSimilarityAsync(Word word)
```
- **Descrição**: Classifica a palavra com base em similaridade de pronúncia com outras palavras.

- **Parâmetro**:
  - `word`: A palavra a ser classificada.

- **Retorna**: Uma lista de palavras que têm similaridade de pronúncia com `word`.

- **Tratamento de erros**:
  - **Exceções**: Outras exceções resultam em lançamentos específicos para erros de classificação fonética.

### **`ClassifyByContextAsync`**:

```csharp
public async Task<List<string>> ClassifyByContextAsync(Word word)
```
- **Descrição**: Classifica a palavra com base em seu contexto (por exemplo, partes do corpo, países, cores).

- **Parâmetro**:
  - `word`: A palavra a ser classificada.

- **Retorna**: Uma lista de contextos aos quais a palavra pertence.

- **Tratamento de erros**:
  - **Exceções**: Outras exceções resultam em lançamentos específicos para erros de classificação por contexto.

### **`ClassifyByGrammaticalTypeAsync`**:

```csharp
public async Task<List<string>> ClassifyByGrammaticalTypeAsync(Word word)
```
- **Descrição**: Classifica a palavra com base em seus tipos gramaticais (por exemplo, verbo, substantivo, adjetivo).

- **Parâmetro**:
  - `word`: A palavra a ser classificada.

- **Retorna**: Uma lista de tipos gramaticais aos quais a palavra pertence.

- **Tratamento de erros**:
  - **Exceções**: Outras exceções resultam em lançamentos específicos para erros de classificação gramatical.