<template>
  <div>
    <h1>Files</h1>
    <router-link to="fileUpload/add">
      <i class="fa fa-add fa-1x pull-right" />hinzufügen
    </router-link>
    <div class="list-group">
      <div
        :key="file"
        v-for="file in all"
        class="list-group-item d-flex justify-content-between align-items-right"
      >
        <a :href="`/assets/files/${file}`">{{ file }}</a>
        <div>
          <i @click="remove(file)" class="fa fa-remove fa-1x pull-right"></i>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  computed: {
    ...mapGetters('files', ['all'])
  },

  created() {
    this.load()
  },

  methods: {
    ...mapActions('files', ['load', 'remove'])
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
