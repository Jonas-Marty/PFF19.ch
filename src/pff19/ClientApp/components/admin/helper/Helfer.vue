<template>
  <div>
    <h1>Alle Helfer</h1>

    <div class="list-group">
      <div
        class="list-group-item d-flex justify-content-between align-items-right"
        v-for="helfer in all"
        :key="helfer.id"
      >
        <div>{{ helfer.name }}, {{ helfer.vorname }}, {{ helfer.pfadiname }}</div>
        <div>
          {{ helfer.email }}
        </div>
        <div>
          {{ helfer.wishes }}
        </div>
        <div>
          <i class="fa fa-remove fa-1x pull-right" @click="remove(helfer.id)"></i>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'
import axios from 'axios'

export default {
  methods: {
    ...mapActions('helfer', ['load', 'remove'])
  },

  computed: {
    ...mapGetters('helfer', ['all'])
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
</style>
