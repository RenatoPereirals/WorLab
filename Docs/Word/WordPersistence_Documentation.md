### **WordPersistence**

A `WordPersistence` é responsável pela persistência de dados para a entidade `Word`. Ela lida com operações de armazenamento, recuperação, atualização e exclusão de palavras.

#### **Construtor**

```csharp
public WordPersistence(DbContext dbContext)
```
- **Descrição**: Inicializa uma nova instância de `WordPersistence` com o contexto de banco de dados fornecido.

- **Parâmetro**:
  - `dbContext`: Contexto de banco de dados utilizado pela `WordPersistence` para acessar o banco de dados.

### **Métodos**

#### **`AddWordAsync`**:

```csharp
public async Task AddWordAsync(Word word)
```
- **Descrição**: Adiciona uma nova palavra ao banco de dados.

- **Parâmetro**:
  - `word`: A palavra a ser adicionada.

- **Tratamento de erros**:
  - **Duplicação**: Se a palavra já existir no banco de dados, lança uma exceção `InvalidOperationException`.
  - **Exceções**: Outras exceções resultam em lançamentos específicos para erros de persistência.

#### **`GetWordByIdAsync`**:

```csharp
public async Task<Word> GetWordByIdAsync(int id)
```
- **Descrição**: Recupera uma palavra específica pelo seu identificador.

- **Parâmetro**:
  - `id`: O identificador da palavra a ser recuperada.

- **Retorna**: A palavra encontrada, ou `null` se não for encontrada.

- **Tratamento de erros**:
  - **Não encontrada**: Se a palavra não for encontrada, lança uma exceção `KeyNotFoundException`.

#### **`GetAllWordsAsync`**:

```csharp
public async Task<List<Word>> GetAllWordsAsync()
```
- **Descrição**: Recupera todas as palavras do banco de dados.

- **Retorna**: Uma lista contendo todas as palavras.

- **Tratamento de erros**:
  - **Exceções**: Outras exceções resultam em lançamentos específicos para erros de persistência.

#### **`UpdateWordAsync`**:

```csharp
public async Task UpdateWordAsync(Word word)
```
- **Descrição**: Atualiza uma palavra existente no banco de dados.

- **Parâmetro**:
  - `word`: O objeto `Word` contendo as informações atualizadas.

- **Tratamento de erros**:
  - **Não encontrada**: Se `word` não existir no banco de dados, lança uma exceção `KeyNotFoundException`.
  - **Exceções**: Outras exceções resultam em lançamentos específicos para erros de persistência.

#### **`DeleteWordAsync`**:

```csharp
public async Task DeleteWordAsync(int id)
```
- **Descrição**: Exclui uma palavra específica pelo seu identificador.

- **Parâmetro**:
  - `id`: O identificador da palavra a ser excluída.

- **Tratamento de erros**:
  - **Não encontrada**: Se `word` não for encontrada no banco de dados, lança uma exceção `KeyNotFoundException`.
  - **Exceções**: Outras exceções resultam em lançamentos específicos para erros de persistência.