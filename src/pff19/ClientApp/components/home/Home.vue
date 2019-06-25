<template>
    <div>
        <app-slideshow></app-slideshow>
        <app-news-list></app-news-list>
        <description-fr v-if="language === 'fr'"></description-fr>
        <description-de v-else></description-de>
        <ytvideo></ytvideo>
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
import ytVideo from './YoutubeVideo'

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
        descriptionDe,
        'ytvideo': ytVideo
    }
}
</script>
