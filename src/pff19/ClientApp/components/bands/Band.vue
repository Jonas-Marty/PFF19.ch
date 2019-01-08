<template>
    <div>
        <div class="slideshow" :style="{backgroundImage: `url(/assets/bands/images/${this.getCurrentBand.imageLarge})`}">
        </div>
        <div class="container">
                <div class="row back">
                    <div class="col">
                        <router-link 
                        class="btn btn-outline-primary" 
                        :to="{name: 'bandsOverview'}">
                            Alle Bands
                        </router-link>
                    </div>
                </div>
                
                <h1>{{ this.getCurrentBand }}</h1>
                <div class="date">{{ getCurrentBand.date | formateDate }}</div>
                <br><br>

                <div class="text-content" v-html="newsContent"></div>
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
        ...mapActions('bands', [
            'loadCurrentBand'
        ])
    },

    mounted() {
            this.loadCurrentBand(this.$route.params.id)
    },

    computed: {
        ...mapGetters('bands', [
            'getCurrentBand',
        ]),

        newsContent () {
            return this.$store.getters.language === 'de' ? this.getCurrentBand.contentDe : this.getCurrentBand.contentFr;
        },
        getFirstImage () {
            if(this.getCurrentBand.images){
                return this.getCurrentBand.images.split(';')[0];
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

    .band-image {
        max-height: 100%;
        max-width: 100%;
    }

    .slideshow { 
        height: 630px;
        width: 100%;
        background-repeat: no-repeat;
        background-size: cover;
        background-position: center;
        position: relative;
        overflow: hidden;
    }
</style>

