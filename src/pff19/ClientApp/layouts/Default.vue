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
import { mapGetters } from 'vuex'

export default {
    metaInfo() {
        return {
            titleTemplate: 'PFF FFS 19 %s',
            htmlAttrs: {
                lang: this.language,
                description:
                    this.language === 'de'
                        ? `«Mosaik» ist das Motto des PFF, das vom 30. August – 01. 
                            September 2019 in Stäfa (ZH) stattfindet. Während 3 Tagen versammeln sich zahlreiche Pfadis und 
                            ihre Freunde, um ein Openair der etwas anderen Art zu geniessen.`
                        : `« Mosaïque » c’est la devise du FFS, qui a lieu à Stäfa (ZH) du 30 août au 1er 
                            septembre 2019. Au cours de  3 jours nombreux scouts et leurs amis regroupent pour 
                            profiter d’un festival en plein air inoubliable.`
            }
        }
    },

    components: {
        NavMenu,
        AppFooter
    },

    computed: {
        ...mapGetters(['language'])
    }
}
</script>
