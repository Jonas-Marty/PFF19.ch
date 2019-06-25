<template>
  <div>
    <h1>Alle FAQs</h1>
    <router-link to="faqs/add"> <i class="fa fa-add fa-1x pull-right"></i>hinzufügen </router-link>
    <div class="list-group">
      <div
        v-for="faq in orderedFaqs"
        :key="faq.id"
        class="list-group-item d-flex justify-content-between align-items-right"
      >
        <div>{{ faq.questionDe }}</div>
        <div>
          <i class="fa fa-remove fa-1x pull-right" @click="remove(faq.id)"></i>
          <router-link :to="{ name: 'adminFAQEdit', params: { id: faq.id } }">
            <i class="fa fa-edit fa-1x pull-right"></i>
          </router-link>
          <i class="fa fa-arrow-up fa-1x pull-right" @click="toUpperElem(faq.id, faq.order)"></i>
          <i class="fa fa-arrow-down fa-1x pull-right" @click="toLowerElem(faq.id, faq.order)"></i>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  computed: {
    ...mapGetters('faqs', ['all']),
    orderedFaqs() {
      // eslint-disable-next-line vue/no-side-effects-in-computed-properties
      return this.all.sort((a, b) => a.order - b.order)
    }
  },

  created() {
    this.load()
  },

  methods: {
    ...mapActions('faqs', ['load', 'remove', 'swap']),

    toUpperElem(id, order) {
      let minDiff = Number.MAX_SAFE_INTEGER
      let otherElem = {}

      this.orderedFaqs.forEach(el => {
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

      this.orderedFaqs.forEach(el => {
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
</style>
