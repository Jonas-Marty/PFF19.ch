<template>
  <div class="card-columns">
    <div v-for="band in filteredBands" :key="band.id" class="card">
      <router-link :to="{ name: 'band', params: { id: band.id, name: band.name } }">
        <img
          :src="`/assets/bands/thumbnail/${band.imageThumbnail}`"
          :alt="band.name"
          class="card-img-top"
        />
      </router-link>
      <div class="card-body">
        <router-link :to="{ name: 'band', params: { id: band.id, name: band.name } }">
          <h5 class="card-title">{{ band.name }}</h5>
        </router-link>
        <h6>{{ band.playTimeForSorting | formateDateTime(language) }} | {{band.stage}}</h6>
      </div>
    </div>
  </div>
</template>
<script>
import { mapGetters } from 'vuex'
import moment from 'moment'

export default {
  metaInfo() {
    return {
      title: `| ${this.$i18n.t('lang.navigation.bandsOverview')}`
    }
  },

  // eslint-disable-next-line vue/require-prop-types
  props: ['selectedDay'],

  data() {
    return {
      days: [
        {
          name: 'whole_weekend',
          start: new moment('2019-08-30T00:00:00'),
          end: new moment('2019-09-02T00:00:00')
        },
        {
          name: 'friday',
          start: new moment('2019-08-30T00:00:00'),
          end: new moment('2019-08-31T05:00:00')
        },
        {
          name: 'saturday',
          start: new moment('2019-08-31T05:00:01'),
          end: new moment('2019-09-01T05:00:00')
        },
        {
          name: 'sunday',
          start: new moment('2019-09-01T05:00:01'),
          end: new moment('2019-09-02T00:00:00')
        }
      ]
    }
  },

  computed: {
    ...mapGetters('bands', ['all']),
    ...mapGetters(['language']),
    filteredBands() {
      return this.all.filter(band => {
        const bandTime = new moment(band.playTimeForSorting)
        if (this.selectedDay === 'whole_weekend') {
          return true
        }

        if (
          bandTime.isBetween(
            this.days.find(d => d.name === this.selectedDay).start,
            this.days.find(d => d.name === this.selectedDay).end
          )
        ) {
          return true
        }
        return false
      })
    }
  }
}
</script>

<style lang="scss" scoped>
.container {
  padding-top: 100px;
}
</style>
