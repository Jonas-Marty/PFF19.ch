<template>
  <div class="container">
    <div class="row">
      <div class="col-md-8 col-lg-9">
        <h1>{{ $t(`lang.components.bands.title`) }}</h1>
      </div>
      <div class="col-md-4 col-lg-3">
        <form>
          <div class="form-group">
            <select id="days" v-model="selectedDay" class="form-control">
              <option
                v-for="day in days"
                :key="day.name"
                :value="day.name"
                :selected="day.name === selectedDay"
                >{{ $t(`lang.components.bands.${day.name}`) }}</option
              >
            </select>
          </div>
        </form>
      </div>
    </div>
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
          <h6>{{ band.playTimeForSorting | formateDateTime(language) }}</h6>
          <p class="card-text"></p>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'
import moment from 'moment'

export default {
  metaInfo() {
    return {
      title: `| ${this.$i18n.t('lang.navigation.bandsOverview')}`
    }
  },

  data() {
    return {
      selectedDay: 'whole_weekend',
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
  },

  created() {
    this.load()
  },

  methods: {
    ...mapActions('bands', ['load', 'loadCurrentBand'])
  }
}
</script>

<style lang="scss" scoped>
.container {
  padding-top: 100px;
}
</style>
