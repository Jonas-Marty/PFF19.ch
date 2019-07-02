<template>
  <div class="container">
    <h1>{{ $t(`lang.components.program.title`) }}</h1>

    <div class="card-columns">
      <div v-for="program in all" :key="program.id" class="card">
        <router-link
          :to="{
            name: 'programDisplay',
            params: { id: program.id, name: language === 'de' ? program.nameDe : program.nameFr }
          }"
        >
          <img
            :src="`/assets/socialPrograms/thumbnail/${program.imageThumbnail}`"
            :alt="language === 'de' ? program.nameDe : program.nameFr"
            class="card-img-top"
          />
        </router-link>
        <div class="card-body">
          <router-link
            :to="{
              name: 'programDisplay',
              params: { id: program.id, name: language === 'de' ? program.nameDe : program.nameFr }
            }"
          >
            <h5 class="card-title">{{ language === 'de' ? program.nameDe : program.nameFr }}</h5>
          </router-link>
          <h6 v-if="program.startTime && program.startTime !== '0001-01-01T00:00:00'">
            {{ program.startTime | formateDateTime(language) }}
          </h6>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  metaInfo() {
    return {
      title: `| ${this.$i18n.t('lang.navigation.programOverview')}`
    }
  },

  computed: {
    ...mapGetters('program', ['all']),
    ...mapGetters(['language'])
  },

  created() {
    this.load()
  },

  methods: {
    ...mapActions('program', ['load', 'loadCurrentProgram'])
  }
}
</script>

<style lang="scss" scoped>
.container {
  padding-top: 100px;
}
</style>
