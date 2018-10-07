<template>
    <div>
        <h1>Alle News</h1>
        <router-link
            to="news/add"
            >
            hinzufügen
        </router-link>
        <div class="list-group">
            <div class="list-group-item" v-for="news in all" :key="news.id">
                {{ news.titleDe }}
            </div>
        </div>
    </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex';
import axios from 'axios';


export default {

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
        if(!(this.all.length > 0)){
            this.load();
        }
    },
    
}
</script>

