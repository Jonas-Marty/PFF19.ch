<template>
    <div>
        <app-slideshow></app-slideshow>
        <app-news-list></app-news-list>
        <div class="container">
            <div class="row">
                <div class="col-12 offset-md-2 col-md-8 offset-lg-2 col-lg-8">
                    <div class="iframe-container text-center">
                        <iframe class="ytplayer"
                                type="text/html"
                                src="https://www.youtube-nocookie.com/embed/jJDrwRzCLac"
                                frameborder="0"
                                allowfullscreen />
                    </div>
                </div>
            </div>
        </div>
        <description-fr v-if="language === 'fr'"></description-fr>
        <description-de v-else></description-de>
    </div>
</template>

<script>
import Vue from 'vue'

import Slideshow from './slideshow/Slideshow'
import NewsList from './news/NewsList'
import SocialMedia from './SocialMedia'
import Bands from './BandsRegistration'
import descriptionFr from './DescriptionFr'
import descriptionDe from './DescriptionDe'

import { mapActions, mapGetters } from 'vuex'

export default {
    metaInfo() {
        return {
            title: `| ${this.$i18n.t('lang.navigation.home')}`
        }
    },

    data() {
        return {}
    },

    methods: {
        ...mapActions(['enterHome', 'leaveHome'])
    },

    computed: {
        ...mapGetters(['language'])
    },

    mounted() {
        this.enterHome()
    },
    beforeDestroy() {
        this.leaveHome()
    },

    components: {
        'app-slideshow': Slideshow,
        'app-news-list': NewsList,
        'app-social-media': SocialMedia,
        'app-bands': Bands,
        descriptionFr,
        descriptionDe
    }
}
</script>

<style>
    .ytplayer {
        width: 100%;
        height: 250px;
    }
    @media (min-width: 768px) { 
        .ytplayer {
            height: 300px;
        }
    }

    @media (min-width: 992px) { 
        .ytplayer {
            height: 400px;
        }
    }

</style>
