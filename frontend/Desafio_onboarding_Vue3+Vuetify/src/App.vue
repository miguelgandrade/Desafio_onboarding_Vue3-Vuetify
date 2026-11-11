<script setup>
import { onMounted, ref } from 'vue';
import Formulario_Bolsa from './componentes/Formulario_Bolsa.vue'
import Tabela_bolsas from './componentes/Tabela_bolsas.vue';

const mensagemApi = ref('Carregando...')

async function testarApi() {
  console.log('Iniciando requisição à API...')

  try {
    const resposta = await fetch('https://localhost:7213/api/Bolsa')

    if (!resposta.ok) {
      throw new Error(`Erro HTTP: ${resposta.status}`)
    }

    mensagemApi.value = await resposta.text()

    console.log('Resposta recebida:', mensagemApi.value)
  } catch (erro) {
    console.error('Erro ao conectar com a API:', erro)
    mensagemApi.value = 'Erro ao conectar com a API'
  }

  
}
onMounted(() => {
  testarApi()
})

</script>

<template>
  <v-app>
    <v-main>
      <v-container>
        <h1>Sistema de bolsa</h1>
        <Formulario_Bolsa></Formulario_Bolsa>
        <Tabela_bolsas></Tabela_bolsas>
        <p>Resposta do backend: {{ mensagemApi }}</p>
      </v-container>
    </v-main>
  </v-app>
</template>

<style scoped>
</style>