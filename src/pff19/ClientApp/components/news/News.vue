<template>
    <div class="container">
        <div class="row back">
            <div class="col">
                <router-link class="btn btn-outline-primary" to="/news"> Übersicht</router-link>
            </div>
        </div>
        <h1>{{ news.title }}</h1>
        <div class="card-img-top" :style="'background-image: url(' + imagePath +')'" alt="Card image"></div>
        {{ news.content }}
    </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex';
import axios from 'axios';


export default {
    data () {
        return {
            news: {}
        }
    },

    created(){
        axios.get('/api/news/' + this.$route.params.id) 
            .then(response => {
                this.news = response.data;
            }).catch(e => {
                console.log('error');
            });
    },

    computed: {
        imagePath () {
            return require("../../assets/news/" + this.news.image);
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

    .card-img-top {
        height: 500px;
        background-size: cover;
        margin-bottom: 50px;
    }

    .back {
        margin-bottom: 40px;
    }
</style>

