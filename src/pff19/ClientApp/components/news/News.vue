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
                <div class="img" :style="imagePath" alt="Card image"></div>
                <div class="date">{{ news.date | formateDate }}</div>
                

                <div class="text-content" v-html="newsContent"></div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';


export default {
    data () {
        return {
            news: {}
        }
    },

    beforeCreate(){
        axios.get('/api/news/' + this.$route.params.id) 
            .then(response => {
                this.news = response.data;
            }).catch(e => {
                console.log('error');
            });
    },

    computed: {
        imagePath () {
            return "background-image: url(/assets/news/images/" + this.news.image + ")";

        },
        newsTitle () {
            return this.$store.getters.language === 'de' ? this.news.titleDe : this.news.titleFr;
        },
        newsContent () {
            return this.$store.getters.language === 'de' ? this.news.contentDe : this.news.contentFr;
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
        height: 500px;
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

