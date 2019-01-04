<template>
    <div class="container">
        <h1>Alle News</h1>
        <div class="row">
            <app-news v-for="news in all" :key="news.id" :news="news"></app-news>
        </div>
    </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import axios from 'axios'

import News from './NewsThumpnail'
import NUMBER_OF_NEWS_ON_HOMEPAGE from '../../constants/main'

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
       ...mapGetters('news',[
           'all'
       ])
    },

    created() {
         if(!(this.all.length > NUMBER_OF_NEWS_ON_HOMEPAGE)){
            this.load()
        }
    },

    components: {
        'app-news': News
    }
}
</script>

<style lang="scss" scoped>
    .container {
        padding-top: 100px;
    }
</style>
