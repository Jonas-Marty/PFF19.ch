<template>
  <div>
    <div v-for="day in days" :key="day.name">
      <table class="table">
        <thead class="dark">
          <tr>
            <th scope="col" colspan="3">{{ $t(`lang.components.bands.${day.name}`) }}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="band in filteredBands(day.name)">
            <td class="time">{{ band.playTimeForSorting | formateTime(language) }}</td>

            <td>
              <router-link
                :to="{ name: 'band', params: { id: band.id, name: band.name } }"
              >{{ band.name }}</router-link>
            </td>
            <td class="place">{{band.stage ? band.stage: ''}}</td>
          </tr>
        </tbody>
      </table>
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

  data() {
    return {
      selectedDay: 'whole_weekend',
      days: [
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
    ...mapGetters(['language'])
  },

  methods: {
    filteredBands(day) {
      return this.all
        .filter(band => {
          const bandTime = new moment(band.playTimeForSorting)
          if (
            bandTime.isBetween(
              this.days.find(d => d.name === day).start,
              this.days.find(d => d.name === day).end
            )
          ) {
            return true
          }
          return false
        })
        .sort((a, b) => moment.utc(a.playTimeForSorting).diff(moment.utc(b.playTimeForSorting)))
    }
  }
}
</script>

<style lang="scss" scoped>
.table {
  background-color: white;
  margin-bottom: 0;
}
.dark {
  background-color: #202020;
  color: white;
  text-transform: uppercase;
}
.time {
  width: 100px;
}
.place {
  width: 120px;
}
</style>
