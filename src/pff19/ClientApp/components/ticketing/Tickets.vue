<template>
  <div>
    <app-slideshow></app-slideshow>
    <description-fr v-if="language === 'fr'"></description-fr>
    <description-de v-else></description-de>
  </div>
</template>

<script>
import Vue from 'vue'

import Slideshow from './Slideshow'
import descriptionDe from './DescriptionDe'
import descriptionFr from './DescriptionFr'

import { mapActions, mapGetters } from 'vuex'

export default {
  metaInfo() {
    return {
      title: `| ${this.$i18n.t('lang.navigation.ticketing')}`
    }
  },
  computed: {
    ...mapGetters(['language'])
  },

  components: {
    'app-slideshow': Slideshow,
    descriptionFr,
    descriptionDe
  }
}
</script>

<style></style>
