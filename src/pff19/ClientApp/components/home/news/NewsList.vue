<template>
    <div class="news-list container">
        <div class="row">
            <app-news v-for="news in newsList" :key="news.id" :news="news"> </app-news>
        </div>
            <div class="float-right">
                <router-link
                    :to="{name: 'news_overview'}"
                    class=""
                > weitere News</router-link>
            </div>
    </div>
</template>

<script>
import Vue from 'vue';
import News from './News';

export default {
    data () {
        return {
            newsList: [
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
            ]
        }
    },

    components: {
        'app-news': News
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
