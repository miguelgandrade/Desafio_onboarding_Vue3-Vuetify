<script setup>
import Formulario_Bolsa from './componentes/Formulario_Bolsa.vue'
import Tabela_bolsas from './componentes/Tabela_bolsas.vue';

</script>

<template>
  <v-app>
    <v-main>
      <v-container>
        <h1>Sistema de bolsa</h1>
        <Formulario_Bolsa></Formulario_Bolsa>
        <Tabela_bolsas></Tabela_bolsas>
      </v-container>
    </v-main>
  </v-app>
</template>

<style scoped>
</style>