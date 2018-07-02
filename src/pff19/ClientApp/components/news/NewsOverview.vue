<template>
    <div class="container">
        <h1>Alle News</h1>
        <div class="row">
            <app-news v-for="news in newsList" :key="news.id" :news="news"></app-news>
        </div>
    </div>
</template>

<script>
import News from './NewsThumpnail';

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
                },
                {
                    id: 4, 
                    date: "Thu Jun 21 20:53:17 2018 UTC", 
                    title: "Der Aufbau beginnt", 
                    short: "Bacon ipsum dolor amet porchetta meatloaf prosciutto,\
                    kevin rump turducken jerky picanha jowl doner tenderloin shank\
                    frankfurter. Ground round burgdoggen venison ham biltong",
                    image: "beer_sunset"
                },
                {
                    id: 5, 
                    date: "Thu Jun 21 20:53:17 2018 UTC", 
                    title: "1000 Tickets wurden verkauft", 
                    short: "Bacon ipsum dolor amet porchetta meatloaf prosciutto,\
                    kevin rump turducken jerky picanha jowl doner tenderloin shank\
                    frankfurter. Ground round burgdoggen venison ham biltong",
                    image: "beer_sunset"
                },
                {
                    id: 6, 
                    date: "Thu Jun 21 20:53:17 2018 UTC", 
                    title: "Alle Bands wurden bereits Gefunden",
                    short: "Bacon ipsum dolor amet porchetta meatloaf prosciutto,\
                    kevin rump turducken jerky picanha jowl doner tenderloin shank\
                    frankfurter. Ground round burgdoggen venison ham biltong",
                    image: "beer_sunset"
                },
                {
                    id: 7, 
                    date: "Thu Jun 21 20:53:17 2018 UTC", 
                    title: "Der Aufbau beginnt", 
                    short: "Bacon ipsum dolor amet porchetta meatloaf prosciutto,\
                    kevin rump turducken jerky picanha jowl doner tenderloin shank\
                    frankfurter. Ground round burgdoggen venison ham biltong",
                    image: "beer_sunset"
                },
                {
                    id: 8, 
                    date: "Thu Jun 21 20:53:17 2018 UTC", 
                    title: "1000 Tickets wurden verkauft", 
                    short: "Bacon ipsum dolor amet porchetta meatloaf prosciutto,\
                    kevin rump turducken jerky picanha jowl doner tenderloin shank\
                    frankfurter. Ground round burgdoggen venison ham biltong",
                    image: "beer_sunset"
                },
                {
                    id: 9, 
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
    .container {
        padding-top: 100px;
    }
</style>
