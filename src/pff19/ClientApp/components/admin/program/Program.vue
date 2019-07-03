<template>
  <div>
    <h1>Programm</h1>
    <router-link :to="{ name: 'adminProgramAdd' }">
      <i class="fa fa-add fa-1x pull-right"></i>hinzufügen
    </router-link>
    <div class="list-group">
      <div v-for="program in orderedPrograms" :key="program.id" class="list-group-item d-flex">
        <img
          :src="`/assets/socialPrograms/thumbnail/${program.imageThumbnail}`"
          class="list-img p-1"
          alt="Card image cap"
        />
        <div class="card-body p-5">
          <h5 class="card-title">{{ program.name }}</h5>
          <p class="card-text">{{ program.descriptionDe | shorten(150) }}</p>
          <router-link
            :to="{ name: 'programDisplay', params: { id: program.id } }"
            class="card-link"
            >View</router-link
          >
          <router-link
            :to="{ name: 'adminProgramEdit', params: { id: program.id } }"
            class="card-link"
            >Edit</router-link
          >

          <i @click="remove(program.id)" class="fa fa-remove fa-1x pull-right"></i>
          <i
            @click="toUpperElem(program.id, program.order)"
            class="fa fa-arrow-up fa-1x pull-right"
          ></i>
          <i
            @click="toLowerElem(program.id, program.order)"
            class="fa fa-arrow-down fa-1x pull-right"
          ></i>
        </div>
        <div></div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'
import auth from 'utils/auth'

export default {
  computed: {
    ...mapGetters('program', ['all']),
    orderedPrograms() {
      // eslint-disable-next-line vue/no-side-effects-in-computed-properties
      return this.all.sort((a, b) => a.order - b.order)
    }
  },

  created() {
    this.load()
  },
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
        auth.put(`socialprograms/${id}/${otherElem.id}`).then(() =>
        //this.swap({ first: id, second: otherElem.id })
        window.location.reload() //fucking ugly way to do it but i dont have time to do it better
        )
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
        auth.put(`socialprograms/${id}/${otherElem.id}`).then(() =>
        //this.swap({ first: id, second: otherElem.id })
        window.location.reload() //fucking ugly way to do it but i dont have time to do it better
        )
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
