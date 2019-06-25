<template>
  <div class="container">
    <div class="row">
      <div class="col-md-8 col-lg-9">
        <h1>{{ $t(`lang.navigation.foodAndBarsOverview`) }}</h1>
      </div>
    </div>
    <div class="card-columns">
      <div v-for="bar in all" :key="bar.id" class="card">
        <router-link
          :to="{
            name: 'foodAndBar',
            params: { id: bar.id, name: language === 'de' ? bar.nameDe : bar.nameFr }
          }"
        >
          <img
            :src="`/assets/bars/thumbnail/${bar.imageThumbnail}`"
            :alt="bar.nameDe"
            class="card-img-top"
          />
        </router-link>
        <div class="card-body">
          <router-link
            :to="{
              name: 'foodAndBar',
              params: {
                id: bar.id,
                name: language === 'de' ? bar.nameDe : bar.nameFr
              }
            }"
          >
            <h5 class="card-title">
              {{ language === 'de' ? bar.nameDe : bar.nameFr }}
            </h5>
          </router-link>
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
      title: `| ${this.$i18n.t('lang.navigation.foodAndBarsOverview')}`
    }
  },

  computed: {
    ...mapGetters('bars', ['all']),
    ...mapGetters(['language'])
  },

  created() {
    this.load()
  },

  methods: {
    ...mapActions('bars', ['load', 'loadCurrentBar'])
  }
}
</script>

<style lang="scss" scoped>
.container {
  padding-top: 100px;
}
</style>
