<template>
    <div>
        <div class="slideshow" :style="{backgroundImage: `url(/assets/bands/images/${this.getCurrentBand.imageLarge})`}">
            <img class="slideshow-overlay" src="../../assets/images/slideshow-overlay.svg"/>
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
                
                
                <h1 class="title">{{ this.getCurrentBand.name }}</h1>

                <div class="row" v-if="this.getCurrentBand.spotifyPlaylist">
                    <div class="col-12 col-md-6 text-content" v-html="description"></div>
                    <div class="col-12 col-md-6">
                        <iframe 
                            class="spotify"
                            :src="this.getCurrentBand.spotifyPlaylist" 
                            frameborder="0" 
                            allowtransparency="true" 
                            allow="encrypted-media">
                        </iframe>
                    </div>
                </div>
                <div class="row" v-else >
                    <div class="col-12 text-content" v-html="description"></div>
                </div>
                                
                <div class="row" v-if="this.getCurrentBand.webSiteUrl">
                    <div class="col-12 band-website">
                    <a :href="this.getCurrentBand.webSiteUrl">Band Website</a>
                    </div>
                </div>
                <div class="row" v-if="this.getCurrentBand.facebook || this.getCurrentBand.instagram">
                <div class="col-12 social-media-container">
                    <div class="social-media" v-if="this.getCurrentBand.facebook">
                        <a :href="this.getCurrentBand.facebook"> <img :src="require('assets/images/001-facebook.svg')" alt="facebook" class="social-icon"> </a>
                    </div>
                    <div class="social-media" v-if="this.getCurrentBand.instagram">
                        <a :href="this.getCurrentBand.instagram"> <img :src="require('assets/images/003-instagram.svg')" alt="instagram" class="social-icon"> </a>
                    </div>
                </div>
                </div>


                <div class="youtube-container row" v-if="videos">
                    <div v-for="video in videos" :key="video" class=" col-12 col-md-6">
                        <div class="iframe-container">
                        <iframe class="ytplayer" type="text/html"
                        :src="`https://www.youtube.com/embed/${video}`"
                        frameborder="0"/>
                        </div>
                    </div>
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
            bands: {},
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

        description () {
            return this.$store.getters.language === 'de' ? this.getCurrentBand.descriptionDe : this.getCurrentBand.descriptionFr
        },
        getFirstImage () {
            if(this.getCurrentBand.images){
                return this.getCurrentBand.images.split(';')[0]
            }
        },
        videos (){
            if(this.getCurrentBand.youtubeUrls) {
                return  this.getCurrentBand.youtubeUrls.replace(/\s/g, '').split(',')
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
        padding-top: 50px; 
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

    .title {
        margin-bottom: 40px;
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

    .slideshow-overlay {
        position: absolute;
        bottom: -1px;
        right: -3px;
    }

    .ytplayer {
        width: 100%;
        height: 300px;
    }

    .youtube-container{
        margin-top: 50px 
    }

    .social-media{
        float: left;
        margin-right: 20px;
    }

    .social-icon {
        width: 40px;
    }  

    .social-media-wrapper{
        width: 100%;
    }
    .social-media-container{
        margin: 20px 20px 20px 0;
    }

    .spotify {
        float: right;
        width: 100%;
        max-width: 340px;
        height: 400px;
    }

    .band-website {
        margin: 20px 0 20px 0;
    }


    @media (max-width: 768px) { 
        .spotify {
            float:left;
        }
        .text-content {
            margin-bottom: 20px;
        }
    }
</style>

