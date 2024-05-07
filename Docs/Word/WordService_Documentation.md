### **WordService**

A `WordService` é responsável por lidar com entidades de domínio relacionadas a palavras. Ela contém regras de negócio, validações e operações específicas para manipular palavras.

#### **Construtor**

```csharp
public WordService(IWordRepository wordRepository)
```
- **Descrição**: Inicializa uma nova instância da `WordService` com o repositório fornecido.

- **Parâmetro**:
  - `wordRepository`: Repositório de palavras usado pela `WordService` para operações de persistência.

### **Métodos**

#### **`AddWord`**:

```csharp
public void AddWord(Word word)
```
- **Descrição**: Adiciona uma nova palavra ao repositório, após validar suas propriedades.

- **Parâmetro**:
  - `word`: A palavra a ser adicionada.

- **Tratamento de erros**:
  - **Validação**: Verifica se `word` atende às regras de negócio (por exemplo, não contém caracteres especiais). Se `word` for inválida, lança uma exceção `ArgumentException`.
  - **Duplicação**: Verifica se `word` já existe no repositório. Se já existir, lança uma exceção `InvalidOperationException`.

#### **`GetWordById`**:

```csharp
public Word GetWordById(int id)
```
- **Descrição**: Recupera uma palavra específica pelo seu identificador.

- **Parâmetro**:
  - `id`: O identificador da palavra a ser recuperada.

- **Retorna**: A palavra encontrada, ou `null` se não for encontrada.

- **Tratamento de erros**:
  - **Não encontrada**: Se a palavra não for encontrada, lança uma exceção `KeyNotFoundException`.

#### **`UpdateWord`**:

```csharp
public void UpdateWord(Word word)
```
- **Descrição**: Atualiza uma palavra existente com base nas novas informações fornecidas.

- **Parâmetro**:
  - `word`: O objeto `Word` contendo as informações atualizadas.

- **Tratamento de erros**:
  - **Não encontrada**: Se `word` não existir, lança uma exceção `KeyNotFoundException`.
  - **Validação**: Verifica se as novas informações de `word` são válidas. Se não forem, lança uma exceção `ArgumentException`.

#### **`DeleteWord`**:

```csharp
public void DeleteWord(int id)
```
- **Descrição**: Exclui uma palavra específica pelo seu identificador.

- **Parâmetro**:
  - `id`: O identificador da palavra a ser excluída.

- **Tratamento de erros**:
  - **Não encontrada**: Se a palavra não for encontrada, lança uma exceção `KeyNotFoundException`.