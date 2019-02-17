<template>
    <transition name="bounce">  
        <nav class="navbar navbar-expand-md navbar-inverse position-fixed shadow-sm" :class="{embedded: embedded && isHome && !collapse}">
            <router-link class="navbar-brand" :to="{name: 'home'}">
                <img  :class="{}" src="../../assets/images/black_green_small_logo.png" height="40" class="d-inline-block align-top" alt="logo_pff19">
            </router-link>

            <div class="mr-auto nav-link">
                <a class="nav-item language" @click="changeLang('de')">de</a> <span class="nav-item">|</span>
                <a class="nav-item language" @click="changeLang('fr')">fr</a>
            </div>


            <button class="navbar-toggler" @click="collapse = !collapse" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                <span class="fa fa-navicon"></span>
            </button>

            <div class="collapse navbar-collapse" :class="{show: collapse}" id="navbarNavAltMarkup">
                <div class="navbar-nav ml-auto" >
                    <span 
                        class="nav-item"
                        v-for="route in getDefaultRoutes" :key="route.display"
                    >
                        <router-link
                                v-if="route.important"
                                :to="route.path"
                                class="nav-link"
                        > {{ $t(`lang.navigation.${route.name}`) }}</router-link>
                    </span> 
                </div>
            </div>

        </nav>
    </transition>
</template>

<script>
import { routes } from '../../routes';
import i18n from '../../locales';
import { mapActions } from 'vuex';

export default {
    data() {
        return {
            routes,
            embedded: true,
            collapse: false
        }
    },
    computed: {
        isHome() {
            return this.$store.getters.isHome;
        },

        getDefaultRoutes(){
            return this.routes.find(route => route.name === 'default').children
        }
    },
    methods: {
        ...mapActions([
            'switchI18n',
        ]),

        toggleCollapsed (event) {
            this.collapsed = !this.collapsed;
        },
        navbarBackgroundController () {
            if(window.scrollY > 0){
                this.embedded = false;
            }else{
                this.embedded = true;
            }
        },
        changeLang (lang) {
            if(this.$store.getters.language !== lang){
                this.switchI18n(lang);
            }
        },
    },
    created () {
        window.addEventListener('scroll', this.navbarBackgroundController);

        let self = this;

        window.addEventListener('click', function(e){

            // close dropdown when clicked outside
            if (!self.$el.contains(e.target) || self.$el.contains(e.target) && e.target.tagName === 'A'){
            self.collapse = false
            } 
        })
    },

    destroyed () {
        window.removeEventListener('scroll', this.navbarBackgroundController);
    }
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

.embedded .nav-link {
    color: white;
}

.language {
    cursor: pointer;
}

.embedded .navbar-toggler {
    color: white;
}



</style>
