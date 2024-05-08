# Índice de Documentação

Bem-vindo à documentação do projeto! Esta página serve como um ponto de partida para explorar as diferentes partes da documentação.

## Sumário

- [Introdução](#introdução)
- [Visão Geral do Projeto](#visão-geral-do-projeto)
- [Componentes](#componentes-de-word)
    - [Classes](#classes)
    - [Controladores](#controladores)
    - [Serviços](#serviços)
    - [Persistência](#persistência)
- [Documentação Geral](#documentação-geral)

## Introdução

Aqui você encontrará documentação detalhada sobre os diferentes aspectos do projeto. Use o sumário para navegar entre as seções ou clique nos links abaixo para acessar diretamente os documentos de interesse.

## Visão Geral do Projeto

O projeto WordLab é um aplicativo que auxilia os alunos no aprendizado de vocabulário em inglês. A aplicação está estruturada em várias camadas e componentes especializados para otimizar o processo de aprendizado.

### Arquitetura do Projeto

O projeto segue uma arquitetura em camadas, composta por:

- **Camada de Controle**: Lida com as interações com o usuário e encaminha solicitações para as camadas apropriadas.
- **Camada de Aplicação**: Contém a lógica de aplicação e orquestra chamadas entre a camada de controle e as outras camadas.
- **Camada de Domínio**: Abriga as classes de domínio, como `Word` e suas subclasses e a regra de negócio do aplicativo.
- **Camada de Persistência**: Lida com o armazenamento de dados e interações com o banco de dados.
- **Camada de Serviços Externos**: Gerencia a interação com APIs de terceiros para realizar verificações ortográficas, de pronúncia e recuperação de palavras. Essa camada facilita a integração com outros serviços, mantendo o sistema modular.
- **Camada de testes**:

### Principais Componentes

- **Classes**: O projeto define várias classes de domínio para representar palavras e suas características específicas, como `Word`, `PhoneticWord`, `ContextualWord`, e `GrammaticalWord`.
- **Controladores**: A camada de controle, por exemplo, `WordController`, gerencia as solicitações de entrada e saída, interagindo com a camada de aplicação.
- **Serviços**: Os serviços, como `WordApplication`, `WordService` e `WordExternalService`, lidam com a lógica de negócio, validação, classificação de palavras e interação com serviços externos.
- **Persistência**: A camada de persistência, por exemplo, `WordPersistence`, gerencia a interação com o banco de dados e o armazenamento de dados relacionados a palavras.

### Objetivo do Projeto

O WordLab oferece uma experiência personalizada para os usuários aprenderem vocabulário em inglês de forma mais eficaz e interativa. Ele permite a inserção de novas palavras de interesse, que são automaticamente classificadas com base em similaridade de pronúncia, contexto e tipos gramaticais.

Além disso, o WordLab adota métodos de memorização baseados em pesquisas para otimizar a retenção de palavras, incluindo repetição espaçada e prática ativa.

Essa estrutura de projeto garante que os usuários possam explorar as diferentes partes da documentação e entender como as diferentes camadas e componentes do WordLab interagem para proporcionar uma experiência de aprendizado eficaz.

## Componentes de `Word`

### Classes

- [Word](./word/Domain/Word.md)
- [PhoneticWord](./word/Domain/Word.md#PhoneticWord)
- [ContextualWord](./word/Domain/Word.md#ContextualWord)
- [GrammaticalWord](./word/Domain/Word.md#GrammaticalWord)

### Controladores

- [WordController](./word/controllers/WordController.md)

### Serviços

- [WordApplication](./word/services/WordApplication.md)
- [WordService](./word/services/WordService.md)
- [WordExternalService](./word/services/WordExternalService.md)

### Persistência

- [WordPersistence](./word/persistence/WordPersistence.md)

## Documentação Geral

- [Arquitetura](./general/architecture.md)
- [Configuração Inicial](./general/setup.md)
- [Diretrizes de Desenvolvimento](./general/guidelines.md)

---

Esperamos que essa documentação seja útil para você. Se tiver alguma dúvida ou precisar de mais informações, sinta-se à vontade para entrar em contato conosco ou consultar a documentação detalhada.
