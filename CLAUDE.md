# CLAUDE.md — ApiBolsas (desafio de treinamento)

> Exemplo inicial. Itens marcados com `TODO` são suposições: ajuste ao que existe no seu repositório.

## Sobre o projeto

Desafio do treinamento passado pelo Gabriel (mentor). É um cadastro de bolsas com duas partes:

- `backend/`: API .NET chamada **ApiBolsas**, criada no Visual Studio 2026.
  - `BolsaController` expõe `GET` (sem parâmetros), que retorna o array de opções de bolsa.
  - `BolsaService` inicializa as 3 opções: "Bolsa Matrícula", "Parcelamento da Matrícula" e "Bolsa Mensalidade".
  - O Swagger fica habilitado para testar o controller.
- `frontend/`: Vue 3 com Vuetify 3 e Pinia.
  - O formulário de cadastro de bolsa fica num componente próprio, com os campos Número Matrícula, tipo de bolsa (select), Valor Bolsa (numérico e obrigatório), data (date-input) e o botão "Inserir Bolsa".
  - Uma store Pinia guarda as bolsas inseridas. O formulário grava na store e limpa os campos.
  - Um componente de tabela (Vuetify data table) lê a store e lista as bolsas cadastradas.
  - O select de tipos de bolsa é preenchido pelo retorno do `GET` da ApiBolsas.

## Comandos

```bash
# Backend (no Visual Studio, abra backend/ApiBolsas.slnx)
cd backend/ApiBolsas
dotnet restore
dotnet build
dotnet run --launch-profile https   # Swagger em https://localhost:7213/swagger
dotnet test         # TODO: só se houver um projeto de testes

# Frontend (TODO: confirme se usa npm e Vite)
cd frontend
npm install
npm run dev
npm run build
npm run lint        # TODO: só se o script existir
```

## Convenções

- Escreva o código e os nomes em inglês ou português de forma consistente com o que já existe. TODO: defina a escolha.
- No frontend, use a Composition API (`<script setup>`) e componentes pequenos. O `App.vue` só compõe os componentes, sem regra de negócio.
- O estado compartilhado fica no Pinia, e não em props passadas por vários níveis.
- No backend, o controller fica fino e a lógica vai para o service.
- Valores fixos, como as opções de bolsa, ficam num único lugar no backend. O frontend nunca duplica essa lista.

## Como trabalhar comigo neste repositório

- Antes de mudar qualquer coisa, explique o plano e liste os arquivos que vão mudar.
- Faça mudanças pequenas e mostre o diff de cada uma.
- Depois de mudar o backend, rode `dotnet build`. Depois de mudar o frontend, rode `npm run build`.
- Não faça commit nem push sem o meu ok. As mensagens de commit são em português e no imperativo, como "Adiciona store de bolsas".
- O repositório é público: nunca coloque senhas, tokens ou dados reais de alunos no código ou neste arquivo.

## Contexto

- Este repositório é só para o treinamento. Não tem relação com o código do Conceder nem com o AnimaCodeHub.
- O Gabriel revisa as entregas pelo GitHub.
