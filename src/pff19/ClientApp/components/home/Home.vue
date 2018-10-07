<template>
    <div>
        <app-slideshow> </app-slideshow>
        <app-news-list></app-news-list>
        <app-social-media></app-social-media>

    </div>
</template>

<script>
import Vue from 'vue';

import Slideshow from './slideshow/Slideshow';
import NewsList from './news/NewsList.vue';
import SocialMedia from './SocialMedia.vue';
import Sponsor from './Sponsor';
import Bands from './BandsRegistration'

import { mapActions } from 'vuex';


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
    },

    components: {
        'app-slideshow': Slideshow,
        'app-news-list': NewsList,
        'app-social-media': SocialMedia,
        'app-sponsors': Sponsor,
        'app-bands': Bands
    }
}
</script>

<style>
</style>