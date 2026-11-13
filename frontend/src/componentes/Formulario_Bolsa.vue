<script setup>
import { ref, computed,onMounted } from 'vue'
import { useBolsaStore } from '@/stores/bolsa'

const numero_matricula = ref("")
const valor_bolsa = ref(null)
const selecao = ref(null)
const data = ref(null)
const mensagem = ref(false)

const bolsa_store = useBolsaStore()

const validar_entrada_valor_bolsa = computed(() => {
  if (valor_bolsa.value > 0 && valor_bolsa.value != null && typeof valor_bolsa.value == 'number' &&
    Number.isFinite(valor_bolsa.value)) {
    return true
  } else {
    return false;
  }
})
const botao_desabilitado = computed(() => {
  if (numero_matricula.value.trim() != "" && selecao.value != null &&
    data.value != null && validar_entrada_valor_bolsa.value) {
    return false
  } else {
    return true
  }
})

function enviar_dados() {
  const nova_bolsa = {
    matricula: numero_matricula.value,
    tipo: selecao.value,
    data: data.value,
    valor: valor_bolsa.value
  }

  console.log("Dados enviados:", nova_bolsa)

  bolsa_store.adicionar_bolsa(nova_bolsa)

  console.log("Bolsas cadastradas:", bolsa_store.bolsas)

  numero_matricula.value = ""
  data.value = null
  selecao.value = null
  valor_bolsa.value = null

  mensagem.value = true
}

const tipo_bolsas = ref([])

async function carregarTipoBolsa() {
  console.log('Iniciando requisição à API...')

  try {
    const resposta = await fetch('https://localhost:7213/api/Bolsa')

    if (!resposta.ok) {
      throw new Error(`Erro HTTP: ${resposta.status}`)
    }

    tipo_bolsas.value = await resposta.json()

    console.log('Resposta recebida:', tipo_bolsas.value)
  } catch (erro) {
    console.error('Erro ao conectar com a API:', erro)
    tipo_bolsas.value = []
  }

  
}
onMounted(() => {
  carregarTipoBolsa()
})

</script>

<template>
  <div class="d-flex flex-column flex-md-row ga-4">
    <div class="flex-1-1">
      <v-text-field label="Numero Matricula" v-model="numero_matricula" />
    </div>

    <div class="flex-1-1">
      <v-select label="Seleção de Bolsa" :items="tipo_bolsas" v-model="selecao" />
    </div>
  </div>
  <div class="d-flex flex-column flex-md-row ga-4">
    <div class="flex-1-1">
      <v-number-input label="Valor Bolsa" v-model="valor_bolsa" :min="0" :precision="2" control-variant="stacked">
      </v-number-input>
    </div>

    <div class="flex-1-1">
      <v-date-input v-model="data"></v-date-input>
    </div>
  </div>

  <div class="d-flex justify-end">
    <v-btn color="primary" :disabled="botao_desabilitado" @click="enviar_dados">
      Inserir bolsa
    </v-btn>
  </div>
  <v-alert v-if="mensagem" type="success" class="mt-4">
    Bolsa cadastrada com sucesso!
  </v-alert>
</template>

<style scoped></style>