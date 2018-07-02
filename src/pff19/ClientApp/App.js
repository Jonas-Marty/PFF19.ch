import Vue from 'vue'
import axios from 'axios'
import router from './router'
import { store } from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import i18n from './locales'
 
Vue.prototype.$http = axios;

sync(store, router);

const lang = store.state.language
if (lang) {
	i18n.locale = lang
}

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