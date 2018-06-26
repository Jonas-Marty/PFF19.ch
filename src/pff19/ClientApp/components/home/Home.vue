<template>
    <div>
        <app-slideshow> </app-slideshow>
        <app-news-list></app-news-list>
        <app-social-media></app-social-media>
        <app-sponsors></app-sponsors>
    </div>
</template>

<script>
import Vue from 'vue';
import Slideshow from './slideshow/Slideshow';
import NewsList from './news/NewsList.vue';
import SocialMedia from './SocialMedia.vue';
import Sponsor from './Sponsor';
import { mapActions } from 'vuex';

Vue.component('app-slideshow', Slideshow);
Vue.component('app-news-list', NewsList);
Vue.component('app-social-media', SocialMedia);
Vue.component('app-sponsors', Sponsor)

export default {
    data() {
        return {
        }
    },

    methods: {
        ...mapActions([
            'enterHome',
            'leaveHome'
        ])
    },

    mounted () {
        this.enterHome();
    },
    beforeDestroy () {
        this.leaveHome();
    }
}
</script>

<style>
</style>