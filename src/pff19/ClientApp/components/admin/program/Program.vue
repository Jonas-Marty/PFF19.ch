<template>
  <div>
    <h1>Programm</h1>
    <router-link :to="{name: 'adminProgramAdd'}">
      <i class="fa fa-add fa-1x pull-right"></i>hinzufügen
    </router-link>
    <div class="list-group">
      <div class="list-group-item d-flex" v-for="program in orderedPrograms" :key="program.id">
        <img
          class="list-img p-1"
          :src="`/assets/socialPrograms/thumbnail/${program.imageThumbnail}`"
          alt="Card image cap"
        >
        <div class="card-body p-5">
          <h5 class="card-title">{{ program.name }}</h5>
          <p class="card-text">{{ program.descriptionDe | shorten(150) }}</p>
          <router-link
            class="card-link"
            :to="{ name: 'programDisplay', params: { id: program.id } }"
          >View</router-link>
          <router-link
            class="card-link"
            :to="{ name: 'adminProgramEdit', params: { id: program.id } }"
          >Edit</router-link>

          <i class="fa fa-remove fa-1x pull-right" @click="remove(program.id)"></i>
          <i
            class="fa fa-arrow-up fa-1x pull-right"
            @click="toUpperElem(program.id, program.order)"
          ></i>
          <i
            class="fa fa-arrow-down fa-1x pull-right"
            @click="toLowerElem(program.id, program.order)"
          ></i>
        </div>
        <div></div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'
import axios from 'axios'

export default {
  methods: {
    ...mapActions('program', ['load', 'remove', 'swap']),

    toUpperElem(id, order) {
      let minDiff = Number.MAX_SAFE_INTEGER
      let otherElem = {}

      this.orderedPrograms.forEach(el => {
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

      this.orderedPrograms.forEach(el => {
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
  },

  computed: {
    ...mapGetters('program', ['all']),
    orderedPrograms() {
      return this.all.sort((a, b) => a.order - b.order)
    }
  },

  created() {
    this.load()
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
