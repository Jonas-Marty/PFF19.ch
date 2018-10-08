<template>
    <transition name="bounce">  
        <nav class="navbar navbar-expand-md navbar-inverse position-fixed shadow-sm">
            <router-link class="navbar-brand" :to="{name: 'adminDashboard'}">
                <img  :class="{}" src="../../../assets/images/black_red_small_logo.png" height="40" class="d-inline-block align-top" alt="logo_pff19">
            </router-link>

            <button class="navbar-toggler" @click="collapse = !collapse" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                <span class="fa fa-navicon"></span>
            </button>

            <div class="collapse navbar-collapse" :class="{show: collapse}" id="navbarNavAltMarkup">
                <div class="navbar-nav ml-auto" >
                        <router-link
                                v-for="route in getAdminRoutes" :key="route.display"
                                v-if="route.important"
                                :to="{name: route.name}"
                                class="nav-item nav-link"
                        > {{ route.display }} </router-link>
                        <a
                        href="#"
                        class="nav-item nav-link"
                        @click="logout"
                        >
                            Log out
                        </a>
                     
                </div>
            </div>

        </nav>
    </transition>
</template>

<script>
import { routes } from '../../../routes';
import { mapActions } from 'vuex';

export default {
    data() {
        return {
            routes,
            collapse: false
        }
    },
    computed: {
        getAdminRoutes() {
            return routes.find(route => route.name === 'admin').children;
        },
        isHome() {
            return this.$store.getters.isHome;
        }
    },
    methods: {
        ...mapActions('api', [
            'logout'
        ]),

        toggleCollapsed (event) {
            this.collapsed = !this.collapsed;
        },
    },

}
</script>

<style lang="scss" scoped>
.navbar {
    color: black;
    background: white;
    width: 100%;
    z-index: 999;
    font-family: "Glacial Indifference Bold";
    text-transform: uppercase;
    position: absolute;
}


.navbar, .shadow-sm {
    transition:all 0.500s ease;
    -webkit-transition:all 0.500s ease;
    -moz-transition:all 0.500s ease;
    -o-transition:all 0.500s ease;
}


</style>
