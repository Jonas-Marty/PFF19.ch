<template>
    <div>
        <h1>Alle News</h1>
        <router-link
            to="news/add"
            >
            hinzufügen
        </router-link>
        <div class="list-group">
            <div class="list-group-item d-flex justify-content-between align-items-center" v-for="news in all" :key="news.id">
                {{ news.titleDe }}
                <div><router-link 
                :to="{ name: 'adminNewsEdit', params: {id: news.id }}"
                >edit</router-link></div>
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
        this.load();
    },
    
    
}
</script>

