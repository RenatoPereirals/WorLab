# Architecture

### Índice

- [Aspectos de Arquitetura](#aspectos-de-arquitetura)
    - [Aspectos Permanentes](#aspectos-permanentes)
    - [Estratégia para Autorizar Mudanças](#estratégia-para-autorizar-mudanças)
    - [Metas e Restrições de Arquitetura](#metas-e-restrições-de-arquitetura)
    - [Visões e Perspectivas de Arquitetura](#visões-e-perspectivas-de-arquitetura)
- [Estrutura Atual](#estrutura-atual)
    - [WordLab.API](#wordlabapi)
    - [WordLab.Application](#wordlabapplication)
    - [WordLab.Domain](#wordlabdomain)
    - [WordLab.Infrastructure](#wordlabinfrastructure)
    - [WordLab.ExternalService](#wordlabexternalservice)
    - [WordLab.ExceptionHandling](#wordlabexceptionhandling)
    - [WordLab.Test](#wordlabtest)
- [Componentes de Software](#componentes-de-software)
    - [Arranjo em Subsistemas e Componentes](#arranjo-em-subsistemas-e-componentes)
    - [Interfaces Internas e Externas](#interfaces-internas-e-externas)
    - [Detalhes dos Componentes de Software](#detalhes-dos-componentes-de-software)
- [Registro de Rastreabilidade](#registro-de-rastreabilidade)
- [Premissas e Funcionalidades Esperadas](#premissas-e-funcionalidades-esperadas)
- [Problema que Queremos Resolver](#problema-que-queremos-resolver)
- [Tecnologias para Solucionar o Problema](#tecnologias-para-solucionar-o-problema)
- [Validação de Requisitos](#validação-de-requisitos)
- [Diagrama de Implantação](#diagrama-de-implantação)
- [Fundamentação de Decisões de Desenvolvimento](#fundamentação-de-decisões-de-desenvolvimento)
- [Cenários de Uso](#cenários-de-uso)
- [Organograma e Descrição de Componentes](#organograma-e-descrição-de-componentes)

## Aspectos de Arquitetura

### Aspectos Permanentes

[Defina e documente os aspectos permanentes da arquitetura do projeto, incluindo atributos de qualidade e restrições que permanecerão verdadeiros por mais tempo.]

Os aspectos permanentes da arquitetura do projeto WordLab incluem a necessidade de manter uma estrutura modular e bem organizada, com camadas que promovem a separação de responsabilidades e a flexibilidade para atualizações futuras. Os atributos de qualidade, como desempenho, segurança e escalabilidade, são mantidos através do uso de boas práticas de desenvolvimento.

### Estratégia para Autorizar Mudanças

[Descreva a estratégia para autorizar mudanças na arquitetura ou no projeto, incluindo processos de revisão, aprovação e comunicação de mudanças.]

### Metas e Restrições de Arquitetura

[Documente as metas de arquitetura e as restrições que guiam o desenvolvimento do projeto.]

As metas da arquitetura do projeto incluem a entrega de um sistema robusto, seguro e eficiente, capaz de fornecer uma experiência de usuário satisfatória e promover o aprendizado do vocabulário em inglês. As restrições incluem o respeito às normas de segurança e privacidade de dados, além de otimizar o desempenho e escalabilidade do sistema.

### Visões e Perspectivas de Arquitetura

[Apresente diferentes visões e perspectivas da arquitetura para abordar vários aspectos do projeto, como desempenho, segurança e escalabilidade.]

As visões de arquitetura do projeto WordLab abordam diferentes aspectos do sistema, como desempenho, segurança e escalabilidade. Essas visões incluem a separação em camadas para organizar as responsabilidades do sistema e manter uma arquitetura flexível e modular.

## Estrutura Atual

### **WordLab.API**

Esta camada atuará como a interface com o usuário ou sistema cliente. Ela conterá os endpoints que receberão as requisições HTTP e responderão a elas. É a camada mais externa e lida diretamente com as solicitações e respostas da web.

### **WordLab.Application**

Esta camada servirá como um mediador entre a camada de API e as camadas de domínio e serviços externos. Ela conterá a lógica de aplicação e coordenará as operações entre as camadas de domínio e infraestrutura/serviços externos.

### **WordLab.Domain**

Esta camada conterá a lógica de negócios e as entidades do domínio. Ela define as regras de negócio e as operações que podem ser realizadas no sistema.

### **WordLab.Infrastructure**

Esta camada lidará com todos os aspectos da persistência de dados, como acesso ao banco de dados, repositórios, etc. Ela fornecerá os meios para que as outras camadas interajam com o banco de dados.

### **WordLab.ExternalService**

Esta camada será responsável por integrar e comunicar-se com serviços externos, como APIs de terceiros. Ela abstrairá as chamadas a esses serviços e fornecerá uma interface limpa para a camada de aplicação.

### **WordLab.ExceptionHandling**

Esta camada será responsável por gerenciar e centralizar o tratamento de exceções em todo o projeto. Isso pode incluir a definição de políticas de exceção personalizadas, manipuladores de exceção e a lógica para decidir quando e como as exceções devem ser registradas ou propagadas.

### **test**

A camada de testes colocará todos os testes unitários, testes de integração e possivelmente testes de sistema/end-to-end. Esta camada é crucial para garantir que a aplicação funcione como esperado e para detectar regressões ou problemas antes que eles afetem os usuários finais ou a produção.

### **Estrutura do Sistema**
A estrutura atual do sistema WordLab é composta por camadas separadas, cada uma com suas responsabilidades específicas. As camadas incluem a camada de controle, aplicação, domínio, serviços externos, persistência e testes.

### **Contexto ou Escopo do Sistema**
O sistema WordLab é um aplicativo de aprendizado de vocabulário em inglês que auxilia estudantes de inglês a aprender novas palavras e seus significados, além de praticar pronúncia e gramática. Ele se integra com APIs de terceiros para realizar verificações ortográficas e de pronúncia.

### **Diagramas de Componentes**
Os diagramas de componentes devem ilustrar as partes principais do sistema e suas interações, como controladores, serviços de aplicação, classes de domínio, serviços externos, camadas de persistência e testes.

### **Diagramas de Sequência**
Os diagramas de sequência devem mostrar como as solicitações e respostas fluem entre os componentes do sistema. Isso inclui o fluxo de dados entre controladores, serviços de aplicação e serviços externos.

## Componentes de Software

### Arranjo em Subsistemas e Componentes

[Descreva como o sistema é organizado em subsistemas e componentes, com base nas camadas acima.]

### Interfaces Internas e Externas

[Explique as interfaces internas e externas dos componentes de software, especialmente nas camadas de controle, aplicação e domínio.]

### Detalhes dos Componentes de Software

[Descreva os componentes de software, incluindo suas responsabilidades, funcionalidades e interações.]

## Registro de Rastreabilidade

[Documente o registro de rastreabilidade para acompanhar requisitos e funcionalidades ao longo do projeto.]

## Premissas e Funcionalidades Esperadas

[Liste as premissas feitas durante o desenvolvimento e as funcionalidades esperadas.]

## Problema que Queremos Resolver

[Descreva o problema que o projeto pretende resolver.]

## Tecnologias para Solucionar o Problema

[Liste as tecnologias utilizadas para resolver o problema.]

## Validação de Requisitos

[Explique como os requisitos são validados para garantir que o sistema atenda às necessidades dos usuários.]

## Diagrama de Implantação

[Forneça diagramas de implantação para ilustrar a configuração de hardware e software do sistema.]

## Fundamentação de Decisões de Desenvolvimento

[Documente a fundamentação para decisões tomadas durante o desenvolvimento, como a escolha de tecnologias ou arquiteturas.]

## Cenários de Uso

[Descreva os cenários de uso do sistema para ilustrar como ele é utilizado em diferentes situações.]

## Organograma e Descrição de Componentes

[Adicione um organograma ou diagrama de blocos que descreva a estrutura do sistema e seus componentes.]