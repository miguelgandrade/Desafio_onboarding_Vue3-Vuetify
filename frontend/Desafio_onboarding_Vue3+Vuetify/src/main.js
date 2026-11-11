import { createApp } from 'vue'
import App from './App.vue'

// Importa o Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'


import { createPinia } from 'pinia'

// Cria a instância do Vuetify
const vuetify = createVuetify({
  components,
  directives,
})


const app = createApp(App)
const pinia = createPinia()

app.use(vuetify)
app.use(pinia)

// Inicia a aplicação
app.mount('#app')