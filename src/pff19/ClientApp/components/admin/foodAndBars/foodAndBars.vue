<template>
  <div>
    <h1>Food and Bars</h1>
    <router-link :to="{ name: 'adminFoodAndBarsAdd' }">
      <i class="fa fa-add fa-1x pull-right"></i>hinzufügen
    </router-link>
    <div class="list-group">
      <div v-for="bar in orderedBars" :key="bar.id" class="list-group-item d-flex">
        <img
          :src="`/assets/bars/thumbnail/${bar.imageThumbnail}`"
          class="list-img p-1"
          alt="Card image cap"
        />
        <div class="card-body p-5">
          <h5 class="card-title">{{ bar.nameDe }}</h5>
          <p class="card-text">{{ bar.descriptionDe | shorten(150) }}</p>
          <router-link
            :to="{ name: 'foodAndBar', params: { id: bar.id, name: bar.nameDe } }"
            class="card-link"
            >View</router-link
          >
          <router-link
            :to="{ name: 'adminFoodAndBarsEdit', params: { id: bar.id } }"
            class="card-link"
            >Edit</router-link
          >

          <i @click="remove(bar.id)" class="fa fa-remove fa-1x pull-right"></i>
          <i @click="toUpperElem(bar.id, bar.order)" class="fa fa-arrow-up fa-1x pull-right"></i>
          <i @click="toLowerElem(bar.id, bar.order)" class="fa fa-arrow-down fa-1x pull-right"></i>
        </div>
        <div></div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  computed: {
    ...mapGetters('bars', ['all']),
    orderedBars() {
      // eslint-disable-next-line vue/no-side-effects-in-computed-properties
      return this.all.sort((a, b) => a.order - b.order)
    }
  },

  created() {
    this.load()
  },

  methods: {
    ...mapActions('bars', ['load', 'remove', 'swap']),

    toUpperElem(id, order) {
      let minDiff = Number.MAX_SAFE_INTEGER
      let otherElem = {}

      this.orderedBars.forEach(el => {
        const diff = order - el.order
        if (diff > 0 && diff < minDiff) {
          minDiff = diff
          otherElem = el
        }
      })
      if (Object.keys(otherElem).length !== 0) {
        this.swap({ first: id, second: otherElem.id })
        window.location.reload() //fucking ugly way to do it but i dont have time to do it better
      }
    },

    toLowerElem(id, order) {
      let minDiff = Number.MAX_SAFE_INTEGER
      let otherElem = {}

      this.orderedBars.forEach(el => {
        const diff = el.order - order
        if (diff > 0 && diff < minDiff) {
          minDiff = diff
          otherElem = el
        }
      })

      if (Object.keys(otherElem).length !== 0) {
        this.swap({ first: id, second: otherElem.id }).then(this.load())
        window.location.reload() //fucking ugly way to do it but i dont have time to do it better
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.fa-remove {
  cursor: pointer;
}

.fa-edit {
  margin-right: 5px;
}

.list-img {
  border-bottom: 2px solid #212529;
  max-width: auto;
  height: auto;
}

.fa-arrow-up {
  margin-right: 20px;
}
</style>
