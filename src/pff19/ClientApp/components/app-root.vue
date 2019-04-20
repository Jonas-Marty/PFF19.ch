<template>
    <div id="app">
        <router-view></router-view>
    </div>
</template>

<script>
import Vue from 'vue'
import NavMenu from './partials/Header'
import Footer from './partials/Footer'

Vue.component('nav-menu', NavMenu)
Vue.component('app-footer', Footer)
</script>
