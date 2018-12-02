<template>
    <div class="news-list container">
        <div class="row">
            <app-news v-for="news in firstThree" :key="news.id" :news="news"> </app-news>
        </div>
            <div class="float-right">
                <router-link
                    :to="{name: 'news_overview'}"
                    class=""
                > {{ $t('lang.components.home.news.further_news') }}</router-link>
            </div>
    </div>
</template>

<script>
import Vue from 'vue';
import News from '../../news/NewsThumpnail';
import axios from 'axios';
import { mapActions, mapGetters } from 'vuex'

export default {
    data () {
        return {
            newsList: []
        }
    },

    methods: {
        ...mapActions('news', [
            'load'
        ]),
    }, 

    computed: {
        ...mapGetters('news', [
            'all',
            'firstThree'
        ])
    },

    created() {
        if(!(this.all.length > 0)){
            this.load()
        }
    },


    components: {
        'app-news': News
    },

    beforeUpdate () {
        return this.newsList[this.$store.getters.language];
    }

}
</script>

<style lang="scss" scoped>
    .news-list {
        margin-top: -250px;
        min-height: 300px;
        z-index: 2;
    }

    @media (max-width: 768px) { 
        .news-list {
            margin-top: -150px;
        }
    }

</style>
