<template>
    <transition name="bounce">  
        <nav class="navbar navbar-inverse position-fixed shadow-sm" :class="{background: background}">
            <a class="navbar-brand" href="#" >
                <img  v-if="background" src="../../assets/images/black_green_small_logo.png" height="30" class="d-inline-block align-top" alt="">
            </a>
            {{ background }}
        </nav>
    </transition>
</template>

<script>
import { routes } from '../../routes'

export default {
    data() {
        return {
            routes,
            collapsed : true,
            background: false
        }
    },
    methods: {
        toggleCollapsed: function(event){
            this.collapsed = !this.collapsed;
        },
        navbarBackgroundController () {
            if(window.scrollY > 0){
                this.background = true;
            }else{
                this.background = false;
            }
        }
    },
    created () {
        window.addEventListener('scroll', this.navbarBackgroundController);
    }
}
</script>

<style lang="scss" scoped>
.navbar {
    color: white;
    width: 100%;
    z-index: 999;
}

.navbar, .shadow-sm {
    transition:all 0.500s ease;
    -webkit-transition:all 0.500s ease;
    -moz-transition:all 0.500s ease;
    -o-transition:all 0.500s ease;
}

.background {
    color: black;
    background: white;
}

</style>
