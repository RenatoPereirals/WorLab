## Controllers

### WordController

A `WordController` é responsável por gerenciar operações relacionadas a palavras, como inserção, busca, exclusão, atualização e recuperação de todas as palavras.

- **Dependências**:
  - `IWordRepository _wordRepository`: Um repositório de palavras.
  - `IWordApplication _wordApplication`: Uma aplicação para manipulação de palavras.

#### Construtor

```csharp
public WordController(IWordRepository wordRepository, IWordApplication wordApplication)
```
- **Descrição**: Inicializa uma nova instância da `WordController` com as dependências necessárias.

- **Parâmetros**:
  - `wordRepository`: O repositório de palavras a ser utilizado pela controller.
  - `wordApplication`: A aplicação para manipulação de palavras.

## Métodos

### **`InsertWord`**:

```csharp
public async Task<IActionResult> InsertWord(string word)
```
- **Descrição**: Insere uma nova palavra após validá-la e determinar seu tipo.
- **Parâmetro**:
  - `word`: A palavra a ser inserida.
- **Retorna**: Um `IActionResult` indicando o resultado da operação.
- **Tratamento de erros**:
  - **Validação**: Se `word` for nulo ou vazio, uma resposta HTTP com código `400 Bad Request` será retornada.
  - **Duplicação**: Se `word` já existir no repositório, uma resposta HTTP com código `409 Conflict` será retornada.
  - **Exceções**: Se ocorrer qualquer outra exceção, uma resposta HTTP com código `500 Internal Server Error` será retornada.

### **`GetAllWord`**:

```csharp
public async Task<IActionResult> GetAllWord()
```
- **Descrição**: Recupera todas as palavras do repositório.
- **Retorna**: Um `IActionResult` contendo uma lista de todas as palavras.
- **Tratamento de erros**:
  - **Exceções**: Se ocorrer qualquer problema ao buscar palavras no repositório, uma resposta HTTP com código `500 Internal Server Error` será retornada.

### **`GetWord`**:

```csharp
public async Task<IActionResult> GetWord(string word)
```
- **Descrição**: Recupera uma palavra específica do repositório.
- **Parâmetro**:
  - `word`: A palavra a ser recuperada.
- **Retorna**: Um `IActionResult` contendo a palavra especificada, se encontrada.


### **`UpdateWord`**:

```csharp
public async Task<IActionResult> UpdateWord(string word, Word updatedWord)
```
- **Descrição**: Atualiza uma palavra existente com base nas novas informações fornecidas em `updatedWord`.
- **Parâmetros**:
  - `word`: A palavra existente a ser atualizada.
  - `updatedWord`: O objeto `Word` contendo as novas informações para atualizar a palavra existente.
- **Retorna**: Um `IActionResult` indicando o resultado da operação.

- **Tratamento de erros**:
  - **Não encontrada**: Se `word` não for encontrada no repositório, uma resposta HTTP com código `404 Not Found` será retornada.
  - **Validação**: Se `updatedWord` contiver dados inválidos, uma resposta HTTP com código `400 Bad Request` será retornada.
  - **Exceções**: Se ocorrer qualquer outra exceção, uma resposta HTTP com código `500 Internal Server Error` será retornada.

### **`DeleteWord`**:

```csharp
public async Task<IActionResult> DeleteWord(string word)
```
- **Descrição**: Exclui uma palavra específica do repositório.
- **Parâmetro**:
  - `word`: A palavra a ser excluída.
- **Retorna**: Um `IActionResult` indicando o resultado da operação.

- **Tratamento de erros**:
  - **Não encontrada**: Se `word` não for encontrada no repositório, uma resposta HTTP com código `404 Not Found` será retornada.
  - **Exceções**: Se ocorrer qualquer outra exceção, uma resposta HTTP com código `500 Internal Server Error` será retornada.
