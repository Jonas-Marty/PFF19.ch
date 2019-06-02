<template>
    <div class="news-list container">
        <div class="row">
            <app-news v-for="news in firstThree" :key="news.id" :news="news"></app-news>
        </div>
        <div class="float-right">
            <router-link :to="{ name: 'newsOverview' }" class>
                {{ $t('lang.components.home.news.further_news') }}
            </router-link>
        </div>
    </div>
</template>

<script>
import Vue from 'vue'
import axios from 'axios'
import { mapActions, mapGetters } from 'vuex'

import News from '../../news/NewsThumpnail'
import NUMBER_OF_NEWS_ON_HOMEPAGE from '../../../constants/main'

export default {
    data() {
        return {
            newsList: []
        }
    },

    methods: {
        ...mapActions('news', ['loadTopThree'])
    },

    computed: {
        ...mapGetters('news', ['all', 'firstThree'])
    },

    created() {
        if (!(this.all.length >= NUMBER_OF_NEWS_ON_HOMEPAGE)) {
            this.loadTopThree()
        }
    },

    components: {
        'app-news': News
    },

    beforeUpdate() {
        return this.newsList[this.$store.getters.language]
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
