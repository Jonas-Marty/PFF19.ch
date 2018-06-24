<template>
    <div>
        <app-slideshow> </app-slideshow>
        <div class="container">
            <app-news-list></app-news-list>
        </div>
        <app-social-media></app-social-media>
        <app-sponsors></app-sponsors>
    </div>
</template>

<script>
import Vue from 'vue';
import Slideshow from './Slideshow';
import NewsList from './news/NewsList.vue';
import SocialMedia from './SocialMedia.vue';
import Sponsor from './Sponsor';

Vue.component('app-slideshow', Slideshow);
Vue.component('app-news-list', NewsList);
Vue.component('app-social-media', SocialMedia);
Vue.component('app-sponsors', Sponsor)

export default {
    data() {
        return {
        }
    },
}
</script>

<style>
</style>
