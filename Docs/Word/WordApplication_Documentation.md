### **WordApplication**

A `WordApplication` é responsável por coordenar a lógica de aplicação relacionada a palavras. Ela interage com a camada de domínio e lida com serviços externos, transportando dados entre a API e a lógica de aplicação.

#### **Construtor**

```csharp
public WordApplication(IWordService wordService,IExternalWordService externalWordService)
```
- **Descrição**: Inicializa uma nova instância da `WordApplication` com o serviço de palavras e o serviço externo fornecidos.

- **Parâmetros**:
  - `wordService`: Serviço de palavras para lidar com a lógica de domínio relacionada a palavras.
  - `externalWordService`: Serviço externo para interagir com APIs ou serviços de terceiros.

### **Métodos**

#### **`InsertWordAsync`**:

```csharp
public async Task<bool> InsertWordAsync(string word)
```
- **Descrição**: Insere uma nova palavra após validá-la localmente e verificar sua validade com um serviço externo.

- **Parâmetro**:
  - `word`: A palavra a ser inserida.

- **Retorna**: Um booleano indicando se a palavra foi inserida com sucesso.

- **Tratamento de erros**:
  - **Validação Local**: Valida se `word` é uma string válida (sem números ou caracteres especiais). Se a palavra for inválida, lança uma exceção `ArgumentException`.
  - **Serviço Externo**: Verifica a validade da palavra com um serviço externo. Se a palavra não passar na validação do serviço externo, lança uma exceção `ArgumentException`.
  - **Exceções**: Outras exceções resultam em lançamentos específicos para erros de aplicação.

#### **`GetAllWordsAsync`**:

```csharp
public async Task<List<string>> GetAllWordsAsync()
```
- **Descrição**: Recupera todas as palavras disponíveis.

- **Retorna**: Uma lista contendo todas as palavras.

- **Tratamento de erros**:
  - **Exceções**: Se ocorrer qualquer problema ao buscar palavras, lança uma exceção.

#### **`GetWordAsync`**:

```csharp
public async Task<string> GetWordAsync(string word)
```
- **Descrição**: Recupera uma palavra específica.

- **Parâmetro**:
  - `word`: A palavra a ser recuperada.

- **Retorna**: A palavra especificada, se encontrada.

- **Tratamento de erros**:
  - **Não encontrada**: Se a palavra não for encontrada, lança uma exceção `ArgumentException`.
  - **Exceções**: Outras exceções resultam em lançamentos específicos para erros de aplicação.

#### **`UpdateWordAsync`**:

```csharp
public async Task<bool> UpdateWordAsync(string word, Word updatedWord)
```
- **Descrição**: Atualiza uma palavra existente com base nas informações de `updatedWord`.

- **Parâmetros**:
  - `word`: A palavra existente a ser atualizada.
  - `updatedWord`: O objeto `Word` contendo as novas informações para atualizar a palavra existente.

- **Retorna**: Um booleano indicando se a palavra foi atualizada com sucesso.

- **Tratamento de erros**:
  - **Não encontrada**: Se a palavra não for encontrada, lança uma exceção `ArgumentException`.
  - **Validação Local**: Valida se `updatedWord` é uma string válida (sem números ou caracteres especiais). Se `updatedWord` for inválido, lança uma exceção `ArgumentException`.
  - **Serviço Externo**: Verifica a validade de `updatedWord` com um serviço externo. Se não passar, lança uma exceção `ArgumentException`.
  - **Exceções**: Outras exceções resultam em lançamentos específicos para erros de aplicação.

#### **`DeleteWordAsync`**:

```csharp
public async Task<bool> DeleteWordAsync(string word)
```
- **Descrição**: Exclui uma palavra específica.

- **Parâmetro**:
  - `word`: A palavra a ser excluída.

- **Retorna**: Um booleano indicando se a palavra foi excluída com sucesso.

- **Tratamento de erros**:
  - **Não encontrada**: Se `word` não for encontrada, lança uma exceção `ArgumentException`.
  - **Exceções**: Outras exceções resultam em lançamentos específicos para erros de aplicação.