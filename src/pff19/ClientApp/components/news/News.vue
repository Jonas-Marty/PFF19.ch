<template>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-8">
                <div class="row back">
                    <div class="col">
                        <router-link class="btn btn-outline-primary" to="/news">Alle News</router-link>
                    </div>
                </div>
                
                <h1>{{ newsTitle }}</h1>
                <img class="img" :src="`/assets/news/images/${getFirstImage}`" :alt="newsTitle">
                <div class="date">{{ getCurrentNews.date | formateDate }}</div>
                <br><br>

                <div class="text-content" v-html="newsContent"></div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import { mapGetters, mapActions } from 'vuex'


export default {
    data () {
        return {
            news: {}
        }
    },

    methods: {
        ...mapActions('news', [
            'loadCurrentNews'
        ])
    },

    mounted() {
            this.loadCurrentNews(this.$route.params.id)
    },

    computed: {
        ...mapGetters('news', [
            'getCurrentNews',
        ]),

        newsTitle () {
            return this.$store.getters.language === 'de' ? this.getCurrentNews.titleDe : this.getCurrentNews.titleFr;
        },
        newsContent () {
            return this.$store.getters.language === 'de' ? this.getCurrentNews.contentDe : this.getCurrentNews.contentFr;
        },
        getFirstImage () {
            if(this.getCurrentNews.images){
                return this.getCurrentNews.images.split(';')[0];
            }
        }
        
    }
}
</script>

<style lang="scss" scoped>
    h1 {
        margin-bottom: 20px;
    }
    .container {
        padding-top: 100px; 
    }

    .img {
        max-height: 500px;
        max-width: 100%;
        background-size: cover;
        margin-bottom: 20px;
    }

    .date {
        margin-bottom: 30px;
    }

    .back {
        margin-bottom: 30px;
    }
</style>

