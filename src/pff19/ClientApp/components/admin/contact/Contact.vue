<template>
  <div>
    <h1>Kontaktanfragen (neuste zuerst)</h1>
    <div class="list-group">
      <div v-for="contact in orderedContacts" :key="contact.id" class="list-group-item">
        <div class="card-body">
          <h5 class="card-title">{{ contact.firstName }}, {{ contact.lastName }}</h5>
          <h6 class="card-subtitle mb-2 text-muted">
            {{ contact.mail }}, {{ contact.submitedAt | formateDate(language) }}
          </h6>
          <p class="card-text">{{ contact.text }}</p>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  computed: {
    ...mapGetters('contact', ['all']),
    ...mapGetters(['language']),

    orderedContacts() {
      // eslint-disable-next-line vue/no-side-effects-in-computed-properties
      return this.all.sort((a, b) => (new Date(a.submitedAt) - new Date(b.submitedAt)) * -1)
    }
  },

  created() {
    this.load()
  },

  methods: {
    ...mapActions('contact', ['load'])
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
