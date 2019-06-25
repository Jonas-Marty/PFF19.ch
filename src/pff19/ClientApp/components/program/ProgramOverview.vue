<template>
  <div class="container">
    <h1>{{ $t(`lang.components.program.title`) }}</h1>

    <div class="card-columns">
      <div class="card" v-for="program in all" :key="program.id">
        <router-link
          :to="{ name: 'programDisplay', params: { id: program.id, name: language === 'de' ? program.nameDe : program.nameFr } }"
        >
          <img
            class="card-img-top"
            :src="`/assets/socialPrograms/thumbnail/${program.imageThumbnail}`"
            :alt="language === 'de' ? program.nameDe : program.nameFr"
          >
        </router-link>
        <div class="card-body">
          <router-link
            :to="{ name: 'programDisplay', params: { id: program.id, name: language === 'de' ? program.nameDe : program.nameFr } }"
          >
            <h5 class="card-title">{{ language === 'de' ? program.nameDe : program.nameFr }}</h5>
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'
import axios from 'axios'
import i18n from 'locales'
import moment from 'moment'

export default {
  metaInfo() {
    return {
      title: `| ${this.$i18n.t('lang.navigation.programOverview')}`
    }
  },

  methods: {
    ...mapActions('program', ['load', 'loadCurrentProgram'])
  },

  computed: {
    ...mapGetters('program', ['all']),
    ...mapGetters(['language'])
  },

  created() {
    this.load()
  }
}
</script>

<style lang="scss" scoped>
.container {
  padding-top: 100px;
}
</style>
