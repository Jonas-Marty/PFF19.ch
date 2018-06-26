<template>
    <transition name="bounce">  
        <nav class="navbar navbar-expand-md navbar-inverse position-fixed shadow-sm" :class="{embedded: embedded && isHome && !navToggle}">
            <a class="navbar-brand" href="#" >
                <img  :class="{}" src="../../assets/images/black_green_small_logo.png" height="40" class="d-inline-block align-top" alt="">
            </a>

            <button class="navbar-toggler" @click="navToggle = !navToggle" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                <span class="fa fa-navicon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                <div class="navbar-nav ml-auto" >
                        <router-link
                            v-for="route in routes" :key="route.display"
                            :to="route.path"
                            class="nav-item nav-link"
                        > {{ route.display }}</router-link>
                     
                </div>
            </div>

        </nav>
    </transition>
</template>

<script>
import { routes } from '../../routes';

export default {
    data() {
        return {
            routes,
            collapsed : true,
            embedded: true,
            navToggle: false
        }
    },
    computed: {
        isHome() {
            return this.$store.getters.isHome;
        }
    },
    methods: {
        toggleCollapsed: function(event){
            this.collapsed = !this.collapsed;
        },
        navbarBackgroundController () {
            if(window.scrollY > 0){
                this.embedded = false;
            }else{
                this.embedded = true;
            }
        }
    },
    created () {
        window.addEventListener('scroll', this.navbarBackgroundController);
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
}


.navbar, .shadow-sm {
    transition:all 0.500s ease;
    -webkit-transition:all 0.500s ease;
    -moz-transition:all 0.500s ease;
    -o-transition:all 0.500s ease;
}

.embedded {
    color: white;
    background: none;
    box-shadow: none !important;
}

.embedded .navbar-brand {
    visibility: hidden;
}

.embedded .nav-item {
    color: white;
}

.embedded .navbar-toggler {
    color: white;
}



</style>
