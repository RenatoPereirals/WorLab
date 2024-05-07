## Controllers

### WordController

A `WordController` gerencia operações relacionadas a palavras, como inserção, busca, exclusão, atualização e recuperação de todas as palavras. Ela utiliza `IWordRepository` para lidar com dados de palavras e `IWordApplication` para lógica de aplicação.

#### Construtor

```csharp
public WordController(IWordRepository wordRepository, IWordApplication wordApplication)
```
- **Descrição**: Inicializa uma nova instância da `WordController` com o repositório e aplicação fornecidos.

- **Parâmetros**:
  - `wordRepository`: Repositório de palavras utilizado pela controller.
  - `wordApplication`: Aplicação para manipulação de palavras.

### Métodos

#### **`InsertWord`**:

```csharp
public async Task<IActionResult> InsertWord(string word)
```
- **Descrição**: Insere uma nova palavra após validá-la localmente e verificar sua existência usando um serviço externo.

- **Parâmetro**:
  - `word`: A palavra a ser inserida.
  
- **Retorna**: 
  - `IActionResult` com código `201 Created` se a palavra for inserida com sucesso.
  - `400 Bad Request` se a palavra for inválida ou o serviço externo rejeitar a palavra.
  - `409 Conflict` se a palavra já existir no repositório.

- **Tratamento de erros**:
  - **Validação Local**: Valida se `word` é uma string alfanumérica sem caracteres especiais. Se `word` for inválida, retorna `400 Bad Request`.
  - **Serviço Externo**: Consulta um serviço externo para verificar se `word` é válida. Se a palavra não passar na validação do serviço externo, retorna `400 Bad Request`.
  - **Exceções**: Qualquer exceção resultará em `500 Internal Server Error`.

#### **`GetAllWord`**:

```csharp
public async Task<IActionResult> GetAllWord()
```
- **Descrição**: Recupera todas as palavras do repositório.

- **Retorna**: `IActionResult` contendo uma lista de todas as palavras.

- **Tratamento de erros**:
  - **Exceções**: Se ocorrer qualquer problema ao buscar palavras no repositório, retorna `500 Internal Server Error`.

#### **`GetWord`**:

```csharp
public async Task<IActionResult> GetWord(string word)
```
- **Descrição**: Recupera uma palavra específica do repositório.

- **Parâmetro**:
  - `word`: A palavra a ser recuperada.
  
- **Retorna**: `IActionResult` contendo a palavra especificada, se encontrada.

- **Tratamento de erros**:
  - **Não encontrada**: Se `word` não for encontrada no repositório, retorna `404 Not Found`.
  - **Exceções**: Qualquer outra exceção resultará em `500 Internal Server Error`.

#### **`UpdateWord`**:

```csharp
public async Task<IActionResult> UpdateWord(string word, Word updatedWord)
```
- **Descrição**: Atualiza uma palavra existente com as informações fornecidas em `updatedWord`.

- **Parâmetros**:
  - `word`: A palavra existente a ser atualizada.
  - `updatedWord`: O objeto `Word` contendo as novas informações para atualizar a palavra existente.
  
- **Retorna**: `IActionResult` indicando o resultado da operação.

- **Tratamento de erros**:
  - **Não encontrada**: Se `word` não for encontrada no repositório, retorna `404 Not Found`.
  - **Validação Local**: Verifica se `updatedWord` é válido (não contém caracteres especiais ou números). Se `updatedWord` for inválido, retorna `400 Bad Request`.
  - **Serviço Externo**: Consulta um serviço externo para validar `updatedWord`. Se não passar, retorna `400 Bad Request`.
  - **Exceções**: Qualquer outra exceção resultará em `500 Internal Server Error`.

#### **`DeleteWord`**:

```csharp
public async Task<IActionResult> DeleteWord(string word)
```
- **Descrição**: Exclui uma palavra específica do repositório.

- **Parâmetro**:
  - `word`: A palavra a ser excluída.
  
- **Retorna**: `IActionResult` indicando o resultado da operação.

- **Tratamento de erros**:
  - **Não encontrada**: Se `word` não for encontrada no repositório, retorna `404 Not Found`.
  - **Exceções**: Qualquer outra exceção resultará em `500 Internal Server Error`.