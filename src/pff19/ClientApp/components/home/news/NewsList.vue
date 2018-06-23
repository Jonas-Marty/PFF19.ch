<template>
    <div class="news-list">
        <div v-for="news in newsList" :key="news.id">

        </div>
    </div>
</template>

<script>
export default {
    data () {
        return {
            newsList: [
                {
                    id: 1, 
                    date: "Thu Jun 21 20:53:17 2018 UTC", 
                    title: "1000 Tickets wurden verkauft", 
                    short: "Bacon ipsum dolor amet porchetta meatloaf prosciutto,\
                    kevin rump turducken jerky picanha jowl doner tenderloin shank\
                    frankfurter. Ground round burgdoggen venison ham biltong\
                    hamburger filet mignon fatback rump capicola. Ball tip salami\
                    filet mignon t-bone cupim tongue pork ham pork loin meatball"
                }
            ]
        }
    }
}
</script>

<style>

</style>
