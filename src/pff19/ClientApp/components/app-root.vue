<template>
    <div id="app">
        <nav-menu params="route: route"></nav-menu>
        <router-view></router-view>
        <app-footer></app-footer>
    </div>

</template>

<script>
import Vue from 'vue'
import CounterExample from './counter-example'
import FetchData from './fetch-data'
import HomePage from './home/Home'
import NavMenu from './partials/Header'
import Footer from './partials/Footer'

Vue.component('counter-example', CounterExample);
Vue.component('fetch-data', FetchData);
Vue.component('home-page', HomePage);
Vue.component('nav-menu', NavMenu);
Vue.component('app-footer', Footer);

export default {
    data() {
        return {
        }
    },

}
</script>

<style>
</style>