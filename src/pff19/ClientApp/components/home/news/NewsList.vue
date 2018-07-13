<template>
    <div class="news-list container">
        <div class="row">
            <app-news v-for="news in newsList" :key="news.id" :news="news"> </app-news>
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
import News from './News';
import axios from 'axios';

export default {
    data () {
        return {
            newsList: []
        }
    },

    created() {
        axios.get('/api/news')
        .then(response => {
            this.newsList = response.data;
            console.log(response.data);
        }).catch(e => {
            this.errors.push(e)
        });
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
    }

    @media (min-width: 400px) { 
        .news-list {
            margin-top: 30px;
        }
    }

    @media (min-width: 768px) { 
    .news-list {
        margin-top: -250px;
        }
    }
</style>
