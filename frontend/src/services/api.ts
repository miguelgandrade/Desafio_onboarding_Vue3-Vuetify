import axios from 'axios'

//Colocar inteceptor
const api = axios.create({
    baseURL: 'https://localhost:7213/api'
})

export default api