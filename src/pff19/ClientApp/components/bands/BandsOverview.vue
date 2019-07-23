<template>
  <div class="container">
    <div class="header row">
      <div class="col-md-4 col-lg-4">
        <h1>{{ $t(`lang.components.bands.title`) }}</h1>
      </div>
      <div class="col-md-8 col-lg-8">
        <div class="pull-right">
          <button
            v-for="opt in btnOptions"
            :key="opt"
            @click="selectedOpt = opt"
            :class="{ active: selectedOpt == opt }"
            class="btn btn-outline-primary"
          >
            {{ $t(`lang.components.bands.${opt}`) }}
          </button>
        </div>
        <!-- <form>
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
        </form> -->
      </div>
    </div>
    <time-table v-if="selectedOpt == 'timeTable'" />
    <thumpnail-listing v-else :selectedDay="selectedOpt" />
  </div>
</template>
<script>
import { mapActions } from 'vuex'

import BandsThumpnailListing from './BandThumpnailListing'
import BandsTimeTable from './BandsTimeTable'

export default {
  components: {
    'thumpnail-listing': BandsThumpnailListing,
    'time-table': BandsTimeTable
  },
  metaInfo() {
    return {
      title: `| ${this.$i18n.t('lang.navigation.bandsOverview')}`
    }
  },

  data() {
    return {
      selectedOpt: 'whole_weekend',
      btnOptions: ['whole_weekend', 'friday', 'saturday', 'sunday', 'timeTable']
    }
  },
  created() {
    this.load()
  },

  methods: {
    ...mapActions('bands', ['load'])
  }
}
</script>

<style lang="scss" scoped>
.container {
  padding-top: 100px;
}

.header {
  margin-bottom: 30px;
}

.btn {
  margin: 5px;
}
</style>
