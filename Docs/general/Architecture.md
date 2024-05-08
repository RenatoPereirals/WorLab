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

Esta camada lida com as interações com os usuários, recebendo solicitações e retornando respostas apropriadas. Ela orquestra a comunicação com a camada de aplicação.

### **WordLab.Application**

A camada de aplicação atua como um ponto de coordenação entre a camada de controle (API) e a camada de domínio. Ela é responsável por processos de autenticação e permissão, além de lidar com serviços externos. Ela também encapsula os dados utilizando DTOs para transporte seguro e eficiente entre as camadas.

### **WordLab.Domain**

A camada de domínio abriga as classes de domínio que representam as entidades principais da aplicação (`Word`, `PhoneticWord`, `ContextualWord`, `GrammaticalWord`), suas interfaces para garantir o desacoplamento e a aplicação do Princípio de Inversão de Dependência (DIP), e as regras de negócio do projeto.

### **WordLab.Infrastructure**

Esta camada lida com a infraestrutura do projeto, como a persistência de dados e interações com o banco de dados, utilizando repositórios (`WordPersistence`) para gerenciar operações de armazenamento e recuperação de dados relacionados a palavras.

### **WordLab.ExternalService**

A camada de serviços externos gerencia a interação com APIs de terceiros para verificações ortográficas, de pronúncia e recuperação de palavras. Ela facilita a integração com outros serviços, mantendo o sistema modular.

### **WordLab.ExceptionHandling**

Esta camada é responsável por lidar com o tratamento de exceções de maneira padronizada em todo o sistema, garantindo que as exceções sejam tratadas corretamente e de forma consistente.

### **WordLab.Test**

A camada de testes compreende testes de integração, unidade e outros necessários para garantir que cada parte do sistema funcione corretamente e em conjunto.

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