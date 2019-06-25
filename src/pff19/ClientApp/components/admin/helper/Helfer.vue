<template>
  <div>
    <h1>Alle Helfer</h1>

    <div class="list-group">
      <div
        v-for="helfer in all"
        :key="helfer.id"
        class="list-group-item d-flex justify-content-between align-items-right"
      >
        <div>{{ helfer.name }}, {{ helfer.vorname }}, {{ helfer.pfadiname }}</div>
        <div>{{ helfer.email }}</div>
        <div>{{ helfer.wishes }}</div>
        <div>
          <i @click="remove(helfer.id)" class="fa fa-remove fa-1x pull-right"></i>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  computed: {
    ...mapGetters('helfer', ['all'])
  },

  created() {
    this.load()
  },

  methods: {
    ...mapActions('helfer', ['load', 'remove'])
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
