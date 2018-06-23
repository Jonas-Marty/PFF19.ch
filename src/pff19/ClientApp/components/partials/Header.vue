<template>
    <transition name="fade">  
        <nav class="navbar navbar-inverse position-fixed" :class="{background: background}" >
            <a class="navbar-brand" href="#">Navbar</a>
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
}

.background {
    color: black;
    background: white;
}


</style>
