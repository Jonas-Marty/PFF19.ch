<template>
  <div class="container">
    <h1>Alle News</h1>
    <div class="row">
      <app-news v-for="news in all" :key="news.id" :news="news"></app-news>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'

import News from './NewsThumpnail'
import NUMBER_OF_NEWS_ON_HOMEPAGE from '../../constants/main'

export default {
  metaInfo() {
    return {
      title: `| ${this.$i18n.t('lang.navigation.news_overview')}`
    }
  },

  components: {
    'app-news': News
  },

  data() {
    return {
      newsList: []
    }
  },

  computed: {
    ...mapGetters('news', ['all'])
  },

  created() {
    if (!(this.all.length > NUMBER_OF_NEWS_ON_HOMEPAGE)) {
      this.load()
    }
  },

  methods: {
    ...mapActions('news', ['load'])
  }
}
</script>

<style lang="scss" scoped>
.container {
  padding-top: 100px;
}
</style>
