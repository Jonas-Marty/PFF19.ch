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
import Slideshow from './slideshow/Slideshow'
import NewsList from './news/NewsList'
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

  components: {
    'app-slideshow': Slideshow,
    'app-news-list': NewsList,
    descriptionFr,
    descriptionDe,
    ytvideo: ytVideo
  },

  data() {
    return {}
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

  methods: {
    ...mapActions(['enterHome', 'leaveHome'])
  }
}
</script>
