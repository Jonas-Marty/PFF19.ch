<template>
    <div id="app">
        <nav-menu params="route: route"></nav-menu>
            <router-view></router-view>
        <app-footer></app-footer>
    </div>

</template>

<script>
import NavMenu from '../components/partials/Header.vue' 
import AppFooter from '../components/partials/Footer.vue' 

export default {
    components: {
        NavMenu,
        AppFooter
    }
}
</script>
