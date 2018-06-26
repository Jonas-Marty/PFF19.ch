import Vue from 'vue'
import VueRouter from 'vue-router'

import {routes, helperRoutes} from './routes'

Vue.use(VueRouter);

routes.concat(helperRoutes);

let router = new VueRouter({
    mode: 'history',
    routes,
})

export default router
