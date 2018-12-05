import Vue from 'vue'
import axios from 'axios'
import router from './router'
import { store } from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import i18n from './locales'
import './filters'
import Vuelidate from 'vuelidate'
import VueAnalytics from 'vue-analytics'
import Polygon from 'components/partials/Polygon.vue'

Vue.use(VueAnalytics, {
  id: 'UA-123742823-1',
  autoTracking: {
    screenview: true
  }
})

Vue.use(Vuelidate)

Vue.prototype.$http = axios

sync(store, router)

const lang = store.state.language
if (lang) {
  i18n.locale = lang
}

axios.defaults.headers.get['Accepts'] = 'application/json'

Vue.component('app-polygon', Polygon) // component name should be in camel-case

const app = new Vue({
  store,
  router,
  i18n,
  ...App
})

export {
  app,
  router,
  store,
  i18n
}
