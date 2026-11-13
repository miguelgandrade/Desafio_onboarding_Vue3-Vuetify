import api from './api'

export async function buscarTipoBolsa() {
    const { data } = await api.get('/Bolsa/tipos')
    return data 
}      