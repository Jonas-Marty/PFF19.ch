import Vue from 'vue'
import VueRouter from 'vue-router'

import { routes, helperRoutes } from './routes'

Vue.use(VueRouter);

let router = new VueRouter({
    mode: 'history',
    routes,
    helperRoutes
})

export default router
