import { createApp } from 'vue'
import App from './App.vue'
import {router} from './router/router'
import './globalComponents'

const app = createApp(App);
//Sử dụng global component

//Sử dụng router
app.use(router)
app.mount('#app');