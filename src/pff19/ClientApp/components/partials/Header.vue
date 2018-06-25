<template>
    <transition name="bounce">  
        <nav class="navbar navbar-expand-md navbar-inverse position-fixed shadow-sm" :class="{background: active}">
            <a class="navbar-brand" href="#" >
                <img  :class="{}" src="../../assets/images/black_green_small_logo.png" height="30" class="d-inline-block align-top" alt="">
            </a>
            {{ active }}
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                <span class="fa fa-navicon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                <div class="navbar-nav">
                    <a class="nav-item nav-link active" href="#">Home <span class="sr-only">(current)</span></a>
                    <a class="nav-item nav-link" href="#">Features</a>
                    <a class="nav-item nav-link" href="#">Pricing</a>
                    <a class="nav-item nav-link disabled" href="#">Disabled</a>
                </div>
            </div>
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
            active: false
        }
    },
    methods: {
        toggleCollapsed: function(event){
            this.collapsed = !this.collapsed;
        },
        navbarBackgroundController () {
            if(window.scrollY > 0){
                this.active = true;
            }else{
                this.active = false;
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
