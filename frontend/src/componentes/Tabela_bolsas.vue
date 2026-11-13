<script setup>
import { useBolsaStore } from '@/stores/bolsa'

const bolsa_store = useBolsaStore()

const cabecalhos = [
    { title: 'Matrícula', key: 'matricula' },
    { title: 'Tipo de Bolsa', key: 'tipo' },
    { title: 'Valor', key: 'valor' },
    { title: 'Data', key: 'data' }
]

function formatar_data(data) {
    return new Intl.DateTimeFormat('pt-BR').format(new Date(data))
}

function formatar_valor(valor) {
    return new Intl.NumberFormat('pt-BR', {
        style: 'currency',
        currency: 'BRL'
    }).format(valor)
}
</script>

<template>
    <h2>Bolsas cadastradas</h2>
    <v-data-table
    :headers="cabecalhos" 
    :items="bolsa_store.bolsas"
    >
    <template #item.data="{ item }">
        {{ formatar_data(item.data) }}
    </template>

    <template #item.valor="{ item }">
    {{ formatar_valor(item.valor) }}
    </template>
        
    </v-data-table>
</template>