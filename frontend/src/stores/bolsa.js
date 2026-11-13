import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useBolsaStore = defineStore('bolsa', () => {

    const bolsas = ref([])

    function adicionar_bolsa(nova_bolsa) {
    bolsas.value.push(nova_bolsa)
    }

    return {
        bolsas,
        adicionar_bolsa
    }
})