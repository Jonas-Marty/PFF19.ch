<template>
    <div class="news-list container">
        <div class="row">
            <app-news v-for="news in newsListLang" :key="news.id" :news="news"> </app-news>
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

export default {
    data () {
        return {
            newsList: {
                "de": 
                [
                    {
                        id: 1, 
                        date: "Thu Jun 21 20:53:17 2018 UTC", 
                        title: "Der Aufbau beginnt", 
                        short: "Bacon ipsum dolor amet porchetta meatloaf prosciutto,\
                        kevin rump turducken jerky picanha jowl doner tenderloin shank\
                        frankfurter. Ground round burgdoggen venison ham biltong",
                        image: "beer_sunset"
                    },
                    {
                        id: 2, 
                        date: "Thu Jun 21 20:53:17 2018 UTC", 
                        title: "1000 Tickets wurden verkauft", 
                        short: "Bacon ipsum dolor amet porchetta meatloaf prosciutto,\
                        kevin rump turducken jerky picanha jowl doner tenderloin shank\
                        frankfurter. Ground round burgdoggen venison ham biltong",
                        image: "beer_sunset"
                    },
                    {
                        id: 3, 
                        date: "Thu Jun 21 20:53:17 2018 UTC", 
                        title: "Alle Bands wurden bereits Gefunden",
                        short: "Bacon ipsum dolor amet porchetta meatloaf prosciutto,\
                        kevin rump turducken jerky picanha jowl doner tenderloin shank\
                        frankfurter. Ground round burgdoggen venison ham biltong",
                        image: "beer_sunset"
                    }
                ],
                "fr": 
                [
                    {
                        id: 1, 
                        date: "Thu Jun 21 20:53:17 2018 UTC", 
                        title: "Francais Baguett", 
                        short: "Bacon ipsum dolor amet porchetta meatloaf prosciutto,\
                        kevin rump turducken jerky picanha jowl doner tenderloin shank\
                        frankfurter. Ground round burgdoggen venison ham biltong",
                        image: "beer_sunset"
                    },
                    {
                        id: 2, 
                        date: "Thu Jun 21 20:53:17 2018 UTC", 
                        title: "Le Fromage", 
                        short: "Bacon ipsum dolor amet porchetta meatloaf prosciutto,\
                        kevin rump turducken jerky picanha jowl doner tenderloin shank\
                        frankfurter. Ground round burgdoggen venison ham biltong",
                        image: "beer_sunset"
                    },
                    {
                        id: 3, 
                        date: "Thu Jun 21 20:53:17 2018 UTC", 
                        title: "Je suis un baguette",
                        short: "Bacon ipsum dolor amet porchetta meatloaf prosciutto,\
                        kevin rump turducken jerky picanha jowl doner tenderloin shank\
                        frankfurter. Ground round burgdoggen venison ham biltong",
                        image: "beer_sunset"
                    }
                ]
            }

        }
    },

    components: {
        'app-news': News
    },

    computed: {
        newsListLang () {
            return this.newsList[this.$store.getters.language];
        }
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
