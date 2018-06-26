<template>
    <div id="app">
        <nav-menu params="route: route"></nav-menu>
        <router-view></router-view>
        <app-footer></app-footer>
    </div>

</template>

<script>
import Vue from 'vue'
import NavMenu from './partials/Header'
import Footer from './partials/Footer'

Vue.component('nav-menu', NavMenu);
Vue.component('app-footer', Footer);
</script>
